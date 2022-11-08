using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace HAMARAORDER
{
    public partial class Login : System.Web.UI.Page
    {
        private SqlCommand cmd;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strDBConnection"].ConnectionString);
        string StrApplName = ConfigurationManager.AppSettings["StrApplName"].ToString();
        string StrApplCode = ConfigurationManager.AppSettings["StrApplCode"].ToString();

        EncryptDecryptClass EncryptDecrypt = new EncryptDecryptClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Section1.Visible = true;
                Section2.Visible = false;
                list1.Attributes.Add("class", "active");
                list2.Attributes.Add("class", "");

                lblSuccess.Visible = false;
                lblInvalid.Visible = false;


                lblSuccess2.Visible = false;
                lblInvalid2.Visible = false;


            }

        }

        protected void kt_login_forgot_cancel2_Click(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            lblPasswordEncry.Text = EncryptDecrypt.Encrypt(txtPassword.Text);
            txtPassword.Attributes["value"] = lblPasswordEncry.Text;
            txtPassword.Text = txtPassword.Attributes["value"];
            if (LoginOTP2() == true )
            {

                try
                {
                    cmd = new SqlCommand("PRC_GET_USERDETAILS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_USERCODE", txtUsercode.Text);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        Session["UserCode"] = dt.Rows[0]["UserCode"].ToString();
                        Session["UserName"] = dt.Rows[0]["Name"].ToString();
                        Session["UserType"] = dt.Rows[0]["UserType"].ToString();
                        Session["UserEmail"] = dt.Rows[0]["Email"].ToString();
                        Session["ORG"] = dt.Rows[0]["ORG"].ToString();
                        Session["Id"] = dt.Rows[0]["Id"].ToString();
                        Response.Redirect("CustomerInfo.aspx");
                    }
                    else
                    {

                    }

                }
                catch (Exception ex)
                {

                }

            }
            else
            {

                checklogin();
            }

        }

        public void checklogin()
        {
            con.Open();
            try
            {


                cmd = new SqlCommand("PRC_USERS_GETDETAILS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_USERCODE", txtUsercode.Text.Trim());
                cmd.Parameters.AddWithValue("@P_PASSWORD", EncryptDecrypt.Decrypt(txtPassword.Attributes["value"].ToString().Trim()));
                cmd.Parameters.Add("@P_MESSAGE", SqlDbType.VarChar, 300);
                cmd.Parameters["@P_MESSAGE"].Direction = ParameterDirection.Output;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {


                    string Messages = cmd.Parameters["@P_MESSAGE"].Value.ToString();
                    if (Messages != "INVALID CREDENTIALS" || Messages != "USER IS NOT VALID...!")
                    {
                        Session["UserCode"] = dt.Rows[0]["UserCode"].ToString();
                        Session["UserName"] = dt.Rows[0]["Name"].ToString();
                        Session["UserType"] = dt.Rows[0]["UserType"].ToString();
                        Session["UserEmail"] = dt.Rows[0]["Email"].ToString();
                        Session["ORG"] = dt.Rows[0]["ORG"].ToString();
                        Session["Id"] = dt.Rows[0]["Id"].ToString();
                        Response.Redirect("CustomerInfo.aspx");
                    }
                    else
                    {
                        AlertMessage(Messages);
                    }
                    lblInvalid2.Visible = false;
                }
                else
                {
                    lblInvalid2.Visible = true;
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
        public void checklogin2()
        {
            con.Open();
            try
            {


                cmd = new SqlCommand("PRC_USERS_GETDETAILS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_USERCODE", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@P_PASSWORD", EncryptDecrypt.Decrypt(txtEpass.Attributes["value"].ToString().Trim()));
                cmd.Parameters.Add("@P_MESSAGE", SqlDbType.VarChar, 300);
                cmd.Parameters["@P_MESSAGE"].Direction = ParameterDirection.Output;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {


                    string Messages = cmd.Parameters["@P_MESSAGE"].Value.ToString();
                    if (Messages != "INVALID CREDENTIALS" || Messages != "USER IS NOT VALID...!")
                    {
                        Session["UserCode"] = dt.Rows[0]["UserCode"].ToString();
                        Session["UserName"] = dt.Rows[0]["Name"].ToString();
                        Session["UserType"] = dt.Rows[0]["UserType"].ToString();
                        Session["UserEmail"] = dt.Rows[0]["Email"].ToString();
                        Session["ORG"] = dt.Rows[0]["ORG"].ToString();
                        Session["Id"] = dt.Rows[0]["Id"].ToString();
                        Response.Redirect("CustomerInfo.aspx");
                    }
                    else
                    {
                        AlertMessage(Messages);
                    }
                    lblInvalid.Visible = false;
                }
                else
                {
                    lblInvalid.Visible = true;
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


        public void AlertMessage(string message)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), " alert('" + message + "');", true);
        }

        protected void btnEmailLogin_Click(object sender, EventArgs e)
        {


            lblPasswordEncry.Text = EncryptDecrypt.Encrypt(txtEpass.Text);
            txtEpass.Attributes["value"] = lblPasswordEncry.Text;
            txtEpass.Text = txtEpass.Attributes["value"];

            if (LoginOTP() == true)
            {
                try
                {
                    cmd = new SqlCommand("PRC_GET_USERDETAILS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_USERCODE", txtEmail.Text);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        Session["UserCode"] = dt.Rows[0]["UserCode"].ToString();
                        Session["UserName"] = dt.Rows[0]["Name"].ToString();
                        Session["UserType"] = dt.Rows[0]["UserType"].ToString();
                        Session["UserEmail"] = dt.Rows[0]["Email"].ToString();
                        Session["ORG"] = dt.Rows[0]["ORG"].ToString();
                        Session["Id"] = dt.Rows[0]["Id"].ToString();
                        Response.Redirect("CustomerInfo.aspx");
                    }
                    else
                    {

                    }

                }
                catch (Exception ex)
                {

                }



            }
            else
            {
                checklogin2();
            }

        }


        //Check Login
        public bool LoginOTP()
        {
            //Session["UserCode"].ToString()
            try
            {
                cmd = new SqlCommand("PRC_GET_USERDETAILS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_USERCODE", txtEmail.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Session["UserCode"] = dt.Rows[0]["UserCode"].ToString();
                }
                else
                {

                }

                string pass = EncryptDecrypt.Decrypt(txtEpass.Text);
                HAMARAORDER.ServiceReference1.WebServiceSoapClient obj = new HAMARAORDER.ServiceReference1.WebServiceSoapClient();
                bool rest = obj.Login(Encryptdata(Session["UserCode"].ToString()), Encryptdata(pass), Encryptdata(StrApplName), Encryptdata(StrApplCode));
                return rest;
            }
            catch (Exception ex)
            {


            }
            return false;


        }

        public bool LoginOTP2()
        {
            cmd = new SqlCommand("PRC_GET_USERDETAILS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_USERCODE", txtUsercode.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["UserCode"] = dt.Rows[0]["UserCode"].ToString();
            }
            else
            {

            }

            string pass = EncryptDecrypt.Decrypt(txtPassword.Text);
            HAMARAORDER.ServiceReference1.WebServiceSoapClient obj = new HAMARAORDER.ServiceReference1.WebServiceSoapClient();
            bool rest = obj.Login(Encryptdata(Session["UserCode"].ToString()), Encryptdata(pass), Encryptdata(StrApplName), Encryptdata(StrApplCode));
            return rest;

        }


        //generate OTP
        public bool generateOTP(string Mobile, string EMail, string UserName)
        {
            try
            {
                cmd = new SqlCommand("PRC_GET_USERDETAILS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_USERCODE", txtEmail.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Session["UserCode"] = dt.Rows[0]["UserCode"].ToString();
                }
                else
                {

                }

                HAMARAORDER.ServiceReference1.WebServiceSoapClient obj = new HAMARAORDER.ServiceReference1.WebServiceSoapClient();
                bool rest = obj.Password(Encryptdata(UserName), Encryptdata(Mobile), Encryptdata(StrApplName), Encryptdata(StrApplCode), Encryptdata(EMail));

                if (rest == true)
                {
                    lblSuccess.Visible = true;
                    lblInvalid.Visible = false;
                }
                else
                {
                    lblInvalid.Visible = true;
                    lblSuccess.Visible = false;
                }
                return rest;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool generateOTP2(string Mobile, string EMail, string UserName)
        {
            try
            {
                cmd = new SqlCommand("PRC_GET_USERDETAILS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_USERCODE", txtEmail.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Session["UserCode"] = dt.Rows[0]["UserCode"].ToString();
                }
                else
                {

                }

                HAMARAORDER.ServiceReference1.WebServiceSoapClient obj = new HAMARAORDER.ServiceReference1.WebServiceSoapClient();
                bool rest = obj.Password(Encryptdata(UserName), Encryptdata(Mobile), Encryptdata(StrApplName), Encryptdata(StrApplCode), Encryptdata(EMail));

                if (rest == true)
                {
                    lblSuccess2.Visible = true;
                    lblInvalid2.Visible = false;
                }
                else
                {
                    lblInvalid2.Visible = true;
                    lblSuccess2.Visible = false;
                }
                return rest;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public string Encryptdata(string retUsrId)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[retUsrId.Length];
            encode = Encoding.UTF8.GetBytes(retUsrId);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }

        protected void btnGenerateOTP_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                AlertMessage("User Code Not Find");
            }
            else
            {
                cmd = new SqlCommand("PRC_GET_USERDETAILS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_USERCODE", txtEmail.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string mobile = dt.Rows[0]["Mobile"].ToString();
                    string Email = dt.Rows[0]["Email"].ToString();
                    string UserName = dt.Rows[0]["UserCode"].ToString();
                    Session["UserCode"] = dt.Rows[0]["UserCode"].ToString();
                    Session["UserName"] = dt.Rows[0]["Name"].ToString();
                    Session["UserType"] = dt.Rows[0]["UserType"].ToString();
                    Session["UserEmail"] = dt.Rows[0]["Email"].ToString();
                    Session["ORG"] = dt.Rows[0]["ORG"].ToString();
                    Session["Id"] = dt.Rows[0]["Id"].ToString();
                    generateOTP(mobile, Email, UserName);
                }
                else
                {

                }



            }
        }
        protected void btnGenerateOTP_Click2(object sender, EventArgs e)
        {
            if (txtUsercode.Text == "")
            {
                AlertMessage("User Code Not Find");
            }
            else
            {
                cmd = new SqlCommand("PRC_GET_USERDETAILS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_USERCODE", txtUsercode.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string mobile = dt.Rows[0]["Mobile"].ToString();
                    string Email = dt.Rows[0]["Email"].ToString();
                    string UserName = dt.Rows[0]["UserCode"].ToString();
                    Session["UserCode"] = dt.Rows[0]["UserCode"].ToString();
                    Session["UserName"] = dt.Rows[0]["Name"].ToString();
                    Session["UserType"] = dt.Rows[0]["UserType"].ToString();
                    Session["UserEmail"] = dt.Rows[0]["Email"].ToString();
                    Session["ORG"] = dt.Rows[0]["ORG"].ToString();
                    Session["Id"] = dt.Rows[0]["Id"].ToString();
                    generateOTP2(mobile, Email, UserName);
                }
                else
                {

                }



            }
        }


        protected void lnkSection1_Click(object sender, EventArgs e)
        {
            Section1.Visible = true;
            Section2.Visible = false;
            list1.Attributes.Add("class", "active");
            list2.Attributes.Add("class", "");

        }

        protected void lnkBtnSection2_Click(object sender, EventArgs e)
        {
            Section1.Visible = false;
            Section2.Visible = true;
            list1.Attributes.Add("class", "");
            list2.Attributes.Add("class", "active");

        }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {
            //lblPasswordEncry.Text = EncryptDecrypt.Encrypt(txtPassword.Text);
            //txtPassword.Attributes["value"] = lblPasswordEncry.Text;

        }

        protected void txtEpass_TextChanged(object sender, EventArgs e)
        {
            //lblPasswordEncry.Text = EncryptDecrypt.Encrypt(txtEpass.Text);
            //txtEpass.Attributes["value"] = lblPasswordEncry.Text;

        }
    }
}