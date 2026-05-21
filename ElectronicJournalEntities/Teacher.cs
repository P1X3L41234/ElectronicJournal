using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournalEntities
{
    public class Teacher
    {
        private String firstName = null;
        private String lastName = null;
        private String school = null;
        private String subject = null;
        private String phone = null;
        private String email = null;
        private String password = null;
        private DateTime? registrationDate = null;

        public Guid? ID { get; set; }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value == null)
                    firstName = "";
                else
                    if (value.Length > 30)
                        firstName = value.Substring(0, 30);
                    else
                        firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (value == null)
                    lastName = "";
                else
                    if (value.Length > 30)
                        lastName = value.Substring(0, 30);
                    else
                        lastName = value;
            }
        }

        public string School
        {
            get
            {
                return school;
            }
            set
            {
                school = value;
            }
        }

        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                if (value == null)
                    phone = "";
                else
                    if (value.Length > 30)
                        phone = value.Substring(0, 30);
                    else
                        phone = value;
            }
        }

        public string EMail
        {
            get
            {
                return email;
            }
            set
            {
                if (value == null)
                    email = "";
                else
                    if (value.Length > 30)
                        email = value.Substring(0, 30);
                    else
                        email = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (value == null)
                    password = "";
                else
                    if (value.Length > 30)
                        password = value.Substring(0, 30);
                    else
                        password = value;
            }
        }

        public DateTime? RegistrationDate
        {
            get
            {
                return registrationDate;
            }
            set
            {
                if (value < DateTime.Now)
                    registrationDate = DateTime.Now;
                else
                    registrationDate = value;
            }
        }

        public Teacher()
        {
            ID = Guid.NewGuid();
            RegistrationDate = DateTime.Now;
        }

        public Teacher(Guid? id, string firstName, string lastName, String school, String subject, string phone, string eMail, string password, DateTime? registrationDate)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            School = school;
            Subject = subject;
            Phone = phone;
            EMail = eMail;
            Password = password;

            if (RegistrationDate != null)
                RegistrationDate = registrationDate;
            else
                RegistrationDate = DateTime.Now;
        }
    }
}
