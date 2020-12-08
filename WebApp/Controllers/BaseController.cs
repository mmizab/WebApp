using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Data;

namespace WebApp.Controllers
{
    public class BaseController : Controller
    {
        private readonly WebAppContext _context;
        public BaseController(WebAppContext webappcontext)
        {
            this._context = webappcontext;
        }

        public Object Save(Object o)
        {
            _context.Add(o);
            _context.SaveChanges();
            _logger.LogInformation(o.ToString());
            return o;
        }

    }
}