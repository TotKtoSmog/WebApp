﻿using Microsoft.EntityFrameworkCore;
using WebApp.API.Models;

namespace WebApp.API.Contexts
{
    public class LocationInHomePageContext : DbContext
    {
        public LocationInHomePageContext(DbContextOptions<LocationInHomePageContext> options)
            : base(options)
        {
        }
        private LocationInHomePageContext() => Database.EnsureCreated();
        public DbSet<LocationInHomePage> Locations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocationInHomePage>(entity =>
            {
                entity.ToView("location_in_home_page");
                entity.Property("Id").HasColumnName("id");
                entity.Property("CityId").HasColumnName("id_city");
                entity.Property("Title").HasColumnName("title");
                entity.Property("Description").HasColumnName("description");
                entity.Property("Address").HasColumnName("address");
                entity.Property("WorkSchedule").HasColumnName("workschedule");
                entity.Property("TicketLink").HasColumnName("ticketlink");
                entity.Property("PictureLink").HasColumnName("picturepagelink");
                entity.Property("PageName").HasColumnName("pagename");
            });
        }
    }
}
