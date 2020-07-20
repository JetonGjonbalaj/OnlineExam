using OnlineExam.Domain.Commands.Command.Student;
using OnlineExam.Domain.Commands.Handler.Student;
using OnlineExam.Domain.Queries.Handler;
using OnlineExam.Domain.Queries.Handler.Student;
using OnlineExam.Domain.Queries.Query.Student;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineExam.ViewModels.Admin.Student
{
    public class SaveStudentViewModel : BaseViewModel
    {
        private Models.Student _student;
        public Models.Student Student
        {
            get { return _student; }
            set { SetProperty(ref _student, value); }
        }

        public BindingList<Models.Department> Departments { get; set; }
        public BindingList<string> Errors { get; set; }

        public SaveStudentViewModel()
        {
            _student = new Models.Student();

            Departments = new BindingList<Models.Department>();
            Errors = new BindingList<string>();

            GetDepartments();
        }

        public SaveStudentViewModel(Models.Student student)
        {
            Departments = new BindingList<Models.Department>();
            Errors = new BindingList<string>();

            var query = new OneStudentQuery(student.UserId);
            var handler = new OneStudentQueryHandle(query);
            var result = handler.Get();

            if (result != null)
            {
                _student = result;
            }
            else
            {
                Errors.Add("There is no student!");
            }

            GetDepartments();
        }

        public void SaveStudent()
        {
            IsBusy = true;
            Errors.Clear();

            var command = new SaveStudentCommand(_student);
            var handler = new SaveStudentCommandHandler(command);
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

        public void GetDepartments()
        {
            IsBusy = true;

            var hanlder = new AllDepartmentsQueryHandler();
            var departments = hanlder.Get();

            if (departments.Count() != 0)
            {
                foreach (var department in departments)
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
