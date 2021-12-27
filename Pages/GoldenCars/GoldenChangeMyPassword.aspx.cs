using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cars_System.App_Code;

namespace Cars_System.Pages.GoldenCars
{
    public partial class GoldenChangeMyPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] != null)
                {
                    UserController userController = new UserController();
                    string sessionid = (String)Session["UserID"];
                    userController.GetUserInfoUsingUserId(sessionid);
                    //int roleid = userController.roleid;
                    switch (userController.CompanyID)
                    {
                        case 1:
                            Response.Redirect("/Muhanadhome");
                            break;
                        case 2:
                            string userid = (string)this.RouteData.Values["ID"];
                            switch (Session["UserID"].ToString() == userid)
                            {
                                case true:

                                    break;
                                case false:
                                    Response.Redirect("/Goldenhome");
                                    break;
                            }
                            break;
                        case 3:
                            Response.Redirect("/Luxuryhome");
                            break;
                        case 4:
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

        protected void Changepassbtn_Click(object sender, EventArgs e)
        {

        }
    }
}