﻿namespace WebApp.Platform.Services.Interfaces
{
    public interface IClientIpService
    {
        string GetClientIp(HttpContext context);
        string GetClientIp();
    }
}
