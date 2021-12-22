<%@ Page Title="" Language="C#" MasterPageFile="~/GoldenSite.Master" AutoEventWireup="true" CodeBehind="GoldenListCars.aspx.cs" Inherits="Cars_System.Pages.GoldenCars.GoldenListCars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>List Cars</h1>
    <hr />
    

    <table id="filtertable" class="table table-striped">
        <thead class="table-light">
            <tr>
                <th style="text-align: center !important;">Car ID</th>
                <th style="text-align: center !important;">Car Name</th>
                <th style="text-align: center !important;">VIN</th>
                <th style="text-align: center !important;">Temp Car Number</th>
                <th style="text-align: center !important;">Buyer Name</th>
                <th style="text-align: center !important;">Employee Name</th>
                <th style="text-align: center !important;">Contract Number</th>
                <th style="text-align: center !important;">Company ID</th>
                <th style="text-align: center !important;">Date</th>
                <th style="text-align: center !important;">More Options</th>
            </tr>
        </thead>
       
        <tbody>
  <asp:Repeater ID="rptCars" runat="server" OnItemDataBound="rptCars_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("CarID")%></td>
                        <td><%#Eval("CarName")%></td>
                        <td><%#Eval("VIN")%></td>
                        <td><%#Eval("TempCarNumber")%></td>
                        <td><%#Eval("BuyerName")%></td>
                        <%--<td><%#GetRoleName(Eval("RoleID"))%></td>--%>
                        <td><%#Eval("EmployeeName")%></td>
                        <td><%#Eval("ContractNumber")%></td>
                        <td><%#Eval("CompanyID")%></td>
                        <td><%#Eval("Date")%></td>
                        <%--<td><%#((bool)(Eval("IsLocked"))==true?"<i class='fa fa-check'></i>":"<i class='fa fa-times'></i>") %></td>--%>
                       
                           <%-- <td> <asp:LinkButton runat="server" ID="UnlockAccountbtn" OnClick="UnlockAccountbtn_Click" CssClass=" btn btn-dark" Text="Unlock"  CommandArgument='<%#Eval("UserID") %>'/></td>--%>
                        <td>
                            <div class="btn-group" role="group" aria-label="Button group with nested dropdown">
                                <div class="btn-group" role="group">
                                  <button type="button" class="btn btn-dark dropdown-toggle-split" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" style="right:0px !important;">
                                                                    <span class="sr-only">More</span>
                                                                    More
                                                                </button>
                                    <div class="dropdown-menu" aria-labelledby="btnGroupDrop1">
                                        <%--<asp:LinkButton runat="server" ID="Changepassbtn" class="dropdown-item" CommandArgument='<%#Eval("UserID") %>' OnClick="Changepassbtn_Click">Change Password</asp:LinkButton>--%>
                                        <asp:LinkButton runat="server" ID="Editbtn" class="dropdown-item" CommandArgument='<%#Eval("CarID") %>' OnClick="Editbtn_Click">Edit</asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="Deletebtn" class="dropdown-item" CommandArgument='<%#Eval("CarID") %>' OnClick="Deletebtn_Click">Delete</asp:LinkButton>
                                         <asp:LinkButton runat="server" ID="Printbtn" class="dropdown-item" CommandArgument='<%#Eval("CarID") %>' OnClick="Printbtn_Click">Print</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </tbody>
    </table>
</asp:Content>
