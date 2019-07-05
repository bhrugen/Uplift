using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Uplift.DataAccess.Data.Repository.IRepository;
using Uplift.Models;

namespace Uplift.DataAccess.Data.Repository
{
    public class UserRepository : Repository<ApplicationUser> , IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void LockUser(string userId)
        {
            var userFromDb = _db.ApplicationUser.FirstOrDefault(u => u.Id == userId);
            userFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            _db.SaveChanges();
        }

        public void UnLockUser(string userId)
        {
            var userFromDb = _db.ApplicationUser.FirstOrDefault(u => u.Id == userId);
            userFromDb.LockoutEnd = DateTime.Now;
            _db.SaveChanges();
        }
    }
}
