using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Controllers;
using WebApp.Data;
using WebApp.DTO;
using WebApp.Mapper;
using WebApp.Models;

namespace WebApp.Service
{
    public class StoreService:BaseService
    {
        private StoreMapper StoreMapper { get; set; }
        public StoreService(WebAppContext context) : base(context)
        {
        }

        public Store GetStore(int storeId)
        {
            User user = GetUser();
            Store store = null;
            // check if the store is owned by the user
            if (user.Role == "admin")
            {
                store = base.Context.Store.FirstOrDefault(o => o.Id == storeId);
            }
            else
            {
                store = base.Context.Store.FirstOrDefault(o => o.Id == storeId && o.User.Id == user.Id);
            }
            if (store == null)
            {
                throw new Exception("Error getting store, is not registered or the user is not the owner");
            }
            return store;
        }

        public List<StoreDto> GetStoresDto()
        {

            User user = GetUser();

            List<Store> stores = null;
            List<StoreDto> storedto = new List<StoreDto>();
            if (user.Role == "admin")
            {
                stores = Context.Store.ToList();
            }
            else
            {
                stores = Context.Store.Where(o => o.User.Id == user.Id).ToList();
            }
            if (stores == null || stores.Count == 0)
            {
                throw new Exception("Error getting store information");
            }

            foreach (var item in stores)
            {
                storedto.Add(StoreMapper.StoreToDto(item));
            }
            return storedto;
        }
    }
}
