using Apexnet.Dispatch.Api.App_Start;
using WebActivatorEx;

[assembly: PostApplicationStartMethod(typeof(RazorGeneratorMvcStart), "Start")]

// ReSharper disable once CheckNamespace
namespace Apexnet.Dispatch.Api.App_Start
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.WebPages;
    using RazorGenerator.Mvc;

    public static class RazorGeneratorMvcStart
    {
        // ReSharper disable UnusedMember.Global
        public static void Start()
        {
            var engine = new PrecompiledMvcEngine(typeof(RazorGeneratorMvcStart).Assembly)
            {
                UsePhysicalViewsIfNewer = HttpContext.Current.Request.IsLocal
            };

            ViewEngines.Engines.Insert(0, engine);

            // StartPage lookups are done by WebPages. 
            VirtualPathFactoryManager.RegisterVirtualPathFactory(engine);
        }

        // ReSharper restore UnusedMember.Global
        ////
    }
}