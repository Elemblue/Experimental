using System.ComponentModel;

namespace Ex1.Models
{
    interface ICustomer
    {
        string Name { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}