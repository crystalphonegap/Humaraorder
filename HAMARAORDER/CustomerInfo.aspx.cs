using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace HAMARAORDER
{
    public partial class CustomerInfo : System.Web.UI.Page
    {
        private SqlCommand cmd;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strDBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Session["Id"] != null || Session["Id"].ToString() != "")
                    {
                        if(Session["UserType"].ToString()=="Admin" )
                        {
                            lstcolor.Visible = true;
                            lstFavList.Visible = true;
                            lstHColor.Visible = true;
                            lstHFavList.Visible = true;
                            lstMColor.Visible = true;
                            lstMFavList.Visible = true;
                            lstRefrel.Visible = true;
                            lstHRefrel.Visible = true;
                            lstMRefrel.Visible = true;
                        }
                        else
                        {
                            lstcolor.Visible = false;
                            lstFavList.Visible = false;
                            lstHColor.Visible = false;
                            lstHFavList.Visible = false;
                            lstMColor.Visible = false;
                            lstMFavList.Visible = false;
                            lstRefrel.Visible = false;
                            lstHRefrel.Visible = false;
                            lstMRefrel.Visible = false;
                        }
                        loginDatetime.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        lblLoginUserName.Text = Session["UserName"].ToString();
                        BindCustomer();
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


                //BindRepeter();


            }

        }

        protected void rptProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void BindRepeter()
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_CART_GETLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_CustomerCode", Session["CustomerCode"].ToString());
                cmd.Parameters.AddWithValue("@P_PlantCode", Session["CustomerPlant"].ToString());
                cmd.Parameters.AddWithValue("@P_AddedBy", Session["Id"].ToString());
     
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                   // lblCount.Text = Convert.ToString(dt.Rows.Count);
                    rptCartProduct.DataSource = dt;
                    rptCartProduct.DataBind();
                }
                else
                {
                   //lblCount.Text = "0";
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

        protected void BindCustomer()
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_BIND_DROPDOWNLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_ACTION", "CUSTOMER");
                cmd.Parameters.AddWithValue("@P_CUSTOMERCODE", "");
                cmd.Parameters.AddWithValue("@P_LOGINUSER", Session["UserCode"].ToString());
                cmd.Parameters.AddWithValue("@P_USERTYPE", Session["UserType"].ToString());
                cmd.Parameters.AddWithValue("@P_ORG_CODE", Session["ORG"].ToString());

                dropCustomer.DataSource = cmd.ExecuteReader();
                dropCustomer.DataTextField = "NAME";
                dropCustomer.DataValueField = "Id";
                dropCustomer.DataBind();

                dropCustomer.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (SqlException ex)
            {

            }
            catch (Exception)
            {
                Response.Redirect("Login.aspx");
            }
            finally
            {
                con.Close();
            }
        }

        protected void BindPlant()
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_BIND_DROPDOWNLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_ACTION", "PLANT");
                cmd.Parameters.AddWithValue("@P_CUSTOMERCODE", dropCustomer.SelectedValue);
                cmd.Parameters.AddWithValue("@P_USERTYPE", Session["UserType"].ToString());
                cmd.Parameters.AddWithValue("@P_ORG_CODE", Session["ORG"].ToString());

                DropPlant.DataSource = cmd.ExecuteReader();
                DropPlant.DataTextField = "NAME";
                DropPlant.DataValueField = "Id";
                DropPlant.DataBind();

                DropPlant.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }
            BindDefaultPlant();
        }

        protected void BindDefaultPlant()
        {
            DropPlant.ClearSelection();
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_PLANT_GETDEFAULT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_COSTUMERCODE", dropCustomer.SelectedValue);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    try
                    {


                        DropPlant.Items.FindByValue(dt.Rows[0]["DefaultDeliveryPlant"].ToString()).Selected = true;
                    }
                    catch (Exception exx)
                    {

                    }
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

        protected void dropCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindPlant();

        }

        protected void DropPlant_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            if (DropPlant.SelectedValue != "0")
            {
                cmd = new SqlCommand("PRC_CUSTOMER_GETPLANT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_COSTUMERCODE", dropCustomer.SelectedValue);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lblDivisionCode.Text = dt.Rows[0]["DivisionCode"].ToString();
                    Session["ORGCODE"] = dt.Rows[0]["SalesOrganizationCode"].ToString();
                }
                else
                {
                    lblDivisionCode.Text = "70";
                }
                Session["CustomerCode"] = dropCustomer.SelectedValue;
                Session["CustomerPlant"] = DropPlant.SelectedValue;
                Session["CustomerPlantDescription"] = DropPlant.SelectedItem.Text;
                Session["Divisioncode"] = lblDivisionCode.Text;

                Response.Redirect("Home.aspx");
            }
            else
            {

            }
        }
    }
}