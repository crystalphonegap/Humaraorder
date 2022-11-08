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

namespace HAMARAORDER
{
    public partial class ViewSalesOrderRefrel : System.Web.UI.Page
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

                        BindGV();
                    }
                }
                catch (Exception)
                {
                    Response.Redirect("Login.aspx");
                }

        }
        }

        protected void BindGV()
        {

            try
            {

                con.Open();
                cmd = new SqlCommand("PRC_SALESORDER_GETLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_Id", 0);
                cmd.Parameters.AddWithValue("@P_Action", "All");
                cmd.Parameters.AddWithValue("@P_Keyword", txtSearch.Text);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    gvSalesOrder.DataSource = dt;
                    gvSalesOrder.DataBind();
                }
                else
                {
                    gvSalesOrder.DataSource = null;
                    gvSalesOrder.DataBind();

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

    

        protected void gvSalesOrder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Id = e.CommandArgument.ToString();
            if (e.CommandName == "Edit")
            {
                Session["HSorderId"] = Id;
                Session["ViewSorder"] = "Edit";
                Response.Redirect("SalesOrderRefrel.aspx");
            }
            else if (e.CommandName == "View")
            {
                Session["HSorderId"] = Id;
                Session["ViewSorder"] = "View";
                Response.Redirect("SalesOrderRefrel.aspx");
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BindGV();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalesOrderRefrel.aspx");
        }

        protected void gvSalesOrder_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvSalesOrder_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSalesOrder.PageIndex = e.NewPageIndex;
            BindGV();
        }
    }
}