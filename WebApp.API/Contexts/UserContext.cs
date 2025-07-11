﻿using Microsoft.EntityFrameworkCore;
using WebApp.API.Models;

namespace WebApp.API.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
                    : base(options)
        {
        }
        private UserContext() => Database.EnsureCreated();

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user_website");
                entity.Property("Id").HasColumnName("id");
                entity.Property("FirstName").HasColumnName("firstname");
                entity.Property("LastName").HasColumnName("lastname");
                entity.Property("Email").HasColumnName("email");
                entity.Property("PasswordHash").HasColumnName("passwordhash");
                entity.Property("Age").HasColumnName("age");
                entity.Property("UserType").HasColumnName("typeuser"); 
                entity.Property("RegistrationIp").HasColumnName("registrationip");
                entity.Property("LastIp").HasColumnName("lastip");
                entity.Property("AvatarLink").HasColumnName("avatar_link");
            });
        }
    }
}
