using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HAMARAORDER
{
    public partial class AddColorMaster : System.Web.UI.Page
    {
        private SqlCommand cmd;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strDBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["Id"] != null || Session["Id"].ToString() != "")
                    {
                        if (Session["UserType"].ToString() == "Admin" )
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
                        loginDatetime.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        lblLoginUserName.Text = Session["UserName"].ToString();
                        if (Session["HColorId"] != null && Session["HColorId"].ToString() != "")
                        {
                            lblId.Text = Session["HColorId"].ToString();
                            string Status = Session["ViewColor"].ToString();
                            if (Status == "View")
                            {
                                BindDetails(lblId.Text);
                                btnAdd.Visible = false;
                            }
                            else if (Status == "Edit")
                            {
                                BindDetails(lblId.Text);
                            }
                        }
                    }

                }
            }
            catch (Exception)
            {
                // Response.Redirect("ViewColorants.aspx");
            }
        }
        protected void BindDetails(string ColorantId)
        {
            try
            {

                con.Open();
                cmd = new SqlCommand("PRC_COLOR_GETLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_Id", lblId.Text);
                cmd.Parameters.AddWithValue("@P_Action", "Single");
                cmd.Parameters.AddWithValue("@P_Keyword", "");
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    txtColorName.Text = dt.Rows[0]["ColorName"].ToString();
                    lblHexaCode.Text = dt.Rows[0]["Hexadecimal"].ToString();
                    txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();
                    lblcolorcode.Text = dt.Rows[0]["Hexadecimal"].ToString();
                    HiddenR.Value = dt.Rows[0]["RUnit"].ToString();
                    HiddenG.Value = dt.Rows[0]["G_UNIT"].ToString();
                    HiddenB.Value = dt.Rows[0]["B_UNIT"].ToString();
                    lblImageName.Text = dt.Rows[0]["Image"].ToString();
                    txtColorCode.Text = dt.Rows[0]["ColorCode"].ToString();

                }
            }
            catch (SqlException Ex)
            {

            }
            finally
            {
                con.Close();
            }
            color1.Value = lblHexaCode.Text;


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            Session["HColorId"] = null;
            Session["ViewColor"] = null;
            Response.Redirect("ViewColorMaster.aspx");


        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_COLOR_MASTER_IUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_Id", lblId.Text);
                cmd.Parameters.AddWithValue("@P_ColorName", txtColorName.Text);
                cmd.Parameters.AddWithValue("@P_Hexadecimal", color1.Value);
                cmd.Parameters.AddWithValue("@P_RUnit", HiddenR.Value);
                cmd.Parameters.AddWithValue("@P_G_Unit", HiddenG.Value);
                cmd.Parameters.AddWithValue("@P_B_Unit", HiddenB.Value);
                cmd.Parameters.AddWithValue("@P_REMARKS", txtRemarks.Text);

                if (fileupload.HasFile)
                {
                    Random rd = new Random();

                    int n = rd.Next(000000, 999999);

                    string fileName = Path.GetFileName(fileupload.PostedFile.FileName);
                    fileupload.PostedFile.SaveAs(Server.MapPath("~/ColorImages/") + n + "" + fileName);
                    //UploadService.FileUploadServiceSoapClient soapClient = new UploadService.FileUploadServiceSoapClient();
                    //soapClient.UploadFile(name, contentType, byteArray);
                    cmd.Parameters.AddWithValue("@P_Image", n + "" + fileName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@P_Image", lblImageName.Text);
                }


                cmd.Parameters.AddWithValue("@P_ADDEDBY", 1);
                cmd.Parameters.AddWithValue("@P_ColorCode", txtColorCode.Text);
                if (lblId.Text == "")
                {
                    cmd.Parameters.AddWithValue("@P_ACTION", "I");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@P_ACTION", "U");
                }


                cmd.Parameters.Add("@P_MESSAGE", SqlDbType.VarChar, 300);
                cmd.Parameters["@P_MESSAGE"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                string Messages = cmd.Parameters["@P_MESSAGE"].Value.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Messages + "');window.location ='ViewColorMaster.aspx';", true);


            }
            catch (SqlException Ex)
            {

            }
            finally
            {
                con.Close();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewColorMaster.aspx");
        }
    }
}