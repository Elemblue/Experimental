using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Plain CLR object. 
//Not MVVM specific

namespace Ex1.Models
{
    //INotifyPropertyChanged - This is how WPF does its data binding. It subscribes to the events of INotifyPropertyChanged to know when to change.
    class Customer : INotifyPropertyChanged, ICustomer
    {

        //This is the longhand way to make a getter setter.
        private String _Name;
        /// <summary>
        /// Stores name of customer
        /// </summary>
        public String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }

        public Customer(String customerName)
        {
            Name = customerName;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;   //Event Handler Variable

        /// <summary>
        /// Takes the name of a gettersetter local variable and creates an event that fires when that variable changes.
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;          //The handler is equal to the predefined global handler.

            if (handler != null)
            {                                          //If the propertyChanged object points to an object of itself
                handler(this, new PropertyChangedEventArgs(propertyName));  //Create a an argument for property name on this object.
            }

        }

        #endregion
    }
}
