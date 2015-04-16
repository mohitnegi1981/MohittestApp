using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Serialization;
using System.IO;

namespace WebApplication1
{
    public partial class ParsingXMLUsingXSD : System.Web.UI.Page
    {
        public List<XmlSchema> Schemas { get; set; }
        public List<String> Errors { get; set; }
        public List<String> Warnings { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                /*XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add("unqualified", @"D:\validateXMLUsingXSD\demo.xsd");
                settings.ValidationType = ValidationType.Schema;

                XmlReader reader = XmlReader.Create(@"D:\validateXMLUsingXSD\demo.xml", settings);
                XmlDocument document = new XmlDocument();
                document.Load(reader);

                ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);

                // the following call to Validate succeeds.
                document.Validate(eventHandler);*/


                //bool varxml = ValidateXml(@"D:\validateXMLUsingXSD\demo.xml", @"D:\validateXMLUsingXSD\demo.xsd");
                bool varxml = validateXMLusingXSD(@"D:\validateXMLUsingXSD\books.xml", @"D:\validateXMLUsingXSD\books.xsd");

                /*Outcome.Text = "<font color=\"green\">Succeeded</font>";
                Output.Text = ""; 

                
                XmlSchemaCollection xsc = new XmlSchemaCollection();
                xsc.Add("unqualified", @"D:\validateXMLUsingXSD\demo.xsd");
                Validate(@"D:\validateXMLUsingXSD\demo.xml", xsc); */

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }

        }

        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("Error: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("Warning {0}", e.Message);
                    break;
            }

        }

        private static bool _isValied = true;

        private void Validate(String filename, XmlSchemaCollection xsc)
        {
            XmlTextReader reader = null;
            XmlValidatingReader vreader = null;

            reader = new XmlTextReader(filename);
            vreader = new XmlValidatingReader(reader);
            vreader.Schemas.Add(xsc);
            vreader.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
            try
            {
                while (vreader.Read()) { }
            }
            catch
            {
                Output.Text = "XML Document is not well-formed.";
            }
            vreader.Close();
        }

        public void ValidationCallBack(object sender, ValidationEventArgs args)
        {
            Outcome.Text = "<font color=\"red\">Failed:</font>";
            Output.Text += "Validation error: <font color=\"red\">" + args.Message + "</font><br>";
        }
        public static bool ValidateXml(string xmlPath, string XsdPath)
        {
            try
            {
                XmlReader xsd = new XmlTextReader(XsdPath);
                XmlSchemaSet schema = new XmlSchemaSet();
                schema.Add(null, xsd);

                XmlReaderSettings xmlReadeSettings = new XmlReaderSettings();
                xmlReadeSettings.ValidationType = ValidationType.Schema;
                xmlReadeSettings.Schemas.Add(schema);
                xmlReadeSettings.ValidationEventHandler += new ValidationEventHandler(ValidationEventHandler);

                XmlTextReader xmlTextReader = new XmlTextReader(xmlPath);
                XmlReader xmlReader = XmlReader.Create(xmlTextReader, xmlReadeSettings);

                while (xmlReader.Read()) ;
                xmlReader.Close();
            }
            catch (Exception ex)
            {
                _isValied = false;
                // Write here exception massage to log               
            }
            return _isValied;
        }

        public bool validateXMLusingXSD(string XMLFILEPATH, string XSDFILEPATH)
        {
            bool isValid = true;
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(null, XSDFILEPATH);
                settings.ValidationType = ValidationType.Schema;
                XmlDocument document = new XmlDocument();
                document.Load(XMLFILEPATH);
                XmlReader rdr = XmlReader.Create(new StringReader(document.InnerXml), settings);
                while (rdr.Read()) { }
            }
            catch
            {
                isValid = false;
            }

            return isValid;
        }

    }
}