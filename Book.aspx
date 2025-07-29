<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="BookLibrary.BookDetails" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Books List</h2>
    <asp:GridView ID="GridViewBooks" runat="server" AutoGenerateColumns="False" DataKeyNames="BookID"
        OnRowEditing="GridViewBooks_RowEditing" OnRowDeleting="GridViewBooks_RowDeleting">
        <Columns>
            <asp:BoundField DataField="BookID" HeaderText="Book ID" ReadOnly="True" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Author" HeaderText="Author" />
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnAddNew" runat="server" Text="Add New Book" PostBackUrl="~/BookDetails.aspx" />
</asp:Content>
