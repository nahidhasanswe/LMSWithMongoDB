using AspNet.Identity.MongoDB;
using LMSWithMongoDB.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LMSWithMongoDB.App_Start
{
    public class ApplicationIdentityContext : IDisposable
    {
        public static ApplicationIdentityContext Create()
        {
            string con = ConfigurationManager.AppSettings.Get("connectionString");
            // todo add settings where appropriate to switch server & database in your own application
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase(ConfigurationManager.AppSettings.Get("Database").ToString());
            var users = database.GetCollection<ApplicationUser>("AspNetUsers");
            var roles = database.GetCollection<IdentityRole>("AspNetRoles");
            return new ApplicationIdentityContext(users, roles);
        }

        private ApplicationIdentityContext(IMongoCollection<ApplicationUser> users, IMongoCollection<IdentityRole> roles)
        {
            Users = users;
            Roles = roles;
        }

        public IMongoCollection<IdentityRole> Roles { get; set; }

        public IMongoCollection<ApplicationUser> Users { get; set; }

        public Task<List<IdentityRole>> AllRolesAsync()
        {
            return Roles.Find(r => true).ToListAsync();
        }

        public void Dispose()
        {
        }
    }
}