
using OnlineExam.Context;
using OnlineExam.Domain.Commands.Command.Department;
using OnlineExam.Domain.Commands.Handler.Department;
using OnlineExam.Domain.Queries.Handler;
using OnlineExam.Domain.Queries.Handler.Exam;
using OnlineExam.Domain.Queries.Query;
using OnlineExam.Services;
using OnlineExam.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineExam.ViewModels.Admin.Department
{
    public class ShowDepartmentsViewModel : BaseViewModel
    {
        public BindingList<string> Errors { get; set; }
        public BindingList<Models.Department> Departments { get; set; }

        public ShowDepartmentsViewModel()
        {
            Errors = new BindingList<string>();
            Departments = new BindingList<Models.Department>();

            GetDepartments();
        }

        public void RemoveDepartment(Models.Department dep)
        {
            IsBusy = true;

            var command = new DeleteDepartmentCommand(dep.DepartmentId);
            var handler = new DeleteDepartmentCommandHandler(command);
            var result = handler.Execute();

            if (result.Success)
            {
                Departments.Remove(dep);
                if (Departments.Count == 0)
                {
                    Errors.Add("No department found! Create one.");
                }
            }

            MessageBox.Show(result.Message);

            IsBusy = false;
        }

        private void GetDepartments()
        {
            IsBusy = true;

            var hanlder = new AllDepartmentsQueryHandler();
            var departments = hanlder.Get();

            if (departments.Count() != 0)
            {
                foreach(var department in departments)
                {
                    Departments.Add(department);
                }
            }
            else
            {
                Errors.Add("No department found! Create one.");
            }

            IsBusy = false;
        }
    }
}
