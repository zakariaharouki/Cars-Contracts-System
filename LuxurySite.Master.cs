using Cars_System.App_Code;
using System;

namespace Cars_System
{
    public partial class LuxurySite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] != null)
                {
                    UserController userController = new UserController();
                    string userid = (String)Session["UserID"];
                    userController.GetUserInfoUsingUserId(userid);
                    //int roleid = userController.roleid;
                    switch (userController.CompanyID)
                    {
                        case 1:
                            Response.Redirect("/Muhanadhome");
                            break;
                        case 2:
                            Response.Redirect("/Goldenhome");
                            break;
                        case 3:
                            switch (userController.roleid)
                            {
                                case 1:
                                    break;
                                case 2:
                                    AdmiSubMenu.Visible = false;
                                    break;
                            }
                            break;
                        case 4:
                            //GetCurrencies();
                            Response.Redirect("/Ruknhome");
                            break;
                    }
                }
                else
                {
                    Response.Redirect("/Login");
                }

            }
        }

        protected void logoutbtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login");
        }
    }
}