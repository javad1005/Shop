using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.HelloWorld.Components
{
    [ViewComponent(Name = "HelloWorld")]
    public class HelloWorldViewComponents : NopViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Plugins/Nop.Plugin.HelloWorld/Views/Configure.cshtml");
        }
    }
}
