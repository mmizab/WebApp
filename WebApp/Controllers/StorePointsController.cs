using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using WebApp.DTO;

namespace WebApp.Controllers
{
    [Authorize]
    public class StorePointsController : BaseController
    {
        public StorePointsController(WebAppContext context):base(context)
        {

        }
        [Route("/punts")]
        public IActionResult Index()
        {
            User user = GetUser();
            List<StorePoints> points = Context.StorePoints.Include(o => o.Store).Include(o => o.User).Where(o => o.User == user).ToList();
            List<Store> stores = Context.Store.Where(o => o.User == user).ToList();
            List<StorePointsHistory> history = new List<StorePointsHistory>();

            foreach (var item in stores)
            {
                history.AddRange(Context.StorePointsHistory.Include(o => o.StorePoints.Store).Include(o => o.StorePoints.User).Where(o => o.StorePoints.Store == item).ToList());
            }

            List<StorePointsHistory> userHistory = Context.StorePointsHistory.Include(o => o.StorePoints.Store).Include(o => o.StorePoints.User).Where(o => o.StorePoints.User == user).ToList();
            foreach (var item in userHistory)
            {
                // check for duplicas
                var found = history.FirstOrDefault(o => o.Id == item.Id);
                if (found == null)
                {
                    history.Add(item);
                }
            }

            StorePointsDto dto = new StorePointsDto { StorePoints = points , StorePointsHistory = history};

            return View(dto);
        }

        [Route("/addpoints")]
        public IActionResult AddPoints(int postId, int storeId, int userId) {
            // this user should be the admin of the store
            User user = GetUser();
            
            //User to add the points
            User clientUser = Context.User.FirstOrDefault(o => o.Id == userId);

            Store store = Context.Store.FirstOrDefault(o => o.Id == storeId);
            if (store.User != user)
            {
                return RedirectToAction("Index");
            }

            Post post = Context.Post.FirstOrDefault(o => o.Id == postId);

            // load points or create new register and add the points
            StorePoints storePoints = Context.StorePoints.FirstOrDefault(o => o.User == clientUser);
            if (storePoints == null)
            {
                storePoints = new StorePoints() { User = clientUser, CreateTime = DateTime.Now, Store = store};
            }

            storePoints.Points += post.Points;
            storePoints.UpdateTime = DateTime.Now;

            if (storePoints.Id == 0)
            {
                Context.Add(storePoints);
                Context.SaveChanges();

            }
            else
            {
                Context.Update(storePoints);
                Context.SaveChanges();
            }

            // should implement store points history and redirect the store owner there.
            StorePointsHistory history = new StorePointsHistory { StorePoints = storePoints, Points = post.Points, Operation = "add", CreateTime = DateTime.Now };
            Context.Add(history);
            Context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
