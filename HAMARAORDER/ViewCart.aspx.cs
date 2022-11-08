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
    public partial class ViewCart : System.Web.UI.Page
    {
        private SqlCommand cmd, cmd2;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strDBConnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
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
                        lstMViewColor.Visible = true;
                        lstMFavList.Visible = true;
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

                
                      
                        lstMViewColor.Visible = false;
                        lstMFavList.Visible = false;
                        lstRefrel.Visible = false;
                        lstHRefrel.Visible = false;
                        lstMRefrel.Visible = false;

                    }

                    loginDatetime.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    lblLoginUserName.Text = Session["UserName"].ToString();
                    BindRepeter();
                    BindCustomerDetails();
                }
            }
            BindCartRepeter();
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


        protected void rptProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "Remove")
            {
                con.Open();
                try
                {
                    cmd = new SqlCommand("PRC_DRAFT_IUD", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_Id", id);
                    cmd.Parameters.AddWithValue("@P_Action", "D");
                    cmd.Parameters.Add("@P_Message", SqlDbType.NVarChar, 300);
                    cmd.Parameters["@P_Message"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    Response.Redirect("ViewCart.aspx");
                }
                catch (SqlException ex)
                {

                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string status = "";
            con.Open();
            SqlTransaction sqltrans = con.BeginTransaction();
            try
            {
                foreach (RepeaterItem item in rptProduct.Items)
                {

                    string ProductCode = (item.FindControl("lblCode") as Label).Text;
                    string Id = (item.FindControl("lblhId") as Label).Text;
                    string Qty = (item.FindControl("txtItemQty") as TextBox).Text;
                    string UOM = (item.FindControl("lblUOM") as Label).Text;
                    //DropDownList dropUOM = (item.FindControl("dropUOM") as DropDownList);
                    if (status == "")
                    {


                        cmd = new SqlCommand("PRC_DRAFT_IUD", con, sqltrans);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@P_Id", Id);
                        cmd.Parameters.AddWithValue("@P_CustomerCode", Session["CustomerCode"].ToString());
                        cmd.Parameters.AddWithValue("@P_PlantCode", Session["CustomerPlant"].ToString());
                        cmd.Parameters.AddWithValue("@P_Status", "D");
                        cmd.Parameters.AddWithValue("@P_LoginUserId", Session["UserCode"].ToString());
                        cmd.Parameters.AddWithValue("@P_LoginUserName", Session["UserName"].ToString());
                        cmd.Parameters.AddWithValue("@P_ProductCode", ProductCode);
                        cmd.Parameters.AddWithValue("@P_QTY", Qty);
                        cmd.Parameters.AddWithValue("@P_Action", "U");
                        cmd.Parameters.AddWithValue("@P_Type", "H");
                        cmd.Parameters.AddWithValue("@P_UOM", UOM);
                        cmd.Parameters.Add("@P_Message", SqlDbType.NVarChar, 300);
                        cmd.Parameters["@P_Message"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        status = "Header";
                    }

                    cmd2 = new SqlCommand("PRC_DRAFT_IUD", con, sqltrans);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@P_Id", Id);
                    cmd2.Parameters.AddWithValue("@P_QTY", Qty);
                    cmd2.Parameters.AddWithValue("@P_Action", "I");
                    cmd2.Parameters.AddWithValue("@P_ProductCode", ProductCode);
                    cmd2.Parameters.AddWithValue("@P_Type", "D");
                    cmd2.Parameters.AddWithValue("@P_UOM", UOM);
                    cmd2.Parameters.Add("@P_Message", SqlDbType.NVarChar, 300);
                    cmd2.Parameters["@P_Message"].Direction = ParameterDirection.Output;
                    cmd2.ExecuteNonQuery();
                }
                sqltrans.Commit();
                Response.Redirect("ViewCart.aspx");
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



        protected void BindRepeter()
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
                    lblcounts.Text = Convert.ToString(dt.Rows.Count);
                    rptProduct.DataSource = dt;
                    rptProduct.DataBind();
                    btnproceed.Visible = true; ;
                }
                else
                {
                    lblcounts.Text = "0";
                    btnproceed.Visible = false;
                }

            }
            catch (SqlException ex)
            {

            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx");
            }
            finally
            {
                con.Close();
            }






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
                    lblCustName.Text = dt.Rows[0]["CustomerName"].ToString();
                    lblCustomerCode.Text = Session["CustomerCode"].ToString();
                    lblPlant.Text = Session["CustomerPlant"].ToString();

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
    }
}