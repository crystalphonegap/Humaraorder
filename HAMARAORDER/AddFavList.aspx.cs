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
    public partial class AddFavList : System.Web.UI.Page
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
                        GetProduct();
                        GetFAVProduct();
                    }
                }
            }
            catch (Exception)
            {
                // Response.Redirect("ViewColorants.aspx");
            }
        }

        protected void GetProduct()
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_PRODUCT_BINDFAVLSIT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_ID", 0);
                cmd.Parameters.AddWithValue("@P_ACTION", "NLIST");
                cmd.Parameters.AddWithValue("@P_ORGCODE", Session["ORG"].ToString());

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lstLeft.DataSource = dt;
                    lstLeft.DataTextField = "Name";
                    lstLeft.DataValueField = "Code";
                    lstLeft.DataBind();
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

        protected void GetFAVProduct()
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_PRODUCT_BINDFAVLSIT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_ID", 0);
                cmd.Parameters.AddWithValue("@P_ACTION", "FAVLIST");
                cmd.Parameters.AddWithValue("@P_ORGCODE", Session["ORG"].ToString());
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lstRight.DataSource = dt;
                    lstRight.DataTextField = "Name";
                    lstRight.DataValueField = "Code";
                    lstRight.DataBind();
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


        protected void LeftClick(object sender, EventArgs e)
        {
            //List will hold items to be removed.
            List<ListItem> removedItems = new List<ListItem>();

            //Loop and transfer the Items to Destination ListBox.
            foreach (ListItem item in lstRight.Items)
            {
                if (item.Selected)
                {
                    item.Selected = false;
                    lstLeft.Items.Add(item);
                    removedItems.Add(item);
                }
            }

            //Loop and remove the Items from the Source ListBox.
            foreach (ListItem item in removedItems)
            {
                lstRight.Items.Remove(item);
            }
        }

        protected void RightClick(object sender, EventArgs e)
        {
            //List will hold items to be removed.
            List<ListItem> removedItems = new List<ListItem>();

            //Loop and transfer the Items to Destination ListBox.
            foreach (ListItem item in lstLeft.Items)
            {
                if (item.Selected)
                {
                    item.Selected = false;
                    lstRight.Items.Add(item);
                    removedItems.Add(item);
                }
            }

            //Loop and remove the Items from the Source ListBox.
            foreach (ListItem item in removedItems)
            {
                lstLeft.Items.Remove(item);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {




        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlTransaction sqltrans = con.BeginTransaction();
            try
            {
                string Type = "NEW";
                foreach (ListItem item in lstRight.Items)
                {
                    cmd = new SqlCommand("PRC_FAVLIST_IUD", con, sqltrans);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_Id", 0);
                    cmd.Parameters.AddWithValue("@P_PRODUCTCode", item.Value);
                    cmd.Parameters.AddWithValue("@P_PRODUCTNAME", item.Text);
                    cmd.Parameters.AddWithValue("@P_USERCODE", "AdMIN");
                    cmd.Parameters.AddWithValue("@P_ACTION", "I");
                    cmd.Parameters.AddWithValue("@P_TYPE", Type);
                    cmd.Parameters.AddWithValue("@P_ORG", Session["ORG"].ToString());
                    cmd.ExecuteNonQuery();
                    Type = "OLD";
                }
                sqltrans.Commit();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Favourite List added successfully');window.location ='AddFavList.aspx';", true);

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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewColorMaster.aspx");
        }
    }
}