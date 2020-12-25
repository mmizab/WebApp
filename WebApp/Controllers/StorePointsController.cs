using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class StorePointsController : BaseController
    {
        public StorePointsController(WebAppContext context):base(context)
        {

        }
        [Route("/punts")]
        public IActionResult Index()
        {
            User user = GetUser();
            List<StorePoints> points = Context.StorePoints.Where(o => o.User == user).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddPoints(int points, int storeId, int userId) {
            // this user should be the admin of the store
            User user = GetUser();
            
            //User to add the points
            User clientUser = Context.User.FirstOrDefault(o => o.Id == userId);

            Store store = Context.Store.FirstOrDefault(o => o.Id == storeId);
            if (store.User != user)
            {
                throw new Exception("User trying to add points is not the admin of the store");
            }

            // load points or create new register and add the points
            StorePoints storePoints = Context.StorePoints.FirstOrDefault(o => o.User == clientUser);
            if (storePoints == null)
            {
                storePoints = new StorePoints() { User = clientUser, CreateTime = DateTime.Now, Store = store};
            }

            storePoints.Points += points;
            storePoints.UpdateTime = DateTime.Now;

            Context.Add(storePoints);
            Context.SaveChanges();

            // should implement store points history and redirect the store owner there.
            return RedirectToAction("Index");
        }
    }
}
