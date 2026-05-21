<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherDefault.aspx.cs" Inherits="ElectronicJournal.TeacherDefault1" MasterPageFile="~/TeacherSite.Master" %>

<%@ Register src="LogOutButton.ascx" tagname="LogOutButton" tagprefix="uc1" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolder" class="form"
runat="server">
    <uc1:LogOutButton ID="LogOutButton1" runat="server" />
</asp:Content>
