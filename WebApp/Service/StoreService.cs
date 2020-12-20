using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Controllers;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Service
{
    public class StoreService:BaseController
    {
        private WebAppContext Context { get; set; }
        public StoreService(WebAppContext context) : base(context)
        {
            Context = context;
        }

        public Store GetStore(int storeId)
        {
            User user = GetUser();
            Store store = null;
            // check if the store is owned by the user
            if (user.Role == "admin")
            {
                store = _context.Store.FirstOrDefault(o => o.Id == storeId);
            }
            else
            {
                store = _context.Store.FirstOrDefault(o => o.Id == storeId && o.User.Id == user.Id);
            }
            if (store == null)
            {
                throw new Exception("Error getting store, is not registered or the user is not the owner");
            }
            return store;
        }

        public List<Store> GetStores()
        {

            User user = GetUser();

            List<Store> stores = null;
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
            return stores;
        }
    }
}
