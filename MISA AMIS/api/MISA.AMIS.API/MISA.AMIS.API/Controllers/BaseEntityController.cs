using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MISA.AMIS.API.Controllers
{
    public class BaseEntityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
