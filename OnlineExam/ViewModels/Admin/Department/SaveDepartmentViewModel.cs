using OnlineExam.Domain.Commands.Command.Department;
using OnlineExam.Domain.Commands.Handler.Department;
using OnlineExam.Domain.Queries.Handler;
using OnlineExam.Domain.Queries.Query;
using OnlineExam.Utils;
using OnlineExam.Views.Admin.Department;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace OnlineExam.ViewModels.Admin.Department
{
    public class SaveDepartmentViewModel : BaseViewModel
    {
        public ICommand Command { get; set; }

        private Models.Department _department;
        public Models.Department Department
        {
            get { return _department; }
            set { SetProperty(ref _department, value); }
        }
        public BindingList<string> Errors { get; set; }

        public SaveDepartmentViewModel()
        {
            _department = new Models.Department();

            Errors = new BindingList<string>();
            Command = new Command(SaveDepartment);
        }

        public SaveDepartmentViewModel(Models.Department department)
        {
            Errors = new BindingList<string>();
            Command = new Command(SaveDepartment);

            var query = new OneDepartmentQuery(department.DepartmentId);
            var handler = new OneDepartmentQueryHandler(query);
            var result = handler.Get();

            if (result != null)
            {
                _department = result;
            } else
            {
                Errors.Add("There is no department!");
            }
        }

        private void SaveDepartment()
        {
            IsBusy = true;
            Errors.Clear();

            var command = new SaveDepartmentCommand(_department);
            var handler = new SaveDepartmentCommandHandler(command);
            var result = handler.Execute();

            if (result.Success)
            {
                MessageBox.Show(result.Message);
            }
            else
            {
                Errors.Add(result.Message);
            }

            IsBusy = false;
        }
    }
}
