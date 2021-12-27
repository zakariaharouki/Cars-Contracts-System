using Cars_System.App_Code;
using System;

namespace Cars_System.Pages.Rukn
{
    public partial class Ruknhome : System.Web.UI.Page
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
                            Response.Redirect("/Luxuryhome");
                            break;
                        case 4:
                            //GetCurrencies();
                            UserController userController1 = new UserController();
                            userController1.GetUserInfoUsingUserId(userid);
                            int roleid = userController.roleid;
                            switch (roleid)
                            {

                                case 1:
                                    break;
                                case 2:

                                    break;
                            }
                            break;
                    }
                }
                else
                {
                    Response.Redirect("/Login");
                }
            }
        }
    }
}