<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentDefault.aspx.cs" Inherits="ElectronicJournal.StudentDefault" MasterPageFile="~/StudentSite.Master" %>

<%@ Register src="LogOutButton.ascx" tagname="LogOutButton" tagprefix="uc1" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolder"
runat="server">
    <uc1:LogOutButton ID="LogOutButton1" runat="server" />
</asp:Content>
