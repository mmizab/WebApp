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
    public class StorePointsHistoryService
    {
        private WebAppContext Context { get; set; }
        private StorePointsHistoryMapper StorePointsHistoryMapper = new StorePointsHistoryMapper();
        public StorePointsHistoryService(WebAppContext context)
        {
            Context = context;
        }
        public List<StorePointsHistoryDto> GetStorePointsHistory(User user) {
            List<Store> stores = Context.Store.Where(o => o.User == user).ToList();
            List<StorePointsHistory> history = new List<StorePointsHistory>();
            List<StorePointsHistoryDto> dtos = new List<StorePointsHistoryDto>();

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

            foreach (var item in history)
            {
                StorePointsHistoryMapper.StorePointsHistoryToDto(item);
            }
            return dtos;
        }

        public void SaveStorePointsHistory(StorePoints storePoints, Post post) {
            StorePointsHistory history = new StorePointsHistory { StorePoints = storePoints, Points = post.Points, Operation = "afegits", CreateTime = DateTime.Now };
            Context.Add(history);
            Context.SaveChanges();
        }
    }
}
