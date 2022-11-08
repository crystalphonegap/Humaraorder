using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using ClosedXML.Excel;
using System.Net.Configuration;
using System.Net.Mail;
using System.Net;

namespace HAMARAORDER
{
    public partial class ViewOrderList : System.Web.UI.Page
    {
        private SqlCommand cmd;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strDBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Section1.Visible = true;
                Section2.Visible = false;
                Section3.Visible = false;
                lstAll.Attributes.Add("class", "active");
                lstPending.Attributes.Add("class", "");
                lstcomplete.Attributes.Add("class", "");
                try
                {
                    if (Session["Id"] != null && Session["Id"].ToString() != "")
                    {

                        if (Session["UserType"].ToString() == "Admin")
                        {
                            lstColor.Visible = true;
                            lstFavList.Visible = true;
                            lstHColor.Visible = true;
                            lstHFavList.Visible = true;
                            LstMColor.Visible = true;
                            LstMFavList.Visible = true;
                            lstRefrel.Visible = true;
                            lstHRefrel.Visible = true;
                            lstMRefrel.Visible = true;



                        }
                        else
                        {
                            lstColor.Visible = false;
                            lstFavList.Visible = false;
                            lstHColor.Visible = false;
                            lstHFavList.Visible = false;
                            LstMColor.Visible = false;
                            LstMFavList.Visible = false;
                            lstPending.Visible = false;
                            lstRefrel.Visible = false;
                            lstHRefrel.Visible = false;
                            lstMRefrel.Visible = false;
                        }
                        if (Session["UserType"].ToString() == "Logistic")
                        {
                            lstPending.Visible = true;
                        }
                        loginDatetime.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        lblLoginUserName.Text = Session["UserName"].ToString();
                        txtfromDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        txtTodate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        BindGridview();
                    }
                    else
                    {
                        // Response.Redirect("Login.aspx");
                    }

                }
                catch (Exception ex)
                {
                    //Response.Redirect("Login.aspx");
                }

            }
        }

        protected void BindGridview()
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_ORDER_GETLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_USERID", Session["UserCode"].ToString());
                cmd.Parameters.AddWithValue("@P_HEDAREID", 0);
                cmd.Parameters.AddWithValue("@P_ACTION", "H");
                cmd.Parameters.AddWithValue("@P_FromDate", Convert.ToDateTime(txtfromDate.Text));
                cmd.Parameters.AddWithValue("@P_TOdate", Convert.ToDateTime(txtTodate.Text));
                cmd.Parameters.AddWithValue("@P_Status", "");
                cmd.Parameters.AddWithValue("@P_USERTYPE", Session["UserType"].ToString());
                cmd.Parameters.AddWithValue("@P_ORG", Session["ORG"].ToString());
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    grdAHeader.DataSource = ds.Tables[0];
                    grdAHeader.DataBind();
                }
                else
                {

                    grdAHeader.DataSource = null;
                    grdAHeader.DataBind();
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    btnSubmit.Visible = true;
                    grdHPending.DataSource = ds.Tables[1];
                    grdHPending.DataBind();
                }
                else
                {
                    btnSubmit.Visible = false;
                    grdHPending.DataSource = null;
                    grdHPending.DataBind();
                }
                if (ds.Tables[2].Rows.Count > 0)
                {

                    grdHComplete.DataSource = ds.Tables[2];
                    grdHComplete.DataBind();
                }
                else
                {

                    grdHComplete.DataSource = null;
                    grdHComplete.DataBind();
                }


            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }

        }

        protected void gvHeader_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gv = (GridView)e.Row.FindControl("grdADetails");
                string HeaderId = (e.Row.FindControl("lblid") as Label).Text;
                cmd = new SqlCommand("PRC_ORDER_GETLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_USERID", 19);
                cmd.Parameters.AddWithValue("@P_HEDAREID", HeaderId);
                cmd.Parameters.AddWithValue("@P_ACTION", "D");
                cmd.Parameters.AddWithValue("@P_Status", "");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gv.DataSource = ds;
                gv.DataBind();
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {

                cmd = new SqlCommand("PRC_EXPORT_ORDERDATA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_FromDate", Convert.ToDateTime(txtfromDate.Text));
                cmd.Parameters.AddWithValue("@P_Todate", Convert.ToDateTime(txtTodate.Text));
                cmd.Parameters.AddWithValue("@P_ID", Session["Id"].ToString());
                cmd.Parameters.AddWithValue("@P_Action", "H");

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {


                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dt, "OrderDetails");
                        Response.Clear();
                        Response.Buffer = true;
                        Response.Charset = "";
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment;filename=" + DateTime.Now.Date.ToString("dd/MM/yyyy") + "Order.xlsx");
                        using (MemoryStream MyMemoryStream = new MemoryStream())
                        {
                            wb.SaveAs(MyMemoryStream);
                            MyMemoryStream.WriteTo(Response.OutputStream);
                            Response.Flush();
                            Response.End();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }


        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGridview();
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string lblAddedBy = "", OrderHeaderId = "";
            try
            {
                con.Open();
                SqlTransaction sqltrans = con.BeginTransaction();



                foreach (GridViewRow row in grdHPending.Rows)
                {
                    CheckBox chk = (row.FindControl("CheckBox1") as CheckBox);
                    Label lblid = (row.FindControl("lblid") as Label);
                    OrderHeaderId = lblid.Text;
                    lblAddedBy = (row.FindControl("lblAddedBy") as Label).Text;

                    if (chk.Checked == true)
                    {
                        cmd = new SqlCommand("PRC_LOGISTIC_APPROVE", con, sqltrans);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@P_ID", lblid.Text);
                        cmd.Parameters.AddWithValue("@P_STATUS", "Y");
                        cmd.Parameters.AddWithValue("@P_REMARK", "Approve");
                        cmd.ExecuteNonQuery();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Approve Done successfully...!');window.location ='ViewOrderList.aspx';", true);
                    }
                    else
                    {

                    }
                }
                sqltrans.Commit();
                sendmail(lblAddedBy, OrderHeaderId);
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }
        }

        protected void grdHPending_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gv = (GridView)e.Row.FindControl("grdDPending");
                string HeaderId = (e.Row.FindControl("lblid") as Label).Text;
                cmd = new SqlCommand("PRC_ORDER_GETLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_USERID", 19);
                cmd.Parameters.AddWithValue("@P_HEDAREID", HeaderId);
                cmd.Parameters.AddWithValue("@P_ACTION", "D");
                cmd.Parameters.AddWithValue("@P_Status", "");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gv.DataSource = ds;
                gv.DataBind();
            }
        }

        protected void grdHComplete_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gv = (GridView)e.Row.FindControl("grdDComplete");
                string HeaderId = (e.Row.FindControl("lblid") as Label).Text;
                cmd = new SqlCommand("PRC_ORDER_GETLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_USERID", 19);
                cmd.Parameters.AddWithValue("@P_HEDAREID", HeaderId);
                cmd.Parameters.AddWithValue("@P_ACTION", "D");
                cmd.Parameters.AddWithValue("@P_Status", "");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gv.DataSource = ds;
                gv.DataBind();
            }
        }

        protected void btnsection1_Click(object sender, EventArgs e)
        {
            Section1.Visible = true;
            Section2.Visible = false;
            Section3.Visible = false;
            lstAll.Attributes.Add("class", "active");
            lstPending.Attributes.Add("class", "");
            lstcomplete.Attributes.Add("class", "");
        }

        protected void bntSection2_Click(object sender, EventArgs e)
        {
            Section1.Visible = false;
            Section2.Visible = true;
            Section3.Visible = false;
            lstAll.Attributes.Add("class", "");
            lstPending.Attributes.Add("class", "active");
            lstcomplete.Attributes.Add("class", "");
        }
        protected void btnsection3_Click(object sender, EventArgs e)
        {
            Section1.Visible = false;
            Section2.Visible = false;
            Section3.Visible = true;

            lstAll.Attributes.Add("class", "");
            lstPending.Attributes.Add("class", "");
            lstcomplete.Attributes.Add("class", "active");
        }

        protected void sendmail(string USERCODE, string OrderHeaderId)
        {

            cmd = new SqlCommand("PRC_EMAIL_GETUSERWISE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_USERCODE", USERCODE);
            cmd.Parameters.AddWithValue("@P_PAGE", "Order");
            cmd.Parameters.AddWithValue("@P_OrderId", OrderHeaderId);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
                    using (MailMessage mm = new MailMessage(smtpSection.From, dt.Rows[0]["EmailTo"].ToString()))
                    {
                        string emailbody = dt.Rows[0]["EmailBody"].ToString();
                        mm.Subject = dt.Rows[0]["EmailSubject"].ToString();
                        mm.Body = emailbody;
                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = smtpSection.Network.Host;
                        smtp.EnableSsl = smtpSection.Network.EnableSsl;
                        NetworkCredential networkCred = new NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password);
                        smtp.UseDefaultCredentials = smtpSection.Network.DefaultCredentials;
                        smtp.Credentials = networkCred;
                        smtp.Port = smtpSection.Network.Port;
                        smtp.Send(mm);

                    }

                }
                catch (Exception ex)
                {

                }

            }


        }

        
        public void GetAttachment(Int64 fileId)
        {
            byte[] bytes;
            string fileName, contentType;
            string constr = ConfigurationManager.ConnectionStrings["strDBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "PRC_ORDER_BYID";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", fileId);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["Documents"];
                        contentType = sdr["ContentType"].ToString();
                        fileName = sdr["Filename"].ToString();
                    }
                    con.Close();
                }
            }

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }

        protected void grdAHeader_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkDownload")
            {
                int EditID = Convert.ToInt32(e.CommandArgument);
                GetAttachment(EditID);
            }
        }

        protected void grdHComplete_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkDownload")
            {
                int EditID = Convert.ToInt32(e.CommandArgument);
                GetAttachment(EditID);
            }
        }

        protected void grdHPending_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkDownload")
            {
                int EditID = Convert.ToInt32(e.CommandArgument);
                GetAttachment(EditID);
            }
        }
    }
}