<%@ Page Title="" Language="C#" MasterPageFile="~/GoldenSite.Master" AutoEventWireup="true" CodeBehind="GoldenListEmployees.aspx.cs" Inherits="Cars_System.Pages.GoldenCars.GoldenListEmployees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <h1>List Employees</h1>
    <hr />
    

    <table id="filtertable" class="table table-striped">
        <thead class="table-light">
            <tr>
                <th style="text-align: center !important;">User ID</th>
                <th style="text-align: center !important;">First name</th>
                <th style="text-align: center !important;">Last name</th>
                <th style="text-align: center !important;">Email</th>
                <th style="text-align: center !important;">Date of Birth</th>
                <th style="text-align: center !important;">Role</th>
                <th style="text-align: center !important;">Phone</th>
                <th style="text-align: center !important;">Locked</th>
                <th style="text-align: center !important;">Unlock Account</th>
                <th style="text-align: center !important;">More Options</th>
            </tr>
        </thead>
        <tbody>
  <asp:Repeater ID="rptAccounts" runat="server" OnItemDataBound="rptAccounts_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("UserID")%></td>
                        <td><%#Eval("Fname")%></td>
                        <td><%#Eval("Lname")%></td>
                        <td><%#Eval("Email")%></td>
                        <td><%#Eval("DateofBirth")%></td>
                        <td><%#GetRoleName(Eval("RoleID"))%></td>
                        <td><%#Eval("PhoneNumber")%></td>
                        <td><%#((bool)(Eval("IsLocked"))==true?"<i class='fa fa-check'></i>":"<i class='fa fa-times'></i>") %></td>
                        <td>
                            <asp:LinkButton runat="server" ID="UnlockAccountbtn" OnClick="UnlockAccountbtn_Click" CssClass=" btn btn-dark" Text="Unlock"  CommandArgument='<%#Eval("UserID") %>'/></td>
                        <td>
                            <div class="btn-group" role="group" aria-label="Button group with nested dropdown">
                                <div class="btn-group" role="group">
                                  <button type="button" class="btn btn-dark dropdown-toggle-split" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" style="right:0px !important;">
                                                                    <span class="sr-only">More</span>
                                                                    More
                                                                </button>
                                    <div class="dropdown-menu" aria-labelledby="btnGroupDrop1">
                                        <asp:LinkButton runat="server" ID="Changepassbtn" class="dropdown-item" CommandArgument='<%#Eval("UserID") %>' OnClick="Changepassbtn_Click">Change Password</asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="Editbtn" class="dropdown-item" CommandArgument='<%#Eval("UserID") %>' OnClick="Editbtn_Click">Edit</asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="Deletebtn" class="dropdown-item" CommandArgument='<%#Eval("UserID") %>' OnClick="Deletebtn_Click">Delete</asp:LinkButton>
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
