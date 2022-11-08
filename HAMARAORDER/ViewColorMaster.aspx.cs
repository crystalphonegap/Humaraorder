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
    public partial class ViewColorMaster : System.Web.UI.Page
    {
        private SqlCommand cmd;
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
        }

        protected void BindGV()
        {

            try
            {

                con.Open();
                cmd = new SqlCommand("PRC_COLOR_GETLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_Id", 0);
                cmd.Parameters.AddWithValue("@P_Action", "All");
                cmd.Parameters.AddWithValue("@P_Keyword", txtSearch.Text);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    gvColorants.DataSource = dt;
                    gvColorants.DataBind();
                }
                else
                {
                    gvColorants.DataSource = null;
                    gvColorants.DataBind();

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

        protected void gvColorants_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string ColorCode = (e.Row.FindControl("lblHexa1") as Label).Text;
                TableCell cell = e.Row.Cells[1];
                cell.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorCode);
            }
        }

        protected void gvColorants_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Id = e.CommandArgument.ToString();
            if (e.CommandName == "Edit")
            {
                Session["HColorId"] = Id;
                Session["ViewColor"] = "Edit";
                Response.Redirect("AddColorMaster.aspx");
            }
            else if (e.CommandName == "View")
            {
                Session["HColorId"] = Id;
                Session["ViewColor"] = "View";
                Response.Redirect("AddColorMaster.aspx");
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BindGV();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddColorMaster.aspx");
        }

        protected void gvColorants_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvColorants_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvColorants.PageIndex = e.NewPageIndex;
            BindGV();
        }
    }
}