using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WebApplication1
{
    public partial class WebForm7 : System.Web.UI.Page
    {

        string conn = ConfigurationManager.ConnectionStrings["MyDbConn1"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlConnection sqlconn = new SqlConnection(conn);
            string str = "<Sites tier=\"QA\"><Site company=\"macmillanhighered\" path=\"/launchpad/harryNewinsertTestChange124\" courseId=\"11119\" courseType=\"Launchpad - Vertical\" siteid=\"0\"/></Sites>";

            DataSet rowsAffected;
            sqlconn.Open();
            SqlCommand sqlCMD = new SqlCommand("px_UpdateAgilixCourseIDs", sqlconn);
            //SqlCommand sqlCMD = new SqlCommand("bsi_GetItem", sqlconn);
            sqlCMD.CommandType = CommandType.StoredProcedure;
            sqlCMD.Parameters.Add(new SqlParameter("@siteCourseIdsXml", str));
            //sqlCMD.Parameters.Add(new SqlParameter("@item_id", "6724817"));
            //int rowsAffected = sqlCMD.ExecuteNonQuery();
            SqlDataAdapter sqldb = new SqlDataAdapter(sqlCMD);
            sqldb.Fill(ds);
            //DataSet rowsAffected =(DataSet)sqlCMD.ExecuteScalar();
            sqlconn.Close();

            //hdnAry.Value = "Astronomy 2100||Introduction to Astronomy**Physics!!Biochemisty 2104||Introduction to Biochemistry**Advanced Biochemistry!!Biology 2102||Non-Majors Biology**Intermediate Biology**Genetics**Cell Biology / Molecular Biology**Biochemistry**Ecology**Environmental Science**Immunology**Microbiology**Botany**Comparative Animal Physiology**Ornithology**Biological Statistics**Scientific Teaching Series**Writing in the Biological Sciences**Lab Notebooks!!Chemistry 2106||Gen** Org** Bioc/Chem for Nursing and Allied**Preparatory Chemistry**Liberal Arts Chemistry**General Chemistry**Biochemistry**Organic Chemistry**Environmental Chemistry**Physical Chemistry**Analytical Chemistry**Inorganic Chemistry**Lab Notebooks!!College Success 2090||The College Experience**Critical Thinking**Diversity**Emotional Intelligence**Exams and Tests**Learning Styles**Libraries and research**Majors and careers**Money management**Note-Taking**Participating in class**Purpose for attending college**Reading**Relationships**Study skills**ime management**Wellness**Writing in Class!!Communication 2082||Film Studies**Journalism**Mass Communication**Speech Communication**Professional Resources!!Economics 2098||Business and Economics Statistics**Principles of Macroeconomics**Principles of Microeconomics**Principles of Economics**Survey of Economics**Intermediate Macroeconomics**Intermediate Microeconomics**International Economics**Money and Banking**Public Finance**Game Theory**Intermediate Economics!!Geography 2110||Human Geography**World Regional Geography**Introduction to Geographic Information Systems**Physical Geography!!Geology 2108||Introduction to Physical Geology**Environmental Geology**Historical Geology**Natural Disasters / Hazards**Environmental Science**Oceanography**Sedimentary Geology / Stratigraphy**Petrology**Principles of Paleontology**Structural Geology / Tectonics**Climate Change / Paleoclimatology!!History 2086||U.S. History**European History**World History**The Bedford Series in History and Culture**Writing Guides / Methodology**Profession Resources**1890-1920**1920-1950**1950-1980**1980-present!!Mathematics 2112||Euclidean / Non-euclidean Geometries**Partial Differential Equations**Liberal Arts Mathematics**Mathematics for Teachers**Calculus**Linear Algebra**Complex Analysis / Complex Variables**Real Analysis / Classical Analysis**Discrete Mathematics**Number Theory!!Music 2092||Drama**Music Appreciation**Interactive Listening Charts**Instruments of the Orchestra**Performance!!Physics 2114||Introduction to Astronomy**Physics !!Psychology 2094||Introductory Psychology**Developmental Psychology**Abnormal Psychology**Social and Personality Psychology**Statistics and Research Methods**Biological Psychology and Neuroscience**Cognition** Learning** and Memory**Sensation and Perception**Industrial and Organizational Psychology**Forensic Psychology and Psychology and Law**Health Psychology!!Sociology 2116||Contemporary Social Issues Series**Criminology**Deviance**Global Issues**Introduction to Sociology**Political Sociology**Racial and Ethnicity**Research Methods**Social Problems**Sociological Theory**Sociology of Gender**Sociology of Health and Medicine**Sociology of Religion**Technology**Urban Sociology!!Statistics 2096||Introductory Statistics**Second Course in Statistics**Statistical Literacy / Liberal Arts Statistics**Statistics for Life Sciences**Business Statistics**Mathematical Statistics**Probability and Statistics";

        }
               
    }
}