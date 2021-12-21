using Cars_System.App_Code;
using System;
using System.Web.UI;

namespace Cars_System
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [Obsolete]
        protected void loginbtn_Click(object sender, EventArgs e)
        {
            string email = emailtxt.Text;
            string password = passwordtxt.Text;
            LoginClass loginclass = new LoginClass();
            if (email != "" && password != "")
            {
                switch (loginclass.LoginMethod(email, password))
                {

                    case 1:

                        UserController userControls0 = new UserController();
                        userControls0.GetUserInfoUsingEmail(email);
                        // LoginInformation.RoleID = userControls0.roleid;

                        // Session["RoleID"] = userControls0.roleid.ToString();
                        UserController userControls1 = new UserController();
                        userControls1.checkiflocked(email);

                        if (userControls1.IsLocked == "True")
                        {
                            string str = "'Your Account is Locked'";
                            //Page.RegisterClientScriptBlock("nameofscript", str);
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", str, true);
                            Response.Write(@"<script Language='javascript'>alert('Your Account is Locked');</script>");
                        }


                        //else if (userControls0.roleid == 1)
                        //{
                        //    Session["Email"] = loginemail;
                        //    Response.Redirect("~/UserControl/Templates/User/Home.aspx");
                        //}
                        else
                        {
                            Session["UserID"] = userControls0.UserId.ToString();
                            LoginClass loginclass2 = new LoginClass();
                            loginclass2.getcompanyID(email);
                            int CompanyID = loginclass2.CompanyID;
                            switch (CompanyID)
                            {
                                case 1:
                                    Response.Redirect("/Muhanadhome");
                                    break;
                                case 2:
                                    Response.Redirect("/Goldenhome");
                                    break;
                                case 3:
                                    Response.Redirect("/Ruknhome");
                                    break;
                                case 4:
                                    Response.Redirect("/Luxuryhome");
                                    break;
                                default:
                                    Response.Redirect("Login");
                                    break;
                            }


                        }
                        break;
                    case 0:
                        UserController userControls2 = new UserController();
                        userControls2.checkiflocked(email);
                        if (userControls2.IsLocked == "True")
                        {
                            //MessageBox.Show("Your Account is Locked, Please Contact Your Admin For Further Information", "Locked Account");
                            string str = "'Your Account is Locked'";
                            //Page.RegisterClientScriptBlock("nameofscript", str);
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", str, true);
                            Response.Write(@"<script Language='javascript'>alert('Your Account is Locked');</script>");
                        }
                        else
                        {
                            LoginClass userControls3 = new LoginClass();
                            userControls3.getattempts(email);
                            if (userControls3.AttemptsCount < 4)
                            {
                                int AttemptsCount = userControls3.AttemptsCount + 1;
                                LoginClass userControls4 = new LoginClass();
                                userControls4.updateAttempts(AttemptsCount, email);
                                emailtxt.Text = "wrong email";
                                passwordtxt.Text = "";
                                passwordtxt.Text = "wrong pass";
                            }
                            else
                            {
                                LoginClass userControls4 = new LoginClass();
                                userControls4.lockaccount(email);
                            }
                        }

                        break;
                    case -1:
                        emailtxt.Text = "invalid";
                        passwordtxt.Text = "invalid";
                        break;

                }
            }

        }
    }
}