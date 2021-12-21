using System.Web.Routing;

namespace Cars_System.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            RouteTable.Routes.MapPageRoute("Login", "Login", "~/Pages/Login.aspx");
            RouteTable.Routes.MapPageRoute("Muhanad Home", "Muhanadhome", "~/Pages/MuhanadCars/Muhanadhome.aspx");
            RouteTable.Routes.MapPageRoute("Rukn Home", "Ruknhome", "~/Pages/Rukn/Ruknhome.aspx");
            RouteTable.Routes.MapPageRoute("Golden Home", "Goldenhome", "~/Pages/GoldenCars/Goldenhome.aspx");
            RouteTable.Routes.MapPageRoute("Luxury Home", "Luxuryhome", "~/Pages/LuxuryCars/Luxuryhome.aspx");

            
            RouteTable.Routes.MapPageRoute("Default", "", "~/Pages/Login.aspx");

            //Muhanad Pages
            RouteTable.Routes.MapPageRoute("Add Cars Muhanad","MuhanadAddCars", "~/Pages/MuhanadCars/MuhanadAddCars.aspx");
            RouteTable.Routes.MapPageRoute("List Cars Muhanad","MuhanadListCars", "~/Pages/MuhanadCars/MuhanadListCars.aspx");
            RouteTable.Routes.MapPageRoute("Edit Cars Muhanad","MuhanadEditCar/{ID}", "~/Pages/MuhanadCars/MuhanadEditCar.aspx");

            RouteTable.Routes.MapPageRoute("Add Muhanad Employee","AddMuhanadEmployee", "~/Pages/MuhanadCars/MuhanadAddEmployee.aspx");
            RouteTable.Routes.MapPageRoute("List Muhanad Employee","ListMuhanadEmployees", "~/Pages/MuhanadCars/MuhanadListEmployees.aspx");
            RouteTable.Routes.MapPageRoute("Edit Muhanad Employees","EditMuhanadEmployees/{ID}", "~/Pages/MuhanadCars/MuhanadEditEmployee.aspx");

            //Golden Pages                            
            RouteTable.Routes.MapPageRoute("Add Cars  Golden", "GoldenAddCars", "~/Pages/GoldenCars/GoldenAddCars.aspx");
            RouteTable.Routes.MapPageRoute("Edit Cars Golden", "GoldenEditCar/{ID}", "~/Pages/GoldenCars/GoldenEditCar.aspx");
            RouteTable.Routes.MapPageRoute("List Cars Golden", "GoldenListCars", "~/Pages/GoldenCars/GoldenListCars.aspx");

            RouteTable.Routes.MapPageRoute("Add Golden Employee",  "AddGoldenEmployee", "~/Pages/GoldenCars/GoldenAddEmployee.aspx");
            RouteTable.Routes.MapPageRoute("List Golden Employee", "ListGoldenEmployees", "~/Pages/GoldenCars/GoldenListEmployees.aspx");
            RouteTable.Routes.MapPageRoute("Edit Golden Employees","EditGoldenEmployees/{ID}", "~/Pages/GoldenCars/GoldenEditEmployee.aspx");

            //Luxury Pages                            
            RouteTable.Routes.MapPageRoute("Add Cars  Luxury", "GoldenAddCars", "~/Pages/GoldenCars/GoldenAddCars.aspx");
            RouteTable.Routes.MapPageRoute("Edit Cars Luxury", "GoldenEditCar/{ID}", "~/Pages/GoldenCars/GoldenEditCar.aspx");
            RouteTable.Routes.MapPageRoute("List Cars Luxury", "GoldenListCars", "~/Pages/GoldenCars/GoldenListCars.aspx");

            RouteTable.Routes.MapPageRoute("Add Luxury Employee","AddLuxuryEmployee", "~/Pages/LuxuryCars/LuxuryAddEmployee.aspx");
            RouteTable.Routes.MapPageRoute("List Luxury Employee","ListLuxuryEmployees", "~/Pages/LuxuryCars/LuxuryListEmployees.aspx");
            RouteTable.Routes.MapPageRoute("Edit Luxury Employees","EditLuxuryEmployees/{ID}", "~/Pages/LuxuryCars/LuxuryEditEmployee.aspx");


            //RouteTable.Routes.MapPageRoute("List Accounts", "ListAccounts", "~/UserControl/Templates/Accounts/ListAccounts.aspx");
            //RouteTable.Routes.MapPageRoute("Edit Accounts", "EditAccounts/{ID}", "~/UserControl/Templates/Accounts/EditAccounts.aspx");
            //
            //RouteTable.Routes.MapPageRoute("Change pass", "changepass/{ID}", "~/UserControl/Templates/Accounts/ChangepasswordAdmin.aspx");

            //RouteTable.Routes.MapPageRoute("List Products", "ListProducts", "~/UserControl/Templates/Products/ListProducts.aspx");
            //RouteTable.Routes.MapPageRoute("Edit Products", "EditProducts/{ID}", "~/UserControl/Templates/Products/EditProducts.aspx");
            //RouteTable.Routes.MapPageRoute("Add Products", "AddProducts", "~/UserControl/Templates/Products/AddProducts.aspx");
            //RouteTable.Routes.MapPageRoute("More info products", "Moreinfoproduct/{ID}", "~/UserControl/Templates/Products/MoreInformationProduct.aspx");

            //RouteTable.Routes.MapPageRoute("Sent Enquiries", "SentEnquiries", "~/UserControl/Templates/Enquiries/SentEnquiry.aspx");
            //RouteTable.Routes.MapPageRoute("Add Enquiries", "AddEnquiry", "~/UserControl/Templates/Enquiries/AddEnquiry.aspx");
            //RouteTable.Routes.MapPageRoute("Edit Enquiries", "EditEnquiry/{ID}", "~/UserControl/Templates/Enquiries/EditEnquiry.aspx");
            //RouteTable.Routes.MapPageRoute("List Enquiries", "ListEnquiries", "~/UserControl/Templates/Enquiries/ListEnquiries.aspx");
            //RouteTable.Routes.MapPageRoute("More info", "Moreinfo/{ID}", "~/UserControl/Templates/Enquiries/MoreinfoEnquiry.aspx");

            //RouteTable.Routes.MapPageRoute("Add Needed Products", "AddAdminEnquiry", "~/UserControl/Templates/Enquiries/AddAdminEnquiry.aspx");
            //RouteTable.Routes.MapPageRoute("Needed Products", "NeededProducts", "~/UserControl/Templates/Products/NeededProducts.aspx");
            //RouteTable.Routes.MapPageRoute("Needed Products More info", "NeededProductsMoreinfo/{ID}", "~/UserControl/Templates/Products/NeededProductsMoreinfo.aspx");
            //RouteTable.Routes.MapPageRoute("Edit Needed Prouducts", "EditAdminEnquiry/{ID}", "~/UserControl/Templates/Enquiries/EditAdminEnquiry.aspx");

            //RouteTable.Routes.MapPageRoute("Change my pass", "changemypass/{ID}", "~/UserControl/Templates/User/ChangeMyPassword.aspx");

            //RouteTable.Routes.MapPageRoute("Add Currency", "AddCurrency", "~/UserControl/Templates/Currencies/AddCurrency.aspx");
            //RouteTable.Routes.MapPageRoute("Edit Currency", "EditCurrency/{ID}", "~/UserControl/Templates/Currencies/EditCurrency.aspx");
            //RouteTable.Routes.MapPageRoute("List Currencies", "ListCurrencies", "~/UserControl/Templates/Currencies/ListCurrencies.aspx");


            RouteTable.Routes.MapPageRoute("Privacy and Cookies", "Privacy", "~/UserControl/Templates/User/Privacy.aspx");
        }
    }
}