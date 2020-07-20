using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Validation
{
    public static class ValidationProperties
    {
        #region Answer
        public static int AnswerTextLength = 511;
        #endregion
        
        #region Course
        public static int CourseNameLength = 100;
        #endregion

        #region Department
        public static int DepartmentNameLength = 100;
        #endregion

        #region Exam
        public static int ExamNameLength = 100;
        #endregion

        #region Professor
        public static int ProfessorIdLength = 10;
        #endregion

        #region Question
        public static int QuestionTextLength = 511;
        #endregion

        #region Student
        public static int StudentIdLength = 10;
        #endregion

        #region User
        public static int FirstNameLength = 30;
        public static int LastNameLength = 30;
        public static int EmailLength = 100;
        public static bool IsEmail(string email)
        {
            try
            {
                EmailAddressAttribute m = new EmailAddressAttribute();
                return m.IsValid(email);
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public static int PasswordLength = 100;
        #endregion

        public static bool AreLetters(string str)
        {
            str = str.Replace(" ", "");

            return str.All(Char.IsLetter);
        }
    }
}
