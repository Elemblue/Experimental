using Autofac;
using Ex1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    public static class ContainerConfig
    {
        public static IContainer Configure() {
            var builder = new ContainerBuilder();

            //Tell builder to register difference peices. This is a manual example.
            //builder.RegisterType<Customer>().As<ICustomer>();   //Whenever you look for the interface ICustomer, you will get a new instance of class Customer.

            //Tell builder to register difference peices. This is an automatic example that registers everything in a folder. Its a custom built example.
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Ex1)))  //Useing nameof makes the object accessable from intelisense.
                .Where(t => t.Namespace.Contains(nameof(Models)))       //Where the namespace literally contains the term utilities in the class
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));    //Link it to its associated I Interface
                    

            return builder.Build(); //This returns the key value pair list of all of the difference classes we want to instantiate.
        }
    }
}
