<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="BookLibrary.Books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Books</h2>
    <br />
   <asp:Label ID="Label1" runat="server" ></asp:Label>
    <asp:GridView ID="datatable" runat="server" AutoGenerateColumns="False" style="margin-right: 29px; margin-top: 0px; margin-bottom: 7px;" OnSelectedIndexChanged="displaybuttons" BackColor="#0099FF"  Width="901px">
        <AlternatingRowStyle BackColor="#f2f2f2" />
        <HeaderStyle ForeColor="White" />
    <RowStyle BackColor="White" />
        <Columns>
              
          <asp:CommandField ShowSelectButton="True"  />
            <asp:BoundField DataField="ISBN" HeaderText="ISBN"   >
            </asp:BoundField>
            <asp:BoundField DataField="Title" HeaderText="Title"  />
            <asp:BoundField DataField="Author" HeaderText="Author" />
                        <asp:BoundField DataField="PublishDate" HeaderText="PublishDate" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                                    <asp:BoundField DataField="Publish" HeaderText="Publish"  >

<ControlStyle BackColor="White"></ControlStyle>
            </asp:BoundField>



         



        </Columns>
    </asp:GridView>
  
   <asp:Button ID="add"
           Text="Add"
           OnClick="AddBtn_Click" 
           runat="server"  />
    
     <asp:Button ID="edit" Text="Edit" OnClick="EditBtn_Click" runat="server" Enabled="false" />
    <asp:Button ID="delete" Text="Delete" OnClick="DeleteBtn_Click" runat="server" Enabled="false" />

</asp:Content>
