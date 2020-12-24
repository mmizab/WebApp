using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.DTO;
using WebApp.Models;
using WebApp.Service;

namespace WebApp.Controllers
{
    public class BaseController : Controller
    {
        public readonly WebAppContext Context;
        public BaseController(WebAppContext context)
        {
            Context = context;
        }
        public User GetUser()
        {
            string username = User.Claims.FirstOrDefault(o => o.Type == "Name").Value;
            if (username == null)
            {
                throw new Exception("Error getting user information");
            }
            User user = Context.User.FirstOrDefault(o => o.Email == username);
            if (user == null)
            {
                throw new Exception("Error getting user from database");
            }
            return user;
        }

        public static Byte[] BitmapToBytesCode(Bitmap image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}