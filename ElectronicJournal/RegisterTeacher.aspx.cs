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
    public partial class RegisterTeacher : System.Web.UI.Page
    {
        private ElectronicJournalEntities.Teacher currentTeacher = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
            }
            InstantiateTeacherObject();
        }

        private void InstantiateTeacherObject()
        {
            string school = SchoolDropDownList.SelectedValue;
            if (school.Equals("Choose School"))
            {
                school = "1";
            }

            string subject = SubjectDropDownList.SelectedValue;
            if (subject.Equals("Choose Subject"))
            {
                subject = "Математика";
            }

            if (!this.IsPostBack)
                currentTeacher = new ElectronicJournalEntities.Teacher();
            else
                currentTeacher = new ElectronicJournalEntities.Teacher(null, FirstNameTextBox.Text, LastNameTextBox.Text, school, subject, PhoneTextBox.Text, EMailTextBox.Text, PasswordTextBox.Text, DateTime.Now);
        }

        protected void Page_CompleteLoad(object sender, EventArgs e)
        {
            populateUI();
        }

        private void populateUI()
        {
            FirstNameTextBox.Text = currentTeacher.FirstName;
            LastNameTextBox.Text = currentTeacher.LastName;

            if (currentTeacher.School == null)
                SchoolDropDownList.SelectedValue = currentTeacher.School;
            else
                SchoolDropDownList.SelectedIndex = -1;

            if (currentTeacher.Subject == null)
                SubjectDropDownList.SelectedValue = currentTeacher.Subject;
            else
                SubjectDropDownList.SelectedIndex = -1;

            PhoneTextBox.Text = currentTeacher.Phone;
            EMailTextBox.Text = currentTeacher.EMail;
            PasswordTextBox.Text = currentTeacher.Password;
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            currentTeacher = null;
        }

        protected void TeacherRegisterButton_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            AddToTeachersXml(currentTeacher, "Teachers.xml");
        }

        private void AddToTeachersXml(ElectronicJournalEntities.Teacher teacher, string fileName)
        {
            XElement teachers;

            if (File.Exists(Server.MapPath(fileName)))
            {
                teachers = XElement.Load(Server.MapPath(fileName));
            }
            else
            {
                teachers = new XElement("Teachers");
            }

            teachers.Add(new XElement("Teacher",
                new XAttribute("ID", Guid.NewGuid()),
                new XAttribute("FirstName", teacher.FirstName),
                new XAttribute("LastName", teacher.LastName),
                new XAttribute("School", teacher.School),
                new XAttribute("Subject", teacher.Subject),
                new XAttribute("Phone", teacher.Phone),
                new XAttribute("EMail", teacher.EMail),
                new XAttribute("Password", teacher.Password),
                new XAttribute("RegistrationDate", teacher.RegistrationDate)
            ));

            teachers.Save(Server.MapPath(fileName));

            Response.Redirect("~/Default.aspx");
        }

        protected void TeacherCancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}