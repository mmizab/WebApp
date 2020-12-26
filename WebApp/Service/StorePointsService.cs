using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.DTO;
using WebApp.Mapper;
using WebApp.Models;

namespace WebApp.Service
{
    public class StorePointsService
    {
        WebAppContext Context { get; set; }
        StorePointsMapper StorePointsMapper = new StorePointsMapper();
        public StorePointsService(WebAppContext context)
        {
            Context = context;
        }

        public List<StorePointsDto> GetStorePoints(User user) {
            List<StorePoints> points = Context.StorePoints.Include(o => o.Store).Include(o => o.User).Where(o => o.User == user).ToList();
            List<StorePointsDto> dtos = new List<StorePointsDto>();
            foreach (var item in points)
            {
                dtos.Add(StorePointsMapper.StorePointsToDto(item));
            }
            return dtos;
        }
        public StorePoints CreateStorePoints(User clientUser, Store store, Post post) {
            // load store points or create new register and add the post points
            StorePoints storePoints = Context.StorePoints.FirstOrDefault(o => o.User == clientUser);
            if (storePoints == null)
            {
                storePoints = new StorePoints() { User = clientUser, CreateTime = DateTime.Now, Store = store };
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

            return storePoints;
        }
    }
}
