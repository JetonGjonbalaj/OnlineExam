using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineExam.Context;
using OnlineExam.Domain.Commands.Command.Professor;
using OnlineExam.Domain.Commands.Handler.Professor;
using OnlineExam.Domain.Queries.Handler.Professor;
using OnlineExam.Domain.Queries.Query.Professor;
using OnlineExam.Services;
using OnlineExam.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineExam.ViewModels.Admin.Professor
{
    public class ShowProfessorsViewModel : BaseViewModel
    {
        public BindingList<string> Errors { get; set; }
        public BindingList<Models.Professor> Professors { get; set; }

        public ShowProfessorsViewModel ()
        {
            Errors = new BindingList<string>();
            Professors = new BindingList<Models.Professor>();

            GetProfessors();
        }

        public void RemoveProfessor(Models.Professor professor)
        {
            IsBusy = true;

            var command = new DeleteProfessorCommand(professor.UserId);
            var handler = new DeleteProfessorCommandHandler(command);
            var result = handler.Execute();

            if (result.Success)
            {
                Professors.Remove(professor);
                if (Professors.Count == 0)
                {
                    Errors.Add("No department found! Create one.");
                }
            }

            MessageBox.Show(result.Message);

            IsBusy = false;
        }

        private void GetProfessors()
        {
            IsBusy = true;

            var hanlder = new AllProfessorsQueryHandler();
            var professors = hanlder.Get();

            if (professors.Count() != 0)
            {
                foreach (var professor in professors)
                {
                    Professors.Add(professor);
                }
            }
            else
            {
                Errors.Add("No professor found! Create one.");
            }

            IsBusy = false;
        }
    }
}
