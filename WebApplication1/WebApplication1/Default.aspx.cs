using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Mail;


namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*CheckBoxList1.Items.Add(new ListItem("Mohit","1"));
            CheckBoxList1.Items.Add(new ListItem("Navdeep", "2"));
            CheckBoxList1.Items.Add(new ListItem("Priyanka", "3"));
            hdnVal.Value = "Mohit:1,Navdeep:2,Priyanka:3";*/
            
            //sendmail();
            
        }

        public void sendmail()
        {
            MailMessage mail = new MailMessage();
            mail.To = "mohit.negi@pearson.com";
            mail.From = "rightscapture.helpdesk@pearson.com";
            mail.Subject = "Welcome Mohit Singh  to Rights Capture";
            //mail.Body = "<p>Pedido de Registro </p><p>O seu pedido de acesso para o Rights Capture foi gerado.</p><p>Sua senha temporária é: <strong> 4350 </strong></p><p>Para acessar o Rights Capture, por favor vá ao <b> <a href='http://rightscapture.pearson.com'>rightscapture.pearson.com</a>.</p><p>Note que você deverá alterar a sua senha quando logar pela primeira vez.</p><p>Se você não se registrou no Rights Capture, entre em  contato com o  Helpdesk do Rights Capture  no <a href='mailto:rightscapture.helpdesk@pearson.com'>rightscapture.helpdesk@pearson.com</a>.</p><p>Obrigada.</p> ";
            mail.Body = "<p>Registration Request </p><p>Your access request to Rights Capture has been granted.</p><p>Your temporary password is: <strong> 4350 </strong></p><p>To access Rights Capture, please go to <b><a href='http://rightscapture.pearson.com'>rightscapture.pearson.com</a>.</p><p>Please note, you will be prompted to change your password when logging in for the first time.</p><p>If you did not register for Rights Capture, please contact the Rights Capture Helpdesk at <a href='mailto:rightscapture.helpdesk@pearson.com'>rightscapture.helpdesk@pearson.com</a>.</p><p>Thank You.</p> ";
            mail.BodyFormat = MailFormat.Html;
            SmtpMail.SmtpServer = "mail77.di.pearsontc.net";
            SmtpMail.Send(mail);
        }
    }
}
