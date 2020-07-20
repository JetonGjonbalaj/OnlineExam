using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineExam.Utils
{
    public class FallbackMessage : NotifiableClass
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        private Visibility _visibleState;
        public Visibility VisibleState
        {
            get { return _visibleState; }
            set { SetProperty(ref _visibleState, value); }
        }
    }
}
