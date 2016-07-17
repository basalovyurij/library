using AutoMapper;
using Library.DB;
using Library.Domain;
using Library.Domain.Mapping;
using Library.Web.Code;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Validation.Providers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Library.Web
{
    public class MvcApplication : NinjectHttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
            ); 
            
            routes.MapRoute(
                "Default", // Имя маршрута
                "{controller}/{action}/{id}", // URL-адрес с параметрами
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Параметры по умолчанию
            );

        }

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css")
                .Include(
                    "~/Content/bootstrap.min.css",
                    "~/Content/select.min.css",
                    "~/Content/select2.min.css",
                    "~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/js")
                .Include(
                    "~/Scripts/angular.min.js",
                    "~/Scripts/angular-route.min.js",
                    "~/Scripts/angular-resource.min.js",
                    "~/Scripts/angular-sanitize.min.js",
                    "~/Scripts/select.min.js",
                    "~/Scripts/angular-base64-upload.min.js",
                    "~/Scripts/angular-isbn.js")
                .IncludeDirectory("~/Scripts/App/services/", "*.js")
                .IncludeDirectory("~/Scripts/App/", "*.js")
                .IncludeDirectory("~/Scripts/App/controllers/", "*.js"));

            bundles.Add(new AngularTemplateBundle("~/bundles/template")
                .IncludeDirectory("~/Templates/", "*.html"));
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            kernel.Load(new DbNinjectModule(), new DomainNinjectModule());

            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
            
            return kernel;
        }

        public static void RegisterAutoMapper()
        {
            // Get an instance of each Profile in the executing assembly.
            var profiles = Assembly.GetAssembly(typeof(AuthorMapProfile)).GetTypes()
                .Where(t => typeof(Profile).IsAssignableFrom(t) && t.GetConstructor(Type.EmptyTypes) != null)
                .Select(Activator.CreateInstance)
                .Cast<Profile>();

            // Initialize AutoMapper with each instance of the profiles found.
            Mapper.Initialize(a => profiles.ToList().ForEach(a.AddProfile));

            Mapper.AssertConfigurationIsValid();
        }

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            RegisterAutoMapper();
            RegisterBundles(BundleTable.Bundles);
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}