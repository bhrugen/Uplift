using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Uplift.DataAccess.Data.Repository.IRepository;
using Uplift.Models;

namespace Uplift.DataAccess.Data.Repository
{
    public class OrderDetailsRepository : Repository<OrderDetails> , IOrderDetailsRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderDetailsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        
    }
}
