﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using WebApp.DTO;
using WebApp.Service;

namespace WebApp.Controllers
{
    [Authorize]
    public class StorePointsController : BaseController
    {
        private StorePointsService StorePointsService { get; set; }
        private StorePointsHistoryService StorePointsHistoryService { get; set; }
        public StorePointsController(WebAppContext context):base(context)
        {
            StorePointsService = new StorePointsService(context);
            StorePointsHistoryService = new StorePointsHistoryService(context);
        }

        [Route("/punts")]
        public IActionResult Index()
        {
            User user = GetUser();
            List<StorePointsDto> points = StorePointsService.GetStorePoints(user);
            List<StorePointsHistoryDto> history = StorePointsHistoryService.GetStorePointsHistory(user);

            PointsDto dto = new PointsDto { StorePoints = points , StorePointsHistory = history};

            return View(dto);
        }

        [Route("/addpoints")]
        public IActionResult AddPoints(int postId, int userId) {
            // this user should be the admin of the store
            User user = GetUser();
            
            Post post = Context.Post.Include(o => o.Store).FirstOrDefault(o => o.Id == postId);

            // chack if the store is owned by the user who call the endpoint
            if (post.Store.User != user)
            {
                return RedirectToAction("Index");
            }


            //User to add the points
            User clientUser = Context.User.FirstOrDefault(o => o.Id == userId);

            StorePoints storePoints = StorePointsService.CreateStorePoints(clientUser, post.Store, post);
            StorePointsHistoryService.SaveStorePointsHistory(storePoints, post);

            return RedirectToAction("Index");
        }
    }
}
