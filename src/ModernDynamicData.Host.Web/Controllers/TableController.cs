using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ModernDynamicData.Host.Web.Controllers
{
    public class TableController : Controller
    {
        /// <summary>
        /// Get all contexts
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get all tables by context
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public IActionResult GetAllTables(string context)
        {
            return View();
        }
    }
}
