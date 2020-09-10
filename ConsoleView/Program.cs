using Business;
using Model;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    class Program
    {
        static Container container;

        static void Main(string[] args)
        {
            RegisterDependencies();

            DoSomeTest();
        }



        private static void RegisterDependencies()
        {
            // Get the path where the assembly is getting executed
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directory = System.IO.Path.GetDirectoryName(path);

            // Get All the assemblies in that path
            var assemblies =
                 from file in new DirectoryInfo(directory).GetFiles()
                 where file.Extension.ToLower() == ".dll"
                 select Assembly.Load(AssemblyName.GetAssemblyName(file.FullName));

            container = new Container();

            /// This project is an EXE, not an Assembly, so the "plugin" concept does not apply to this artifact.
            /// Instead, we just register our dependencies localy
            container.Register<BlogAdministrationScreen>();

            // call the RegisterServices method that was implemented on each assembly, (look for a class named DependencyInjectionPackage() in the other assemblies)
            container.RegisterPackages(assemblies);

            container.Verify();
        }

        private static void DoSomeTest()
        {
            // Just creating some stuff to see the program working

            BlogAdministrationScreen screen = container.GetInstance<BlogAdministrationScreen>();

            string blogname = "My Awesome Blog";

            var blog = screen.CreateABlog(blogname, "Ewerton");
            var post = screen.AddPostToBlog(blog, "My New Post", "This is a post testing my new blog");
            var comment = screen.AddCommentToPost(post, "Hey, what a awesome blog, man!");


            var savedBlogs = screen.GetBlogsByName(blogname);

            foreach (var blogItem in savedBlogs)
            {
                Console.WriteLine("You just created the following blog:");
                Console.WriteLine($"    Blog Name: {blog.Name} | Blog Owner: {blog.Owner}");

                foreach (var postItem in blogItem.Posts)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Here are the Posts:");
                    Console.WriteLine($"    Post Title: {postItem.Title} | Post Body: {postItem.Body}");

                    foreach (var commentItem in postItem.Comments)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Here are the Comments:");
                        Console.WriteLine($"    Comment Text: {commentItem.CommentText } | Crete Date: {commentItem.Date.ToShortTimeString()}");
                    }
                }
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

    }
}
