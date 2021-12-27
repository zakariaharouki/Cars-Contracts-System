﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cars_System.App_Code;

namespace Cars_System.Pages.MuhanadCars
{
    public partial class MuhanadChangeMyPassword : System.Web.UI.Page
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
                            string userid = (string)this.RouteData.Values["ID"];
                            switch (Session["UserID"].ToString() == userid)
                            {
                                case true:

                                    break;
                                case false:
                                    Response.Redirect("/Muhanadhome");
                                    break;
                            }
                            break;
                        case 2:
                            Response.Redirect("/Goldenhome");
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
            UserController userController = new UserController();
            string userid = (String)Session["UserID"];
            string oldpass = Oldpasstxt.Text;
            userController.getuserdetails(int.Parse(userid));
            string email = userController.Email;
            LoginClass loginController = new LoginClass();
            switch (loginController.LoginMethod(email, oldpass))
            {
                case 1:
                    UserController userController1 = new UserController();
                    string newpass = Newpasstxt.Text;
                    userController1.Updatepassword(int.Parse(userid), newpass);
                    break;
                case 0:
                    Oldpasstxt.Text = "You Entered Wrong Password";
                    break;
                case -1:
                    Oldpasstxt.Text = "invalid";
                    break;
            }
        }
    }
}