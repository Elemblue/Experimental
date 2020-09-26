using Ex1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ex1.Commands
{
    internal class CustomerUpdateCommand : ICommand
    {

        public CustomerViewModel viewModel { get; set; }

        /// <summary>
        /// Initializes a new instance of the CustomerUpdateCommand class
        /// </summary>
        /// <param name="viewModel"></param>
        public CustomerUpdateCommand(CustomerViewModel viewModel) {
            this.viewModel = viewModel;
        }

        #region ICommand Members

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter){
            return viewModel.CanUpdate;
        }

        public void Execute(object parameter){
            throw new NotImplementedException();
        }

        #endregion
    }
}
