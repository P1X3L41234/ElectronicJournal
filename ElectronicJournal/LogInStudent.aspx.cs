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
    public partial class LogInStudent : System.Web.UI.Page
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
            if (!this.IsPostBack)
                currentStudent = new ElectronicJournalEntities.Student();
            else
                currentStudent = new ElectronicJournalEntities.Student(null, null, null, null, null, null, EMailTextBox.Text, PasswordTextBox.Text, DateTime.Now);
        }

        protected void Page_CompleteLoad(object sender, EventArgs e)
        {
            populateUI();
        }

        private void populateUI()
        {
            EMailTextBox.Text = currentStudent.EMail;
            PasswordTextBox.Text = currentStudent.Password;
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            currentStudent = null;
        }

        protected void StudentLogInButton_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            UserExists(currentStudent.EMail, currentStudent.Password, "Students.xml");
        }

        private void UserExists(string eMail, string password, string fileName)
        {
            XElement users = XElement.Load(Server.MapPath(fileName));

            XElement user = users.Elements()
                .FirstOrDefault(u => (string)u.Attribute("EMail").Value == eMail && (string)u.Attribute("Password").Value == password);

            if (user != null)
            {
                Session["user"] = user.Attribute("ID").Value;
                Response.Redirect("~/StudentDefault.aspx");
            }
        }

        protected void StudentCancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}