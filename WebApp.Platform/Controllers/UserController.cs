﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.API.Models;
using WebApp.Platform.Models;
using WebApp.Platform.Services.Interfaces;

namespace WebApp.Platform.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IUserSearch _search;
        public UserController(ILogger<UserController> logger, 
            IUserService userService,
            IUserSearch search)
        {
            _logger = logger;
            _userService = userService;
            _search = search;
        }

        [Authorize]
        [HttpGet("[controller]/profile")]
        [HttpGet("[controller]/index")]
        [HttpGet("[controller]")]
        public async Task<IActionResult> Index()
        {
            var token = Request.Cookies["jwt_token"];
            var user = await _userService.GetUserByTokenAsync(token ?? "");
            
            var feedbackTask = _userService.GetUserFeedbackAsync(user.Id);
            var favoriteLocationsTask = _userService.GetFavoriteLocationsAsync(user.Id);
            var subscriptionsTask = _userService.GetUserSubscriptionsAsync(user.Id);
            var followersTask = _userService.GetUserFollowersAsync(user.Id);
            var recommendationsTask = _userService.GetUserRecommendation(user.Id);

            await Task.WhenAll(feedbackTask, favoriteLocationsTask, subscriptionsTask, followersTask, recommendationsTask);

            var feedback = feedbackTask.Result;
            var favoriteLocations = favoriteLocationsTask.Result;
            var subscriptions = subscriptionsTask.Result;
            var followers = followersTask.Result;
            var recommendations = recommendationsTask.Result;

            AllUserInformation userInformation = 
                new AllUserInformation(user, feedback, favoriteLocations, 
                subscriptions, followers, recommendations);
            if (user.UserType)
                return RedirectToAction("Index", "City", new { area = "Admin" });
            ViewData["userType"] = "I";
            return View(userInformation);
        }
        [Authorize]
        [HttpGet("[controller]/profile/{id}")]
        [HttpGet("[controller]/index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var token = Request.Cookies["jwt_token"];
            var u = await _userService.GetUserByTokenAsync(token ?? "");
            var mySubscript = await _userService.GetUserSubscriptionsAsync(u.Id);
            var mySubscriptId = mySubscript.Select(s => s.FollowerId).ToHashSet();
            ViewData["userType"] = u.Id == id
                ? "I" : mySubscriptId.Contains(id)
                ? "subscribers" : "other";

            var userTask = _userService.GetAsync(id);
            var feedbackTask = _userService.GetUserFeedbackAsync(id);
            var favoriteLocationsTask = _userService.GetFavoriteLocationsAsync(id);
            var subscriptionsTask = _userService.GetUserSubscriptionsAsync(id);
            var followersTask = _userService.GetUserFollowersAsync(id);

            await Task.WhenAll(userTask, feedbackTask, favoriteLocationsTask, subscriptionsTask, followersTask);

            var user = userTask.Result;
            var feedback = feedbackTask.Result;
            var favoriteLocations = favoriteLocationsTask.Result;
            var subscriptions = subscriptionsTask.Result;
            var followers = followersTask.Result;
            if (user == null) return NotFound();
            AllUserInformation userInformation = new AllUserInformation(user, feedback, favoriteLocations, 
                subscriptions, followers);
            return View(userInformation);
        }
        [HttpGet]
        public IActionResult Registration()
        {
            ModelState.Clear();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(UserRegistration user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            if (!await _userService.RegistrationUserAsync(user))
            {
                ModelState.AddModelError("", "Ошибка при регистрации. Возможно, пароли не совпадают или email уже занят.");
                return View(user);
            }
            TempData["SuccessMessage"] = "Регистрация прошла успешно!";
            return View();
        }
        [HttpGet]
        public IActionResult Authorization()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("profile");

            ModelState.Clear();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Authorization(UserAuthorization user)
        {
            if (!ModelState.IsValid)
                return View(user);
            var token = await _userService.AuthorizationUserAsync(user);
            if (token == null)
            {
                ModelState.AddModelError("", "Пользователь не найден. Возможно неверно указан логин или пароль.");
                return View(user);
            }
            Response.Cookies.Append("jwt_token", token, new CookieOptions
            {
                HttpOnly = true,               
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddMinutes(360)
            });
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt_token");
            return RedirectToAction("Authorization");
        }
        [HttpGet]
        public async Task<IActionResult> Search(string email)
        {
            var token = Request.Cookies["jwt_token"];
            var currentUser = await _userService.GetUserByTokenAsync(token ?? "");

            var usersTask = _search.GetAllAsync();
            var subscriptionsTask = _userService.GetUserSubscriptionsAsync(currentUser.Id);

            await Task.WhenAll(usersTask, subscriptionsTask);

            var subscriptionIds = subscriptionsTask.Result.Select(f => f.FollowerId).ToHashSet();

            var users = usersTask.Result
                .Where(u => u.Id != currentUser.Id)
                .Where(u => !subscriptionIds.Contains(u.Id))
                .ToList();

            return View(users.Where(user => user.Email.Contains(email ?? "")));
        }
        [HttpPost]
        public async Task<IActionResult> Subscribe(int id)
        {
            var token = Request.Cookies["jwt_token"];
            var currentUser = await _userService.GetUserByTokenAsync(token ?? "");

            await _search.AddFollowersAsync(new UserFollower { Id = 0, IdUser = currentUser.Id, IdFollower = id});
            
            var referer = Request.Headers["Referer"].ToString();

            if (!string.IsNullOrEmpty(referer))
                return Redirect(referer);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UnSubscribe(int id)
        {
            var token = Request.Cookies["jwt_token"];
            var currentUser = await _userService.GetUserByTokenAsync(token ?? "");

            var subscription = await _userService.GetUserSubscriptionsAsync(currentUser.Id);

            var subscriptionId = subscription.FirstOrDefault(s => s.FollowerId == id)?.id;

            await _search.DeleteFollowersAsync(subscriptionId ?? 0);

            var referer = Request.Headers["Referer"].ToString();

            if (!string.IsNullOrEmpty(referer))
                return Redirect(referer);
            return RedirectToAction("Index");
        }
    }
}
