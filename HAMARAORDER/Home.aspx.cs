using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HAMARAORDER
{
    public partial class Home : System.Web.UI.Page
    {

        private SqlCommand cmd, cmd2;
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
                            lstcolor.Visible = true;
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
                            lstcolor.Visible = false;
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
                        BindCategoryFilter();
                        BindColorFilter();
                        BindUOMFilter();
                        BindProduct(1, 20);

                    }
                    else
                    {
                        Response.Redirect("Login.aspx");
                    }


                }
                BindRepeter();
            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx");
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

        // Home Code //
        protected void BindProduct(int pageNumber, int PageSize)
        {

            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_PRODUCT_GETLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_Id", 0);
                cmd.Parameters.AddWithValue("@P_Action", "ALL");
                cmd.Parameters.AddWithValue("@P_Keyword", "");
                cmd.Parameters.AddWithValue("@P_PageNumber", pageNumber);
                cmd.Parameters.AddWithValue("@P_PageSize", 20);
                cmd.Parameters.AddWithValue("@P_Division", Session["Divisioncode"].ToString());
                cmd.Parameters.AddWithValue("@P_ORGCODE", Session["ORGCODE"].ToString());
                cmd.Parameters.AddWithValue("@P_ProductName", txtsearch.Text.TrimEnd());

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lblcountAll.Text = dt.Rows[0]["TotalCount"].ToString();
                    rptProduct.DataSource = dt;
                    rptProduct.DataBind();
                    PopulatePager(Convert.ToInt32(lblcountAll.Text), pageNumber);
                }
                else
                {
                    rptProduct.DataSource = null;
                    rptProduct.DataBind();
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

        protected void btncart_Click(object sender, EventArgs e)
        {
            LinkButton button = (sender as LinkButton);

            //Get the command argument
            string commandArgument = button.CommandArgument;

            //Get the Repeater Item reference
            RepeaterItem item = button.NamingContainer as RepeaterItem;

            //Get the repeater item index
            int index = item.ItemIndex;
            string ProductCode = (item.FindControl("lblMcode") as Label).Text;
            string qty = (item.FindControl("txtQty") as TextBox).Text;
            DropDownList dropUOM = (item.FindControl("dropUOM") as DropDownList);
            if (qty == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Check Quantity')", true);

                return;
            }
            else
            {

            }
            con.Open();
            SqlTransaction sqltrans = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("PRC_DRAFT_IUD", con, sqltrans);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_Id", 0);
                cmd.Parameters.AddWithValue("@P_CustomerCode", Session["CustomerCode"].ToString());
                cmd.Parameters.AddWithValue("@P_PlantCode", Session["CustomerPlant"].ToString());
                cmd.Parameters.AddWithValue("@P_Status", "D");
                cmd.Parameters.AddWithValue("@P_LoginUserId", Session["UserCode"].ToString());
                cmd.Parameters.AddWithValue("@P_LoginUserName", Session["UserName"].ToString());
                cmd.Parameters.AddWithValue("@P_ProductCode", ProductCode);
                cmd.Parameters.AddWithValue("@P_QTY", qty);
                cmd.Parameters.AddWithValue("@P_Action", "I");
                cmd.Parameters.AddWithValue("@P_Type", "H");
                cmd.Parameters.AddWithValue("@P_UOM", dropUOM.SelectedValue);
                cmd.Parameters.Add("@P_Message", SqlDbType.NVarChar, 300);
                cmd.Parameters["@P_Message"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                string Id = cmd.Parameters["@P_Message"].Value.ToString();
                if (Id == "Selected unit is not applicable for this product")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selected unit is not applicable for this product')", true);
                    return;
                }
                

                cmd2 = new SqlCommand("PRC_DRAFT_IUD", con, sqltrans);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@P_Id", Id);
                cmd2.Parameters.AddWithValue("@P_LoginUserId", Session["UserCode"].ToString());
                cmd2.Parameters.AddWithValue("@P_QTY", qty);
                cmd2.Parameters.AddWithValue("@P_Action", "I");
                cmd2.Parameters.AddWithValue("@P_ProductCode", ProductCode);
                cmd2.Parameters.AddWithValue("@P_Type", "D");
                cmd2.Parameters.AddWithValue("@P_UOM", dropUOM.SelectedValue);
                cmd2.Parameters.Add("@P_Message", SqlDbType.NVarChar, 300);
                cmd2.Parameters["@P_Message"].Direction = ParameterDirection.Output;
                cmd2.ExecuteNonQuery();

                string Id2 = cmd2.Parameters["@P_Message"].Value.ToString();

                if (Id2 == "Product is already added into the cart please update details in cart")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Product is already added into the cart please update details in cart')", true);
                    return;
                }
                sqltrans.Commit();
                //Response.Redirect("Home.aspx");

            }
            catch (SqlException ex)
            {
                sqltrans.Rollback();
            }
            finally
            {
                con.Close();
            }
            BindRepeter();
        }

        protected void BindColorFilter()
        {
            con.Open();
            try
            {


                cmd = new SqlCommand("PRC_COLOR_GETLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_Id", 0);
                cmd.Parameters.AddWithValue("@P_Action", "All");
                cmd.Parameters.AddWithValue("@P_Keyword", "");
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    RptColorantDetails.DataSource = dt;
                    RptColorantDetails.DataBind();
                    rptmColor.DataSource = dt;
                    rptmColor.DataBind();
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

        protected void RptColorantDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                string ColorCode = (e.Item.FindControl("lblHexa1") as Label).Text;
                (e.Item.FindControl("lblHexa") as Label).BackColor = System.Drawing.ColorTranslator.FromHtml(ColorCode);
                (e.Item.FindControl("lblHexa") as Label).ForeColor = System.Drawing.ColorTranslator.FromHtml(ColorCode);

            }
        }

        protected void rptCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void chkbox_CheckedChanged(object sender, EventArgs e)
        {
            BindProductWithFiltter(1, 20);
        }

        protected void BindCategoryFilter()
        {
            cmd = new SqlCommand("PRC_CATEGORY_GETLIST", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_Id", 0);
            cmd.Parameters.AddWithValue("@P_DivisionCode", Session["Divisioncode"].ToString());
            cmd.Parameters.AddWithValue("@P_ORGCODE", Session["ORGCODE"].ToString());
            cmd.Parameters.AddWithValue("@P_Keyword", txtcategorySearch.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                rptCategory.DataSource = dt;
                rptCategory.DataBind();
                rptMCalegory.DataSource = dt;
                rptMCalegory.DataBind();
            }
        }

        protected void chkCategorybox_CheckedChanged(object sender, EventArgs e)
        {

            BindProductWithFiltter(1, 20);
        }

        protected void BindUOMFilter()
        {
            cmd = new SqlCommand("PRC_UOM_FILTTER", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_Id", 0);
            cmd.Parameters.AddWithValue("@P_DivisionCode", Session["Divisioncode"].ToString());
            cmd.Parameters.AddWithValue("@P_ORGCODE", Session["ORGCODE"].ToString());
            cmd.Parameters.AddWithValue("@P_Keyword", txtsizesearch.Text.Trim());
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                rptUnit.DataSource = dt;
                rptUnit.DataBind();
                rptMSize.DataSource = dt;
                rptMSize.DataBind();
            }
        }

        protected void chkcolorBox_CheckedChanged(object sender, EventArgs e)
        {
            BindProductWithFiltter(1, 20);
        }

        protected void rptmColor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                string ColorCode = (e.Item.FindControl("lblHexa1") as Label).Text;
                (e.Item.FindControl("lblHexa") as Label).BackColor = System.Drawing.ColorTranslator.FromHtml(ColorCode);
                (e.Item.FindControl("lblHexa") as Label).ForeColor = System.Drawing.ColorTranslator.FromHtml(ColorCode);

            }
        }

        protected void BindProductWithFiltter(int PageNumber, int PageSize)
        {
            string code = "";
            string UOM = "";
            string color = "";
            foreach (RepeaterItem rpt in rptCategory.Items)
            {
                CheckBox chk = (rpt.FindControl("chkCategorybox") as CheckBox);
                string lblcode = (rpt.FindControl("lblcode") as Label).Text; ;
                if (chk.Checked == true)
                {
                    code = code + lblcode + ",";
                }
                else
                {

                }
            }
            foreach (RepeaterItem rpt in rptUnit.Items)
            {
                CheckBox chk = (rpt.FindControl("chkboxUnit") as CheckBox);
                string lblUOM = (rpt.FindControl("lblUOM") as Label).Text; ;
                if (chk.Checked == true)
                {
                    UOM = UOM + lblUOM + ",";
                }
                else
                {

                }
            }
            foreach (RepeaterItem rpt in RptColorantDetails.Items)
            {
                CheckBox chkcolorBox = (rpt.FindControl("chkcolorBox") as CheckBox);
                string lblColor = (rpt.FindControl("lblColorCode") as Label).Text; ;
                if (chkcolorBox.Checked == true)
                {
                    color = color + lblColor + ",";
                }
                else
                {

                }
            }
            if (UOM == "" && code == "" && color == "")
            {
                BindProduct(PageNumber, PageSize);
            }
            else
            {



                con.Open();
                try
                {
                    cmd = new SqlCommand("PRC_PRODUCT_GETLIST_WITHFILTTER", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_ColorKeyword", color.TrimEnd(','));
                    cmd.Parameters.AddWithValue("@P_SizeKeyword", UOM.TrimEnd(','));
                    cmd.Parameters.AddWithValue("@P_CategoryKeyword", code.TrimEnd(','));
                    cmd.Parameters.AddWithValue("@P_PageNumber", PageNumber);
                    cmd.Parameters.AddWithValue("@P_PageSize", PageSize);
                    cmd.Parameters.AddWithValue("@P_Division", Session["Divisioncode"].ToString());
                    cmd.Parameters.AddWithValue("@P_ORGCODE", Session["ORGCODE"].ToString());
                    cmd.Parameters.AddWithValue("@P_MaterialCode", txtsearch.Text.Trim());
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        rptProduct.DataSource = dt;
                        rptProduct.DataBind();
                    }
                    else
                    {
                        rptProduct.DataSource = null;
                        rptProduct.DataBind();
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

        protected void chkMcolorBox_CheckedChanged(object sender, EventArgs e)
        {
            BindMobileProductWithFiltter(1, 20);
        }
        protected void BindMobileProductWithFiltter(int PageNumber, int PageSize)
        {
            string code = "";
            string UOM = "";
            string color = "";
            foreach (RepeaterItem rpt in rptMCalegory.Items)
            {
                CheckBox chk = (rpt.FindControl("chkCategorybox") as CheckBox);
                string lblcode = (rpt.FindControl("lblcode") as Label).Text; ;
                if (chk.Checked == true)
                {
                    code = code + lblcode + ",";
                }
                else
                {

                }
            }
            foreach (RepeaterItem rpt in rptMSize.Items)
            {
                CheckBox chk = (rpt.FindControl("chkboxUnit") as CheckBox);
                string lblUOM = (rpt.FindControl("lblUOM") as Label).Text; ;
                if (chk.Checked == true)
                {
                    UOM = UOM + lblUOM + ",";
                }
                else
                {

                }
            }
            foreach (RepeaterItem rpt in rptmColor.Items)
            {
                CheckBox chkcolorBox = (rpt.FindControl("chkcolorBox") as CheckBox);
                string lblColor = (rpt.FindControl("lblColorName") as Label).Text; ;
                if (chkcolorBox.Checked == true)
                {
                    color = color + lblColor + ",";
                }
                else
                {

                }
            }
            if (UOM == "" && code == "" && color == "")
            {
                BindProduct(PageNumber, PageSize);
            }
            else
            {



                con.Open();
                try
                {
                    cmd = new SqlCommand("PRC_PRODUCT_GETLIST_WITHFILTTER", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_ColorKeyword", color.TrimEnd(','));
                    cmd.Parameters.AddWithValue("@P_SizeKeyword", UOM.TrimEnd(','));
                    cmd.Parameters.AddWithValue("@P_CategoryKeyword", code.TrimEnd(','));
                    cmd.Parameters.AddWithValue("@P_PageNumber", PageNumber);
                    cmd.Parameters.AddWithValue("@P_PageSize", PageSize);
                    cmd.Parameters.AddWithValue("@P_Division", Session["Divisioncode"].ToString());
                    cmd.Parameters.AddWithValue("@P_ORGCODE", Session["ORGCODE"].ToString());
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        lblcountAll.Text = dt.Rows[0]["TotalCount"].ToString();
                        rptProduct.DataSource = dt;
                        rptProduct.DataBind();
                    }
                    else
                    {
                        rptProduct.DataSource = null;
                        rptProduct.DataBind();
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


        private void PopulatePager(int recordCount, int currentPage)
        {
            //int iRecordCount = recordCount;
            int PageSize = 20;
            //double dPageCount = (double)((decimal)iRecordCount / Convert.ToDecimal(20));
            //int iPageCount = (int)Math.Ceiling(dPageCount);
            //List<ListItem> lPages = new List<ListItem>();
            //if (iPageCount > 0)
            //{
            //    for (int i = 1; i <= iPageCount; i++)
            //        lPages.Add(new ListItem(i.ToString(), i.ToString(), i != 20));
            //}
            //rptPager.DataSource = lPages;
            //rptPager.DataBind();

            double dblPageCount = (double)((decimal)recordCount / (decimal)PageSize);
            int pageCount = (int)Math.Ceiling(dblPageCount);
            if (pageCount > 0)
            {
                if (currentPage == 1)
                {
                    lbtnPrev.Visible = false;
                }
                else
                {
                    lbtnPrev.CommandArgument = (currentPage - 1).ToString();
                    lbtnPrev.Visible = true;
                }
                if (currentPage > dblPageCount)
                {
                    lbtnNext.Visible = false;
                }
                else
                {
                    lbtnNext.CommandArgument = (currentPage + 1).ToString();
                    lbtnNext.Visible = true;
                }
            }


        }

        protected void rptPager_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int iPageIndex = Convert.ToInt32(e.CommandArgument);
            BindProduct(iPageIndex, 20);
        }

        protected void rptProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //string lblimage = (e.Item.FindControl("lblimage") as Label).Text;
                //var request = (System.Net.FtpWebRequest)WebRequest.Create("ftp://www.crystaldatainc.com/pidilite-img/" + lblimage);
                //request.Credentials = new NetworkCredential("crystaldatainc", "1Uh$86dn");
                //request.Method = WebRequestMethods.Ftp.DownloadFile;
                //request.UsePassive = true;
                //request.UseBinary = true;
                //request.EnableSsl = false;

                //try
                //{
                //    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                //    (e.Item.FindControl("prdimage") as Image).ImageUrl = "https://www.crystaldatainc.com/pidilite-img/" + lblimage;
                //}
                //catch (WebException ex)
                //{
                //    FtpWebResponse response = (FtpWebResponse)ex.Response;
                //    if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) ;
                //    (e.Item.FindControl("prdimage") as Image).ImageUrl = "https://www.crystaldatainc.com/pidilite-img/no-image.jpg";

                //}



            }
        }

        protected void txtcategorySearch_TextChanged(object sender, EventArgs e)
        {
            BindCategoryFilter();
        }

        protected void btnlinksearchProduct_Click(object sender, EventArgs e)
        {
            BindProduct(1, 20);
            BindUOMFilter();
        }

        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            BindProduct(pageIndex, 20);
        }

        protected void searchcategory_TextChanged(object sender, EventArgs e)
        {
            BindUOMFilter();
        }

        //[WebMethod]
        //public static List<string> SearchCustomers(string prefixText, int count)
        //{
        //    SqlCommand cmd = new SqlCommand("PRC_SEARCH_PRODUCTLIST", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@P_KEYWORD", prefixText);
        //    cmd.Parameters.AddWithValue("@P_ORG_CODE", HttpContext.Current.Session["ORGCODE"].ToString());
        //    cmd.Parameters.AddWithValue("@P_Division", HttpContext.Current.Session["Divisioncode"].ToString());
        //    List<string> Product = new List<string>();
        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    sda.Fill(dt);
        //    foreach(DataRow dr in dt.Rows)
        //    {
        //        Product.Add(dr["PName"].ToString());
        //    }
           
        //    return Product;
        //}

        protected void txtsizesearch_TextChanged(object sender, EventArgs e)
        {
            BindUOMFilter();
        }

        //[WebMethod]
        //public static List<string> SearchCategory(string prefixText, int count)
        //{
        //    SqlCommand cmd = new SqlCommand("PRC_SEARCH_Category", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@P_Keyword", prefixText);
        //    cmd.Parameters.AddWithValue("@P_ORGCODE", HttpContext.Current.Session["ORGCODE"].ToString());
        //    cmd.Parameters.AddWithValue("@P_DivisionCode", HttpContext.Current.Session["Divisioncode"].ToString());
        //    List<string> category = new List<string>();
        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    sda.Fill(dt);
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        category.Add(dr["cateName"].ToString());
        //    }

        //    return category;
        //}     
        
        //[WebMethod]
        //public static List<string> Searchsize(string prefixText, int count)
        //{
        //    SqlCommand cmd = new SqlCommand("PRC_SEARCH_SIZE", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@P_Keyword", prefixText);
        //    cmd.Parameters.AddWithValue("@P_ORGCODE", HttpContext.Current.Session["ORGCODE"].ToString());
        //    cmd.Parameters.AddWithValue("@P_DivisionCode", HttpContext.Current.Session["Divisioncode"].ToString());
        //    List<string> size = new List<string>();
        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    sda.Fill(dt);
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        size.Add(dr["sizename"].ToString());
        //    }

        //    return size;
        //}
    }
}