using Ex1.Commands;
using Ex1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ex1;
using Autofac;

namespace Ex1.ViewModels
{
    internal class CustomerViewModel
    {
        //Shorthand getter setter. Creates instance of Customer class.
        public Customer Customer { get; }
        // This is a data binding comming from the view going to the model
        public ICommand UpdateCommand { get; private set; }
        //Gets or sets a System.Boolean value indicating wheather the Customer can be updated.
        public bool CanUpdate {
            get {
                if (Customer == null) {
                    return false;
                }
                return !String.IsNullOrWhiteSpace(Customer.Name);
            }
        }

        /// <summary>
        /// Initializes a new instance of the CustomerViewModel class
        /// </summary>
        public CustomerViewModel() {

            //Dependancy injection example. This is incorrect, just a quick ex.
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<ICustomer>();   //This is a manual call. If you do this alot, your app is inefficient. Should only be at the start. 
            }
        }

        Customer = new Customer("David");
            UpdateCommand = new CustomerUpdateCommand(this); //Passes in itself for the customerUpdateCommand class to deal with.
        }

        /// <summary>
        /// Saves changes made to customer instance.
        /// </summary>
        public void SaveChanges()
        {
            Debug.Assert(false,String.Format("{0} was updated"), Customer.Name);    //Debug Info Pass.

        }
    }
}
