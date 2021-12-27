using System;
using Cars_System.App_Code;

namespace Cars_System
{
    public partial class RuknSite : System.Web.UI.MasterPage
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
                            switch (userController.roleid)
                            {
                                case 1:
                                    ChangeMypassLink.HRef = "/RuknChangeMyPass/"+userid;
                                    break;
                                case 2:
                                    ChangeMypassLink.HRef = "/RuknChangeMyPass/"+userid;
                                    AdmiSubMenu.Visible = false;


                                    break;
                            }
                            break;
                    }

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