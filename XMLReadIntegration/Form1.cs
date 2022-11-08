using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using System.Net;
using System.Xml.Linq;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using ClosedXML.Excel;

namespace XMLReadIntegration
{
    public partial class Form1 : Form
    {
        public string Filepath = ConfigurationManager.AppSettings["FilePath"].ToString();
        public string FtpFilePath = ConfigurationManager.AppSettings["FtpFilePath"].ToString();
        public string FtpFileMovePath = ConfigurationManager.AppSettings["FtpFileMovePath"].ToString();
        public string FtpUserId = ConfigurationManager.AppSettings["FtpUserId"].ToString();
        public string FtpPwd = ConfigurationManager.AppSettings["FtpPwd"].ToString();
        static SqlCommand cmd;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Order"].ConnectionString);
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Ordersms"].ConnectionString);
        static string DocNo;
        static string WssCode;
        static string ItemCode;
        static string Result;
        static string Remark;
        static string OrderValue;
        SqlDataAdapter da;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
            FtpWebRequest reqFTP;
            try
            {
                string[] filenames = GetFileList();
                lstFiles.Items.Clear();
                foreach (string filename in filenames)
                {
                    if (filename.Contains(".xml") || filename.Contains(".XML"))
                    {
                        lstFiles.Items.Add(filename);
                    }

                }

                for (int i = 0; i < lstFiles.Items.Count; i++)
                {
                    string fileName = lstFiles.Items[i].ToString().Trim();

                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + FtpFilePath + "" + fileName));
                    reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                    reqFTP.UseBinary = true;
                    reqFTP.Credentials = new NetworkCredential(FtpUserId, FtpPwd);
                    FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                    Stream ftpStream = response.GetResponseStream();
                    long cl = response.ContentLength;
                    int bufferSize = 2048;
                    int readCount;
                    byte[] buffer = new byte[bufferSize];
                    FileStream outputStream = new FileStream(Filepath + "\\" + fileName, FileMode.Create);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                    while (readCount > 0)
                    {
                        outputStream.Write(buffer, 0, readCount);
                        readCount = ftpStream.Read(buffer, 0, bufferSize);
                    }

                    ftpStream.Close();
                    outputStream.Close();
                    response.Close();
                }

                //for (int i = 0; i < lstFiles.Items.Count; i++)
                //{
                //    string fileName = lstFiles.Items[i].ToString().Trim();
                //    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + FtpFilePath + "" + fileName));

                //    reqFTP.Credentials = new NetworkCredential(FtpUserId, FtpPwd);
                //    reqFTP.Method = WebRequestMethods.Ftp.Rename;
                //    reqFTP.UseBinary = true;
                //    reqFTP.RenameTo = FtpFileMovePath + fileName;
                //    FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();

                //    Stream ftpStream = response.GetResponseStream();
                //    response.Close();
                //    reqFTP = null;

                //}
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }


        public string[] GetFileList()
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + FtpFilePath));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(FtpUserId, FtpPwd);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                //MessageBox.Show(reader.ReadToEnd());
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (line.Contains("Out_AutoAndPushWSSPO"))
                    {
                        //if (line.Contains("Out_AutoAndPushWSSPOResult20180516-142818-446"))
                        //{
                        result.Append(line);
                        result.Append("\n");

                    }
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
                //MessageBox.Show(response.StatusDescription);
                return result.ToString().Split('\n');

            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                downloadFiles = null;
                return downloadFiles;
            }
        }


        public void ReadXMLFileUpdate()
        {
            try
            {
                con.Open();
                for (int cnt = 0; cnt < lstFiles.Items.Count; cnt++)
                {
                    string xmlfile = Filepath + "\\" + lstFiles.Items[cnt].ToString().Trim();

                    DataSet ds = new DataSet();
                    ds.ReadXml(xmlfile);
                    for (int i = 0; i < ds.Tables["Data"].Rows.Count; i++)
                    {
                        try
                        {
                            cmd = new SqlCommand("PRC_XML_RESPONSE_UPDATE", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@P_SAPNUMBER", ds.Tables["Data"].Rows[i]["Quotation_No"].ToString());
                            cmd.Parameters.AddWithValue("@P_SAPSATUS", ds.Tables["Data"].Rows[i]["Flag"].ToString());
                            cmd.Parameters.AddWithValue("@P_ORDERNUMBER", ds.Tables["Data"].Rows[i]["PO_No"].ToString());
                            cmd.Parameters.AddWithValue("@P_MaterialCode", ds.Tables["Data"].Rows[i]["Mat_Code"].ToString());
                            cmd.Parameters.AddWithValue("@P_FLAG", ds.Tables["Data"].Rows[i]["Flag"].ToString());
                            cmd.Parameters.AddWithValue("@P_REMARK", ds.Tables["Data"].Rows[i]["Remark"].ToString());
                            cmd.Parameters.AddWithValue("@P_ORD_VAL", ds.Tables["Data"].Rows[i]["ORD_VAL"].ToString());
                            cmd.Parameters.AddWithValue("@P_SP_RATE", ds.Tables["Data"].Rows[i]["SPRATE"].ToString());
                            cmd.Parameters.AddWithValue("@P_ACTION", "U");
                            cmd.ExecuteNonQuery();
                        }
                        catch (SqlException sqlex)
                        {
                            sqlex.ToString();
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.Message);
            }
        }

        public void ReadSendMail()
        {
            try
            {

                string EmailId;
                string MobileNo;
                for (int cnt = 0; cnt < lstFiles.Items.Count; cnt++)
                {
                    string xmlfile = Filepath + "\\" + lstFiles.Items[cnt].ToString().Trim();

                    //string xmlfile = "D:/Order_XML/Out_AutoAndPushPOResult20140417-120318-034 (2).xml";

                    DataSet ds = new DataSet();
                    ds.ReadXml(xmlfile);

                    cmd = new SqlCommand();
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "FetchMailID";
                    for (int i = 0; i < ds.Tables["Data"].Rows.Count; i++)
                    {
                        WssCode = ds.Tables["Data"].Rows[i]["Cust_Code"].ToString();
                        string docNo = ds.Tables["Data"].Rows[i]["PO_No"].ToString();
                        string sapdocNo = ds.Tables["Data"].Rows[i]["Quotation_No"].ToString();

                        if (sapdocNo == "" && docNo != "")
                        {
                            DataTable dt1 = new DataTable();
                            dt1 = GetEmail();
                            SendMailReject(dt1, docNo, sapdocNo);
                        }

                        cmd.Parameters.Clear();
                        //cmd.CommandText = "FetchMailID";

                        cmd.Parameters.Add("@wssCode", SqlDbType.VarChar, 50).Value = WssCode;
                        da = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            EmailId = dt.Rows[0]["Email"].ToString().Trim();
                            MobileNo = dt.Rows[0]["MobileNo"].ToString().Trim();

                            //if (EmailId != "" && EmailId != null)
                            //{
                            //if (WssCode == "0001018422")
                            //{
                            if (sapdocNo != "")
                            {
                                if (EmailId != "" && EmailId != null)
                                {
                                    SendMail(EmailId, WssCode, docNo, sapdocNo);
                                }
                            }


                            //}
                            //}
                            if (MobileNo != "" && MobileNo != null)
                            {
                                if (sapdocNo != "")
                                {
                                    SqlCommand cmd1 = new SqlCommand();
                                    cmd1.Connection = con1;
                                    cmd1.CommandType = CommandType.StoredProcedure;

                                    cmd1.Parameters.Clear();
                                    cmd1.CommandText = "sen_sms_order";
                                    cmd1.Parameters.Add("@mno", SqlDbType.VarChar, 50).Value = MobileNo;
                                    cmd1.Parameters.Add("@OrderNo", SqlDbType.VarChar, 50).Value = sapdocNo;
                                    cmd1.Parameters.Add("@PartyCode", SqlDbType.VarChar, 50).Value = WssCode;
                                    con1.Open();
                                    cmd1.ExecuteNonQuery();
                                    con1.Close();
                                }
                            }
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {

            }
        }

        public Boolean SendMail(string email, string SenderCode, string DocNo, string SapDocNo)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder message = new StringBuilder();
                string SMTPHost = System.Configuration.ConfigurationManager.AppSettings["SMTPHost"];
                string SMTPPort = System.Configuration.ConfigurationManager.AppSettings["SMTPPort"];
                string SenderAddress = System.Configuration.ConfigurationManager.AppSettings["ContactEmailId"];
                string username = System.Configuration.ConfigurationManager.AppSettings["user_id"];
                string password = System.Configuration.ConfigurationManager.AppSettings["Pass_word"];
                string subject = "";

                subject = "Order Confirmation";
                message.Append("Dear Sir/Madam,<br>");
                message.Append(" Your order No " + DocNo + " has been confirmed and its SAP Order No is " + SapDocNo + ".<br><br>");

                //message.Append("Password is: " + Password + "<br><br>");
                //message.Append("Kindly login with this password to access the EMCS2 System <br><br>");
                message.Append("    This is system generated mail, please do not reply on this mail<br><br>");
                message.Append("- Pidilite Inds. Ltd.<br>");


                if (SMTPHost.Length > 0)
                {
                    MailMessage msgMail = new MailMessage();
                    msgMail.From = new MailAddress(SenderAddress);

                    if (email != "")
                        msgMail.To.Add(new MailAddress(email, "WSS"));


                    msgMail.Subject = subject;
                    msgMail.IsBodyHtml = true;
                    msgMail.Body = Convert.ToString(message);

                    SmtpClient smtp = new SmtpClient(SMTPHost, Convert.ToInt16(SMTPPort));

                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    if (username != "" || password != "")
                    {
                        smtp.Credentials = new NetworkCredential(username, password);
                    }
                    //-------------------------------------------------------------------
                    smtp.Send(msgMail);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }

        }
        public Boolean SendMailReject(DataTable email, string DocNo, string SapDocNo)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder message = new StringBuilder();
                string SMTPHost = System.Configuration.ConfigurationManager.AppSettings["SMTPHost"];
                string SMTPPort = System.Configuration.ConfigurationManager.AppSettings["SMTPPort"];
                string SenderAddress = System.Configuration.ConfigurationManager.AppSettings["ContactEmailId"];
                string username = System.Configuration.ConfigurationManager.AppSettings["user_id"];
                string password = System.Configuration.ConfigurationManager.AppSettings["Pass_word"];
                string subject = "";

                subject = "Order Rejection Confirmation";
                message.Append("Dear Sir/Madam,<br>");
                message.Append(" Your order No " + DocNo + " has been Rejected by SAP.<br><br>");

                //message.Append("Password is: " + Password + "<br><br>");
                //message.Append("Kindly login with this password to access the EMCS2 System <br><br>");
                message.Append("    This is system generated mail, please do not reply on this mail<br><br>");
                message.Append("- Pidilite Inds. Ltd.<br>");

                if (SMTPHost.Length > 0)
                {
                    MailMessage msgMail = new MailMessage();
                    msgMail.From = new MailAddress(SenderAddress);

                    if (email.Rows.Count > 0)
                        msgMail.To.Add(new MailAddress(email.Rows[0]["EMAIL"].ToString()));

                    for (int i = 0; i < email.Rows.Count; i++)
                    {
                        msgMail.CC.Add(new MailAddress(email.Rows[i]["CC_EMAIL"].ToString()));
                    }

                    msgMail.Subject = subject;
                    msgMail.IsBodyHtml = true;
                    msgMail.Body = Convert.ToString(message);
                    SmtpClient smtp = new SmtpClient(SMTPHost, Convert.ToInt16(SMTPPort));
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    if (username != "" || password != "")
                    {
                        smtp.Credentials = new NetworkCredential(username, password);
                    }
                    smtp.Send(msgMail);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }

        }

        public DataTable GetEmail()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from dbo.CC_EMAIL_Order order by id", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            try
            {
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void ReadXMLFile_Load_1(object sender, EventArgs e)
        {
            ReadXMLFileUpdate();
            //ReadSendMail();
            Application.Exit();
        }

    }
}
