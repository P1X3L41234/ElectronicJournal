<%@ Page Title="" Language="C#" MasterPageFile="~/StudentSite.Master" AutoEventWireup="true" CodeBehind="StudentMarks.aspx.cs" Inherits="ElectronicJournal.StudentMarks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:XmlDataSource ID="MarksXmlDataSource" runat="server"></asp:XmlDataSource>
    <asp:GridView ID="MarksGridView" runat="server" AutoGenerateColumns="False" DataSourceID="MarksXmlDataSource" Width="100%" CssClass="gridview" CellPadding="0" CellSpacing="0" GridLines="None">
        <Columns>
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
            <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" />
            <asp:BoundField DataField="Mark" HeaderText="Mark" SortExpression="Mark" />
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
        </Columns>
    </asp:GridView>
</asp:Content>
