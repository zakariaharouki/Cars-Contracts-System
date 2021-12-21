using Cars_System.App_Code;
using System;

namespace Cars_System
{
    public partial class MuhanadSite : System.Web.UI.MasterPage
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
                    switch (userController.roleid)
                    {
                        case 1:
                            //pendingenquiries.Visible = false;
                            //CollabEnquiriesSubmenuControl.Visible = false;
                            //ChangeMypassLink.HRef = "/changemypass/" + userid;
                            //TeamSubmenuControl.Visible = false;
                            //neededproductslisting.Visible = false;
                            //string adminpath = Server.MapPath("~/Files/Images");
                            //processDirectory1(@"" + adminpath);
                            //processDirectory1(@"C:\Users\Zakaria\source\repos\Amags Global Web application\Amags Global Web application\Files\Images");
                            break;
                        case 2:
                            //addusers.Visible = false;

                            break;
                    }
                }
                else
                {

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