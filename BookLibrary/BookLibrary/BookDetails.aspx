<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="BookLibrary.BookDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2> <asp:Label ID="lblLN" runat="server" Text=""></asp:Label></h2>
    <table>
        <tr>
    <td>
        <asp:Label ID="Label1" runat="server" Text="ISBN"></asp:Label>
    </td>
    <td colspan="2">
        <asp:TextBox ID="txtIsbn" runat="server" TextMode="Number" Width="177px" >
           

        </asp:TextBox>


          <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

    </td>
</tr>
        <tr>
    <td>
        <asp:Label ID="Label2" runat="server" Text="Title"></asp:Label>
    </td>
    <td colspan="2">
        <asp:TextBox ID="txtTitle" runat="server" Width="178px"></asp:TextBox>
    </td>
</tr>
        <tr>
    <td>
        <asp:Label ID="Label3" runat="server" Text="Author"></asp:Label>
    </td>
    <td colspan="2">
        <asp:TextBox ID="txtAuthor" runat="server" Height="22px" Width="180px"></asp:TextBox>
    </td>
</tr>
        <tr>
    <td>
        Publiish date :</td>
    <td colspan="2">
        <asp:TextBox ID="txtPublishDate" runat="server" TextMode="Date" Height="29px" Width="183px"></asp:TextBox>
    </td>
</tr>
        <tr>
    <td>
        Price</td>
    <td colspan="2">
        <asp:TextBox ID="txtPrice" runat="server" Width="179px"></asp:TextBox>
                 <asp:Label ID="priceError" runat="server" ForeColor="Red"></asp:Label>

    </td>
</tr>
        <tr>
    <td>
        <asp:Label ID="Label6" runat="server" Text="Publish"></asp:Label>
    </td>
    <td colspan="2">
        <asp:CheckBox ID="txtPublish" runat="server"></asp:CheckBox>

      <asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label>


          <div runat="server" id="Div1" class="alertBox" Visible="false"></div>


    </td>

</tr>
    </table>

    <br />
    <asp:Button  id="save"
    Text="Save"
    OnClick="SaveBtn_Click" 
    runat="server"/>

     <asp:Button  id="cancel"
 Text="Cancel"
 OnClick="CancelBtn_Click" 
 runat="server"/>
  

</asp:Content>
