﻿using Microsoft.EntityFrameworkCore;
using WebApp.API.Models;

namespace WebApp.API.Contexts
{
    public class CityInHomePageContext : DbContext
    {
        public CityInHomePageContext(DbContextOptions<CityInHomePageContext> options)
            : base(options)
        {
        }
        private CityInHomePageContext() => Database.EnsureCreated();

        public DbSet<CityInHomePage> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityInHomePage>(entity =>
            {
                entity.ToView("city_in_home_page_view");
                entity.Property("Id").HasColumnName("id");
                entity.Property("Title").HasColumnName("title");
                entity.Property("PictureLink").HasColumnName("picturelink");
                entity.Property("PageName").HasColumnName("pagename");
                entity.Property("VisiblePage").HasColumnName("pagevisible");
            });
        }
    }
}
