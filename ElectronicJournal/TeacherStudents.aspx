<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="TeacherStudents.aspx.cs" Inherits="ElectronicJournal.TeacherStudents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:XmlDataSource ID="StudentsXmlDataSource" runat="server"></asp:XmlDataSource>
    <asp:GridView ID="StudentsGridView" runat="server" AutoGenerateColumns="False" DataSourceID="StudentsXmlDataSource" Width="100%" CssClass="gridview" CellPadding="0" CellSpacing="0" GridLines="None">
        <Columns>
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
            <asp:TemplateField HeaderText="Mark">
                <ItemTemplate>
                    <asp:DropDownList ID="MarkDropDownList" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="SaveButton" runat="server" Text="Save" OnClick="SaveButton_Click" Width="15%" />
</asp:Content>
