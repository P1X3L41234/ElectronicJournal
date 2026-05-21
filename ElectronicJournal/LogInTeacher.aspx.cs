using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ElectronicJournal
{
    public partial class LogInTeacher : System.Web.UI.Page
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
            if (!this.IsPostBack)
                currentTeacher = new ElectronicJournalEntities.Teacher();
            else
                currentTeacher = new ElectronicJournalEntities.Teacher(null, null, null, null, null, null, EMailTextBox.Text, PasswordTextBox.Text, DateTime.Now);
        }

        protected void Page_CompleteLoad(object sender, EventArgs e)
        {
            populateUI();
        }

        private void populateUI()
        {
            EMailTextBox.Text = currentTeacher.EMail;
            PasswordTextBox.Text = currentTeacher.Password;
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            currentTeacher = null;
        }

        protected void TeacherLogInButton_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            UserExists(currentTeacher.EMail, currentTeacher.Password, "Teachers.xml");
        }

        private void UserExists(string eMail, string password, string fileName)
        {
            XElement users = XElement.Load(Server.MapPath(fileName));

            XElement user = users.Elements()
                .FirstOrDefault(u => (string)u.Attribute("EMail").Value == eMail && (string)u.Attribute("Password").Value == password);

            if (user != null)
            {
                Session["school"] = user.Attribute("School").Value;
                Session["subject"] = user.Attribute("Subject").Value;
                Response.Redirect("~/TeacherDefault.aspx");
            }
        }

        protected void TeacherCancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}