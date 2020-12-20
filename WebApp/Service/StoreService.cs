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
    public class StoreService
    {
        private WebAppContext Context;
        private StoreMapper StoreMapper { get; set; } = new StoreMapper();
        public StoreService(WebAppContext context){
            Context = context;
        }

        public Store GetStore(int storeId, User user)
        {
            Store store = null;
            
            if (user.Role == "admin")
            {
                store = Context.Store.FirstOrDefault(o => o.Id == storeId);
            }
            else
            {
                // check if the store is owned by the user
                store = Context.Store.FirstOrDefault(o => o.Id == storeId && o.User.Id == user.Id);
            }
            if (store == null)
            {
                throw new Exception("Error getting store, is not registered or the user is not the owner");
            }
            return store;
        }

        public List<StoreDto> GetStoresDto(User user)
        {
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
