// Commented cause I prefer to call it explicitly in the Global.Asax
//[assembly: WebActivator.PostApplicationStartMethod(typeof(AspNetMvcWebView.SimpleInjectorInitializer), "Initialize")]

namespace AspNetMvcWebView
{
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            // Get the path where assembly is getting compiled 
            //string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = new System.Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            var directory = System.IO.Path.GetDirectoryName(path);

            // Get All the assemblies in that path
            var assemblies =
                 from file in new DirectoryInfo(directory).GetFiles()
                 where file.Extension.ToLower() == ".dll"
                 select Assembly.Load(AssemblyName.GetAssemblyName(file.FullName));

            // call the RegisterServices method that was implemented on each assembly, (look for a class named DependencyInjectionPackage() in the other assemblies)
            container.RegisterPackages(assemblies);
        }
    }
}