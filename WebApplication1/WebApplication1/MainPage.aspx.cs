using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Data;
using System.Collections;

namespace WebApplication1
{
    public partial class MainPage : System.Web.UI.Page
    {
        List<Question> question = new List<Question>();
        private int question_type_id;
        private int quiz_id;
        private string title;
        private string subtitle;
        private string question_text;
        private decimal points;
        private string choice_numbering_mode;
        private int sequence;
        private string legacy_question_id;
        private string answer;
        private string agilix_question_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strFileName = @"C:/Users/mohit.negi/Desktop/QTI/CGQuizTwo/CGQuizTwo.xml";
            updateQTIData(strFileName);
        }


       public void updateQTIData(string fileName)
        {
            FileInfo fileinfo=new FileInfo(fileName);
            
            if(fileinfo.Extension.ToString().ToLower()==".xml")
            {
                TextReader tr = new StreamReader(fileName);
                string importXml = tr.ReadToEnd();
                tr.Close();
                tr = null;
                string strQuestype = string.Empty;
                //XElement xDoc = new XElement();
                XDocument xDoc = XDocument.Load(@"C:/Users/mohit.negi/Desktop/QTI/CGQuizTwo/CGQuizTwo.xml");
                /*DataSet ds = new DataSet();
                ds.ReadXml(@"C:/Users/mohit.negi/Desktop/QTI/CGQuizTwo/CGQuizTwo.xml");*/
                var itemList = new List<XElement>();
                List<XElement> element=xDoc.Elements("questestinterop").ToList<XElement>();
                itemList = new List<XElement>(xDoc.Elements("questestinterop").Elements("assessment").Elements("section").Elements("item"));
                //IEnumerable<XElement> root =from items xDoc.Elements("questestinterop").;


                //IList<XElement> items = (from item in xDoc.Elements("questestinterop").Elements("assessment").Elements("section").Elements("item")
                                                //select item).ToList<XElement>();

                string responce_lid_ident=string.Empty;
                ArrayList aryresponce_label_ident=new ArrayList();
                Dictionary<string, string> dictResponce = new Dictionary<string, string>();
                Dictionary<string, string> dictReprecessing = new Dictionary<string, string>();
                int counter = 0;
                foreach (XElement itemEL in itemList)
                {
                    //var mattext = itemEl.Elements("itemmetadata").Elements("qmd_itemtype");
                    title = itemEL.Attribute("title").Value;
                    var mattext= itemEL.Element("presentation").Element("material").Element("mattext");
                    question_text = mattext.Value;
                    points = 0;
                    var responce_lid = itemEL.Element("presentation").Element("response_lid");
                    responce_lid_ident = responce_lid.Attribute("ident").Value;
                    List<XElement> responce = new List<XElement>(itemEL.Elements("presentation").Elements("response_lid").Elements("render_choice").Elements("response_label"));
                    int i=0;
                    foreach(XElement res in responce)
                    {
                        var responce_lid_node = res.Attribute("ident");
                        responce_lid_ident = responce_lid_node.Value;
                        var responce_Label = res.Element("material").Element("mattext");
                        dictResponce.Add(responce_lid_ident, responce_Label.Value);
                    }
                    List<XElement> respcondition = new List<XElement>(itemEL.Elements("resprocessing").Elements("respcondition"));
                    foreach (XElement respoItem in respcondition)
                    {
                        var varequal = respoItem.Element("conditionvar").Element("varequal");
                        var setvar = respoItem.Element("setvar");
                        dictReprecessing.Add(varequal.Value, setvar.Value);
                    }
                }
            }
        }
    }
}