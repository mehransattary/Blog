using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
   public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        #region Weblogs
        public DbSet<WebLog> Weblogs { get; set; }
        public DbSet<WebLog_Category> webLog_Categories { get; set; }
        public DbSet<WebLog_Comment> webLog_Comments { get; set; }

        public DbSet<WebLog_Group> WebLog_Groups { get; set; }
        public DbSet<Entities.WebLog_ImageAdvertise> WebLog_ImageAdvertises { get; set; }
        public DbSet<WebLog_Label> WebLog_Labels { get; set; }

        public DbSet<WebLog_Label_Blog> WebLog_Label_Blogs { get; set; }
        public DbSet<WebLog_SelectedBlogs> WebLog_SelectedBlogs { get; set; }
        public DbSet<WebLog_Slider> WebLog_Sliders { get; set; }

        public DbSet<WebLog_Category_Views> WebLog_Category_Views { get; set; }
        public DbSet<WebLog_Group_Views> WebLog_Group_Views { get; set; }
        public DbSet<WebLog_Label_Views>  WebLog_Label_Views { get; set; }
        public DbSet<WebLog_Views>  WebLog_Views { get; set; }

        #endregion

        #region Settings
        public DbSet<Settings> Settings { get; set; }
        public DbSet<SettingAdvertising> settingAdvertisings { get; set; }
        public DbSet<SettingsCopyRight> SettingsCopyRights { get; set; }

        public DbSet<SettingsEnemad> SettingsEnemads { get; set; }
        public DbSet<SettingsLogo> SettingsLogos { get; set; }
        public DbSet<SettingsMeta> SettingsMetas { get; set; }
        #endregion
        public DbSet<Social> Socials { get; set; }
        public DbSet<AbouteMe> AbouteMe { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.DeleteBehavior_Restrict();
        }
    }
}
