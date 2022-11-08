using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using ClosedXML.Excel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Web;
using GemBox.Spreadsheet;
using System.ComponentModel;
using System.Drawing;
using System.Net;



namespace WindowsIntegration
{
    public partial class Form1 : Form
    {
        //Microsoft.Office.Interop.Excel.Application excel;
        //Microsoft.Office.Interop.Excel.Workbook excelworkBook;
        //Microsoft.Office.Interop.Excel.Worksheet excelSheet;
        //Microsoft.Office.Interop.Excel.Range excelCellrange;
    
        private SqlCommand cmd;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strDBConnection"].ConnectionString);
        public Form1()
        {
            InitializeComponent();
        }
   
        private void Form1_Load(object sender, EventArgs e)
        {

            var xmlString = File.ReadAllText("XMLFILE/Out_AutoAndPushWSSPO.xml");
            var stringReader = new StringReader(xmlString);
            var dsSet = new DataSet();
            dsSet.ReadXml(stringReader);
            if (checkBox1.Checked == true)
            {
                btnExportExcel_Click();
            }
            else
            {

            }

        }

        private void btnExportExcel_Click()
        {
            con.Open();
            try
            {
                //Creating DataTable
                cmd = new SqlCommand("PRC_SAP_FILE_GENERATION", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_Id", 0);
                cmd.Parameters.AddWithValue("@P_Action", "I");
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                sda.Fill(dt);

                //Exporting to Excel
                string folderPath = "D:\\Excel\\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                IWorkbook workbook;

                workbook = new HSSFWorkbook();
                //generatexml(0, dt);
                //Export(dt);
               
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "SAPFile"); //"+ DateTime.Now+ "

                    //wb.SaveAs(folderPath, XlFileFormat.);


                    wb.SaveAs(folderPath + "In_AutoAndPushWSSUnity" + DateTime.Now.ToString("dd/mm/yyyy") + ".xls"); //DateTime.Now.ToString("dd/MM/yyyy") + "-" +



                }


            }
            catch (SqlException)
            {

            }
            finally
            {
                con.Close();
            }
           // UpdateIntegartion();
        }

        private void UpdateIntegartion()
        {
            con.Open();
            try
            {
                //Creating DataTable
                cmd = new SqlCommand("PRC_SAP_FILE_GENERATION", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_Id", 0);
                cmd.Parameters.AddWithValue("@P_Action", "U");
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                sda.Fill(dt);


            }
            catch (SqlException)
            {

            }
            finally
            {
                con.Close();
            }

        }

        protected void Export(DataTable dt)
        {
            // If you are using the Professional version, enter your serial key below.
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            var workbook = new ExcelFile();
            var worksheet = workbook.Worksheets.Add("In_AutoAndPushWSS");

            // Insert DataTable to an Excel worksheet.
            worksheet.InsertDataTable(dt,
                new InsertDataTableOptions()
                {
                    ColumnHeaders = true,
                    StartRow = 0
                });
            //string folderPath = "~/XMLFILE/";
            //if (!Directory.Exists(folderPath))
            //{
            //    Directory.CreateDirectory(folderPath);
            //}
            workbook.Save("In_AutoAndPushWSS" + DateTime.Now.ToString("yyyy-MM-dd") + ".xls");
            workbook.Save("~/XMLFILE/", "In_AutoAndPushWSS" + DateTime.Now.ToString("yyyy-MM-dd")+".xls");
            //+DateTime.Now.ToString("HH:mm:ss") + 
            //workbook.sav

        }


        protected void generatexml(int countt, DataTable dt)
        {
            string str = ConfigurationManager.AppSettings["Filepath"].ToString();
            string text = ConfigurationManager.AppSettings["FileName"].ToString();
            string text2 = DateTime.Now.ToString().Trim();
            string text3 = string.Concat(new object[]
            {
        text,
        DateTime.Now.ToString("MMddyyyyHHmmss"),
        "_",
        countt,
        ".xls"
            });
            string text4 = AppDomain.CurrentDomain.BaseDirectory + str + "/" + text3;
            try
            {
                XLWorkbook xLWorkbook = new XLWorkbook();
                xLWorkbook.Worksheets.Add(dt);
                string text5 = ConfigurationManager.AppSettings["TartgetDir"];
                FileStream stream = new FileStream(text4, FileMode.Create, FileAccess.Write);
                string userName = ConfigurationManager.AppSettings["ftpusername"];
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    xLWorkbook.SaveAs(memoryStream);
                    byte[] array = memoryStream.ToArray();
                    memoryStream.WriteTo(stream);
                    memoryStream.Close();
                }
                string str2 = ConfigurationManager.AppSettings["ftppath"].ToString();
                string str3 = ConfigurationManager.AppSettings["ftpFolder"].ToString();
                string password = ConfigurationManager.AppSettings["ftpFolderpassword"].ToString();
                string destFileName = str2 + str3 + text3;
                //using (new Impersonator(userName, "pil_edp", password))
                //{
                //    File.Copy(text4, destFileName);
                //}
            }
            catch (Exception ex)
            {
                //Form1.cmd = new SqlCommand();
                //bool flag = this.con.State == ConnectionState.Closed;
                //if (flag)
                //{
                //    this.con.Open();
                //}
                //Form1.cmd.Connection = this.con;
                //Form1.cmd.CommandType = CommandType.StoredProcedure;
                //Form1.cmd.CommandText = "[inserterror]";
                //Form1.cmd.Parameters.AddWithValue("@error", ex.Message.ToString());
                //Form1.da = new SqlDataAdapter(Form1.cmd);
                //Form1.dt = new DataTable();
                //Form1.da.Fill(Form1.dt);
            }
        }
    }
}
