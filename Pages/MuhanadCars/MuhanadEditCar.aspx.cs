using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cars_System.App_Code;

namespace Cars_System.Pages.MuhanadCars
{
    public partial class MuhanadEditCar : System.Web.UI.Page
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
                    switch (userController.CompanyID)
                    {
                        case 1:
                            switch (userController.roleid)
                            {
                                case 1:
                                    GetCar();
                                    break;
                                case 2:
                                    Response.Redirect("/Muhanadhome");
                                    break;
                                case -1:
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

        protected void EditCarbtn_Click(object sender, EventArgs e)
        {
            string CarID = (string)(this.RouteData.Values["ID"]);
            Cars cars = new Cars();
            //int contractnew = GetHighestContract();
            string Carname = Carnametxt.Text;
            string Buyername = Purchasernametxt.Text;
            //string contractnumber = (contractnew + 1).ToString();
            string TempNumber = Tempcarnumtxt.Text;
            string Vin = vintxt.Text;
            string date = buydate.Text;
            string employeename = Employeenametxt.Text;
            cars.UpdateCar(CarID, Carname, Vin, TempNumber, Buyername, employeename, date);
            Response.Redirect("/MuhanadListCars");
        }
        protected void GetCar()
        {
            string CarID = (string)(this.RouteData.Values["ID"]);
            Cars cars = new Cars();
            cars.getCarDeatils(CarID);
            Carnametxt.Text = cars.CarName;
            DateTime da = DateTime.Parse(cars.Date);
            buydate.Text = da.ToString("yyyy-MM-dd");
            Purchasernametxt.Text = cars.BuyerName;
            vintxt.Text = cars.VIN;
            Tempcarnumtxt.Text = cars.TempCarNumber;
            Employeenametxt.Text = cars.EmployeeName;
        }
    }
}