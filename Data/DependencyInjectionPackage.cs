using SimpleInjector;
using SimpleInjector.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// This method will be called by reflection from de program main() to register the dependencies for the Business assembly
    /// </summary>
    public class DependencyInjectionPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<BlogRepo>();
            container.Register<PostRepo>();
            container.Register<CommentRepo>();
        }
    }
}
