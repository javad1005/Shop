using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Controllers;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Framework;

namespace Nop.Plugin.RasteBazar.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class RasteBazarPublicController : BasePublicController
    {
        #region Methods

        public async Task<IActionResult> DashBord()
        {
            return View("~/Plugins/RasteBazar/Views/Pages/Dashbord.cshtml");
        }

        #endregion
    }
}
