using ElectronicJournalEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ElectronicJournal
{
    public partial class TeacherStudents : System.Web.UI.Page
    {
        static private IEnumerable<XElement> teacherStudents = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                XElement students = loadStudents("Students.xml");
                teacherStudents = filterStudents(students);

                string tempFileName = $"TempStudents_{Guid.NewGuid()}.xml";
                string tempFilePath = Server.MapPath($"~/{tempFileName}");

                File.WriteAllText(tempFilePath, buildXmlString(teacherStudents));

                StudentsXmlDataSource.EnableCaching = false;
                StudentsXmlDataSource.DataFile = $"~/{tempFileName}";

                StudentsXmlDataSource.DataBind();
                StudentsGridView.DataBind();

                Task.Run(() => File.Delete(tempFilePath));
            }
        }

        private XElement loadStudents(string fileName)
        {
            return XElement.Load(Server.MapPath(fileName));
        }

        private IEnumerable<XElement> filterStudents(XElement students)
        {
            String school = Session["school"]?.ToString();
            return
                from s in students.Elements()
                where s.Attribute("School").Value == school.ToString()
                select s;
        }

        private string buildXmlString(IEnumerable<XElement> teacherStudents)
        {
            return "<Students>" + string.Join("", teacherStudents.Select(x => x.ToString()).ToArray()) + "</Students>";
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in StudentsGridView.Rows)
            {
                DropDownList ddl = (DropDownList)row.FindControl("MarkDropDownList");

                string mark = ddl.SelectedValue;

                if (mark != "")
                {
                    string firstName = row.Cells[0].Text;

                    string lastName = row.Cells[1].Text;

                    string subject = Session["subject"]?.ToString();

                    string id = null;

                    XElement students = XElement.Load(Server.MapPath("Students.xml"));
                    XElement student = students.Elements()
                        .FirstOrDefault(s => (string)s.Attribute("FirstName").Value == firstName && (string)s.Attribute("LastName").Value == lastName);

                    if (student != null)
                        id = student.Attribute("ID").Value;

                    AddToMarksXml(id, firstName, lastName, subject, mark, "Marks.xml");
                }
            }
        }

        private void AddToMarksXml(string id, string firstName, string lastName, string subject, string mark, string fileName)
        {
            XElement marks;

            if (File.Exists(Server.MapPath(fileName)))
            {
                marks = XElement.Load(Server.MapPath(fileName));
            }
            else
            {
                marks = new XElement("Marks");
            }

            marks.Add(new XElement("Mark",
                new XAttribute("StudentID", id),
                new XAttribute("FirstName", firstName),
                new XAttribute("LastName", lastName),
                new XAttribute("Subject", subject),
                new XAttribute("Mark", mark),
                new XAttribute("Date", DateTime.Now)
            ));

            marks.Save(Server.MapPath(fileName));
        }
    }
}