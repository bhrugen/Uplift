using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uplift.DataAccess.Data.Repository;
using Uplift.Extensions;
using Uplift.Models;
using Uplift.Models.ViewModels;
using Uplift.Utility;

namespace Uplift.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        [BindProperty]
        public CartViewModel CartVM { get; set; }

        public CartController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            CartVM = new CartViewModel()
            {
                OrderHeader = new Models.OrderHeader(),
                ServiceList = new List<Service>()
            };
        }

        public IActionResult Index()
        {
            if(HttpContext.Session.GetObject<List<int>>(SD.SessionCart)!=null)
            {
                List<int> sessionList = new List<int>();
                sessionList = HttpContext.Session.GetObject<List<int>>(SD.SessionCart);
                foreach(int serviceId in sessionList)
                {
                    CartVM.ServiceList.Add(_unitOfWork.Service.GetFirstOrDefault(u => u.Id == serviceId, includeProperties: "Frequency,Category"));
                }
            }
                return View(CartVM);
        }
    }
}