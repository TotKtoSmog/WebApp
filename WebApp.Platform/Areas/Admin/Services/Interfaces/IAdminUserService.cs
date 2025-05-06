namespace WebApp.Platform.Areas.Admin.Services.Interfaces
{
    public interface IAdminUserService
    {
        public Task<List<API.Models.User>> GetAll();
    }
}
