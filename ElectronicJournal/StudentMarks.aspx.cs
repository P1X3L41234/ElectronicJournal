using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ElectronicJournal
{
    public partial class StudentMarks : System.Web.UI.Page
    {
        static private IEnumerable<XElement> studentMarks = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                XElement marks = loadMarks("Marks.xml");
                studentMarks = filterMarks(marks);

                string tempFileName = $"TempMarks_{Guid.NewGuid()}.xml";
                string tempFilePath = Server.MapPath($"~/{tempFileName}");

                File.WriteAllText(tempFilePath, buildXmlString(studentMarks));

                MarksXmlDataSource.EnableCaching = false;
                MarksXmlDataSource.DataFile = $"~/{tempFileName}";

                MarksXmlDataSource.DataBind();
                MarksGridView.DataBind();

                Task.Run(() => File.Delete(tempFilePath));
            }
        }

        private XElement loadMarks(string fileName)
        {
            return XElement.Load(Server.MapPath(fileName));
        }

        private IEnumerable<XElement> filterMarks(XElement marks)
        {
            String studentID = Session["user"]?.ToString();
            return
                from m in marks.Elements()
                where m.Attribute("StudentID").Value == studentID.ToString()
                select m;
        }

        private string buildXmlString(IEnumerable<XElement> studentMarks)
        {
            return "<Marks>" + string.Join("", studentMarks.Select(x => x.ToString())) + "</Marks>";
        }
    }
}