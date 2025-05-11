using WebApp.API.Models;

namespace WebApp.Platform.Models
{
    public class AllUserInformation
    {
        public User User;
        public List<UserFeedback> Feedbacks;
        public AllUserInformation(User user, List<UserFeedback> feedbacks)
        {
            User = user;
            Feedbacks = feedbacks;
        }
    }
}
