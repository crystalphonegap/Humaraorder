using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace HAMARAORDER
{
    public partial class Checkout : System.Web.UI.Page
    {
        private SqlCommand cmd;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strDBConnection"].ConnectionString);
        byte[] byteArray;
        byte[] bytes;
        string fileName, contentType;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Session["Id"] != null || Session["Id"].ToString() != "")
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
                            lstRefrel.Visible = false;
                            lstHRefrel.Visible = false;
                            lstMRefrel.Visible = false;
                        }
                        txtDeliveryDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        loginDatetime.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        lblLoginUserName.Text = Session["UserName"].ToString();
                        txtUserName.Text = Session["UserName"].ToString();
                
                        BindCartRepeter();
                        BindCustomerDetails();
                        BindRefrel();
                        BindRefrelDivision();
                        BindShiptToparty();

                    }
                    else
                    {
                        Response.Redirect("Login.aspx");
                    }

                }
                catch (Exception ex)
                {
                    Response.Redirect("Login.aspx");
                }


            }
        }

        protected void BindCartRepeter()
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_CART_GETLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_CustomerCode", Session["CustomerCode"].ToString());
                cmd.Parameters.AddWithValue("@P_PlantCode", Session["CustomerPlant"].ToString());
                cmd.Parameters.AddWithValue("@P_AddedBy", Session["UserCode"].ToString());
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lblCount.Text = Convert.ToString(dt.Rows.Count);
                    rptCartProduct.DataSource = dt;
                    rptCartProduct.DataBind();
                }
                else
                {
                    lblCount.Text = "0";
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

        protected void BindUserDetails()
        {
            cmd = new SqlCommand("", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_UserId", Session["UserCode"].ToString());
        }


        protected void BindRefrel()
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_BIND_DROPDOWNLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_ACTION", "REFREL");
                cmd.Parameters.AddWithValue("@P_CUSTOMERCODE", "");
                cmd.Parameters.AddWithValue("@P_ORG_CODE", "");
                DropOrderRefrel.DataSource = cmd.ExecuteReader();
                DropOrderRefrel.DataTextField = "NAME";
                DropOrderRefrel.DataValueField = "Id";
                DropOrderRefrel.DataBind();

                DropOrderRefrel.Items.FindByText("Other").Selected = true;
                


            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }
        }
        protected void BindShiptToparty()
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_CUSTOMER_GETSHIPTOPARTY", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_ACTION", "All");
                cmd.Parameters.AddWithValue("@P_CUSTOMERCODE", Session["CustomerCode"].ToString());
                DropPartyList.DataSource = cmd.ExecuteReader();
                DropPartyList.DataTextField = "NAME";
                DropPartyList.DataValueField = "Id";
                DropPartyList.DataBind();
                //DropPartyList.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }
        }

        protected void BindRefrelDivision()
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_BIND_DROPDOWNLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_ACTION", "REFRELDIVISION");
                cmd.Parameters.AddWithValue("@P_CUSTOMERCODE", "");
                cmd.Parameters.AddWithValue("@P_ORG_CODE", "");
                DropDivision.DataSource = cmd.ExecuteReader();
                DropDivision.DataTextField = "NAME";
                DropDivision.DataValueField = "Id";
                DropDivision.DataBind();
                DropDivision.Items.FindByValue("1").Selected = true;

                //DropDivision.Items.Insert(0, new ListItem("Select", "0"));


            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }
        }



        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (DropOrderRefrel.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Order Referral...!')", true);

                return;
            }
            if (DropDivision.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Order  Division...!')", true);

                return;
            }
            if (DropPartyList.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Ship To Party...!')", true);

                return;
            }
            string name = "";
            DataTable dt;
            dt = BindDraftItems();
            con.Open();
            SqlTransaction sqltrans = con.BeginTransaction();
            try
            {
               

                cmd = new SqlCommand("PRC_ORDER_IUD", con, sqltrans);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_Id", 0);
                cmd.Parameters.AddWithValue("@P_UserName", Session["UserName"].ToString());
                cmd.Parameters.AddWithValue("@P_SalesGroup", txtSalesgroup.Text);
                cmd.Parameters.AddWithValue("@P_CustomerCode", lblCustomerCode.Text);
                cmd.Parameters.AddWithValue("@P_CustomerName", Session["CustName"].ToString());
                cmd.Parameters.AddWithValue("@P_OrderRefrel", DropOrderRefrel.SelectedValue);
                cmd.Parameters.AddWithValue("@P_ShipToParty", DropPartyList.SelectedValue);
                cmd.Parameters.AddWithValue("@P_ShipToPlant", txtPlant.Text);
                cmd.Parameters.AddWithValue("@P_OrderRefrelDiv", DropDivision.SelectedValue);
                cmd.Parameters.AddWithValue("@P_SiteName", txtSiteName.Text);

                if (Fileupload.HasFile)
                {
                    name = Fileupload.FileName;
                    string contentType = Fileupload.PostedFile.ContentType;

                    using (Stream stream = Fileupload.PostedFile.InputStream)
                    {
                        using (BinaryReader binaryReader = new BinaryReader(stream))
                        {
                            byteArray = binaryReader.ReadBytes((Int32)stream.Length);
                        }
                    }
                    //UploadService.FileUploadServiceSoapClient soapClient = new UploadService.FileUploadServiceSoapClient();
                    //soapClient.UploadFile(name, contentType, byteArray);
                    cmd.Parameters.AddWithValue("@P_Documents", byteArray);
                    cmd.Parameters.AddWithValue("@P_ContentType", contentType);
                    cmd.Parameters.AddWithValue("@P_Filename", name);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@P_Documents", null);
                    cmd.Parameters.AddWithValue("@P_ContentType", "");
                    cmd.Parameters.AddWithValue("@P_Filename", "");
                }

                cmd.Parameters.AddWithValue("@P_PONumber", txtPONumber.Text);
                cmd.Parameters.AddWithValue("@P_LPONumber", txtLPONumber.Text);
                cmd.Parameters.AddWithValue("@P_DeliveryDate", Convert.ToDateTime(txtDeliveryDate.Text));
                cmd.Parameters.AddWithValue("@P_Remark", txtRemark.Text);
                cmd.Parameters.AddWithValue("@P_Status", "S");
                cmd.Parameters.AddWithValue("@P_AddedBy", Session["UserCode"].ToString());
                cmd.Parameters.AddWithValue("@P_OrderHeaderId", DBNull.Value);
                cmd.Parameters.AddWithValue("@P_ProductCode", DBNull.Value);
                cmd.Parameters.AddWithValue("@P_ProductQty", DBNull.Value);
                cmd.Parameters.AddWithValue("@P_UOM", DBNull.Value);
                cmd.Parameters.AddWithValue("@P_ACTION", "I");
                cmd.Parameters.AddWithValue("@P_TYPE", "H");
                cmd.Parameters.AddWithValue("@P_DraftHeaderId", 1);
                cmd.Parameters.Add("@P_MESSAGE", SqlDbType.NVarChar, 300);
                cmd.Parameters["@P_MESSAGE"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                string Id = cmd.Parameters["@P_MESSAGE"].Value.ToString();

                foreach (DataRow dr in dt.Rows)
                {
                    cmd = new SqlCommand("PRC_ORDER_IUD", con, sqltrans);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_Id", 0);
                    cmd.Parameters.AddWithValue("@P_Documents", null);
                    cmd.Parameters.AddWithValue("@P_OrderHeaderId", Id);
                    cmd.Parameters.AddWithValue("@P_ProductCode", dr["ProductCode"].ToString()); ;
                    cmd.Parameters.AddWithValue("@P_ProductQty", dr["Qty"].ToString());
                    cmd.Parameters.AddWithValue("@P_UOM", dr["UOM"].ToString());
                    cmd.Parameters.AddWithValue("@P_ACTION", "I");
                    cmd.Parameters.AddWithValue("@P_TYPE", "D");
                    cmd.Parameters.AddWithValue("@P_DraftHeaderId", dr["HeaderId"].ToString());
                    cmd.Parameters.Add("@P_MESSAGE", SqlDbType.NVarChar, 300);
                    cmd.Parameters["@P_MESSAGE"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Order placed successfully...!');window.location ='Home.aspx';", true);

                }
                sqltrans.Commit();
                sendmail(Id);

            }
            catch (SqlException ex)
            {
                sqltrans.Rollback();
            }
            finally
            {
                con.Close();
            }



        }


        protected DataTable BindDraftItems()
        {
            DataTable dt = new DataTable();
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_CART_GETLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_CustomerCode", Session["CustomerCode"].ToString());
                cmd.Parameters.AddWithValue("@P_PlantCode", Session["CustomerPlant"].ToString());
                cmd.Parameters.AddWithValue("@P_AddedBy", Session["UserCode"].ToString());
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);


            }
            catch (SqlException ex)
            {

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

            return dt;





        }

        protected void BindCustomerDetails()
        {
            try
            {


                cmd = new SqlCommand("PRC_CUSTOMER_GETLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_Id", Session["CustomerCode"].ToString());
                cmd.Parameters.AddWithValue("@P_Action", "Details");
                cmd.Parameters.AddWithValue("@P_Keyword", "");
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtCustomerName.Text = Session["CustomerCode"].ToString() + "-" + dt.Rows[0]["CustomerName"].ToString();//dt.Rows[0]["CustomerName"].ToString();
                    //txtShipToParty.Text = Session["CustomerCode"].ToString() + "-" + dt.Rows[0]["CustomerName"].ToString();
                    Session["CustName"] = dt.Rows[0]["CustomerName"].ToString();

                    txtPlant.Text = Session["CustomerPlantDescription"].ToString();
                    lblCustomerCode.Text = Session["CustomerCode"].ToString();
                    txtSalesgroup.Text = dt.Rows[0]["Salesgroupdesc"].ToString();

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


        protected void sendmail(string Id)
        {
            try
            {



                cmd = new SqlCommand("PRC_EMAIL_GETUSERWISE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_USERCODE", "");
                cmd.Parameters.AddWithValue("@P_PAGE", "Order");
                cmd.Parameters.AddWithValue("@P_OrderId", Id);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
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
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Email Not Send');window.location ='Home.aspx';", true);

            }


        }
    }
}