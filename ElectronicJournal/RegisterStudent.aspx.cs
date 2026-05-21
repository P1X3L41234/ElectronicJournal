using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ElectronicJournal
{
    public partial class RegisterStudent : System.Web.UI.Page
    {
        private ElectronicJournalEntities.Student currentStudent = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
            }
            InstantiateStudentObject();
        }

        private void InstantiateStudentObject()
        {
            string school = SchoolDropDownList.SelectedValue;
            if (school.Equals("Choose School"))
            {
                school = "1";
            }

            string class_ = ClassDropDownList.SelectedValue;
            if (class_.Equals("Choose Class"))
            {
                class_ = "1";
            }

            if (!this.IsPostBack)
                currentStudent = new ElectronicJournalEntities.Student();
            else
                currentStudent = new ElectronicJournalEntities.Student(null, FirstNameTextBox.Text, LastNameTextBox.Text, school, class_, PhoneTextBox.Text, EMailTextBox.Text, PasswordTextBox.Text, DateTime.Now);
        }

        protected void Page_CompleteLoad(object sender, EventArgs e)
        {
            populateUI();
        }

        private void populateUI()
        {
            FirstNameTextBox.Text = currentStudent.FirstName;
            LastNameTextBox.Text = currentStudent.LastName;

            if (currentStudent.School == null)
                SchoolDropDownList.SelectedValue = currentStudent.School;
            else
                SchoolDropDownList.SelectedIndex = -1;

            if (currentStudent.Class == null)
                ClassDropDownList.SelectedValue = currentStudent.Class;
            else
                ClassDropDownList.SelectedIndex = -1;

            PhoneTextBox.Text = currentStudent.Phone;
            EMailTextBox.Text = currentStudent.EMail;
            PasswordTextBox.Text = currentStudent.Password;
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            currentStudent = null;
        }

        protected void StudentRegisterButton_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            AddToStudentsXml(currentStudent, "Students.xml");
        }

        private void AddToStudentsXml(ElectronicJournalEntities.Student student, string fileName)
        {
            XElement students;

            if (File.Exists(Server.MapPath(fileName)))
            {
                students = XElement.Load(Server.MapPath(fileName));
            }
            else
            {
                students = new XElement("Students");
            }

            students.Add(new XElement("Student",
                new XAttribute("ID", Guid.NewGuid()),
                new XAttribute("FirstName", student.FirstName),
                new XAttribute("LastName", student.LastName),
                new XAttribute("School", student.School),
                new XAttribute("Class", student.Class),
                new XAttribute("Phone", student.Phone),
                new XAttribute("EMail", student.EMail),
                new XAttribute("Password", student.Password),
                new XAttribute("RegistrationDate", student.RegistrationDate)
            ));

            students.Save(Server.MapPath(fileName));

            Response.Redirect("~/Default.aspx");
        }

        protected void StudentCancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}