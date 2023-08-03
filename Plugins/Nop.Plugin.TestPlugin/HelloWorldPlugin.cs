using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Nop.Services.Plugins;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.TestPlugin
{
    public class HelloWorldPlugin : BasePlugin
    {
        //public Task ManageSiteMapAsync(SiteMapNode rootNode)
        //{
        //    var AlirezaPluginsNode = rootNode.ChildNodes.FirstOrDefault(x => x.SystemName == "HelloWorld");
        //    if (AlirezaPluginsNode == null)
        //    {
        //        AlirezaPluginsNode = new SiteMapNode()
        //        {
        //            SystemName = "HelloWorld",
        //            Title = "HelloWorld",
        //            Visible = true
        //        };
        //        rootNode.ChildNodes.Add(AlirezaPluginsNode);
        //    }

        //    var menueLikeProduct = new SiteMapNode()
        //    {
        //        SystemName = "HelloWorld",
        //        Title = "HelloWorld Configuration",
        //        ControllerName = "HelloWorld",
        //        ActionName = "Configure",
        //        Visible = true,
        //        RouteValues = new RouteValueDictionary() { { "Area", "Admin" } },
        //    };

        //    AlirezaPluginsNode.ChildNodes.Add(menueLikeProduct);
        //    return Task.CompletedTask;
        //}
        public override Task InstallAsync()
        {
            return base.InstallAsync();
        }

        public override Task UninstallAsync() 
        {
            return base.UninstallAsync();
        }
    }
}