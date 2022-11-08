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
    public partial class SalesOrderRefrel : System.Web.UI.Page
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
                        loginDatetime.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        lblLoginUserName.Text = Session["UserName"].ToString();
                        if (Session["HSorderId"] != null && Session["HSorderId"].ToString() != "")
                        {
                            lblId.Text = Session["HSorderId"].ToString();
                            string Status = Session["ViewSorder"].ToString();
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
                Response.Redirect("ViewSalesOrderRefrel.aspx");
            }
        }
        protected void BindDetails(string ColorantId)
        {
            try
            {

                con.Open();
                cmd = new SqlCommand("PRC_SALESORDER_GETLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_Id", lblId.Text);
                cmd.Parameters.AddWithValue("@P_Action", "Single");
                cmd.Parameters.AddWithValue("@P_Keyword", "");
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    txtBuyerName.Text = dt.Rows[0]["Buyer Name"].ToString();
                    txtCity.Text = dt.Rows[0]["City"].ToString();
                    txtContact_Name.Text = dt.Rows[0]["Contact_Name"].ToString();
                    txtContact_No.Text = dt.Rows[0]["Contact_No"].ToString();
                    txtEmail_ID.Text = dt.Rows[0]["Email_ID"].ToString();
                    txtGSTN.Text = dt.Rows[0]["GSTN"].ToString();
                    txtLocation.Text = dt.Rows[0]["Location"].ToString();
                    txtName.Text = dt.Rows[0]["Name"].ToString();
                    txtPIN_Code.Text = dt.Rows[0]["PIN_Code"].ToString();


                }
            }
            catch (SqlException Ex)
            {

            }
            finally
            {
                con.Close();
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["HSorderId"] = null;
            Session["ViewSorder"] = null;
            Response.Redirect("ViewSalesOrderRefrel.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_ORDERREFREL_IUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_Id", lblId.Text);
                cmd.Parameters.AddWithValue("@P_Name", txtName.Text);
                cmd.Parameters.AddWithValue("@P_BuyerName", txtBuyerName.Text);
                cmd.Parameters.AddWithValue("@P_GSTN", txtGSTN.Text);
                cmd.Parameters.AddWithValue("@P_ContactName", txtContact_Name.Text);
                cmd.Parameters.AddWithValue("@P_Contact_No", txtContact_No.Text);
                cmd.Parameters.AddWithValue("@P_Email", txtEmail_ID.Text);
                cmd.Parameters.AddWithValue("@P_City", txtCity.Text);
                cmd.Parameters.AddWithValue("@P_Location", txtLocation.Text);
                cmd.Parameters.AddWithValue("@P_PinCode", txtPIN_Code.Text);
                cmd.Parameters.AddWithValue("@P_USERCODE", Session["UserCode"].ToString());
                cmd.Parameters.AddWithValue("@P_ORG", Session["ORG"].ToString());
                if (lblId.Text == "" || lblId.Text == "0")
                {
                    cmd.Parameters.AddWithValue("@P_Action", "I");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@P_Action", "U");
                }

                cmd.ExecuteNonQuery();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Details Added Successfully');window.location ='ViewSalesOrderRefrel.aspx';", true);
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
            Response.Redirect("ViewSalesOrderRefrel.aspx");
        }
    }
}