<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogInTeacher.aspx.cs" Inherits="ElectronicJournal.LogInTeacher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title class="title">Log In</title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="form">

            <asp:TextBox ID="EMailTextBox" runat="server" PlaceHolder="EMail:" MaxLength="30"></asp:TextBox>

            <asp:RequiredFieldValidator ID="EMailRequiredFieldValidator" ControlToValidate="EMailTextBox" runat="server" ErrorMessage="EMail must be filled in" Text="*"></asp:RequiredFieldValidator>

            <asp:RegularExpressionValidator ID="EMailRegularExpressionValidator" ControlToValidate="EMailTextBox" runat="server" ErrorMessage="The EMail must be valid" Text="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

            <asp:TextBox ID="PasswordTextBox" runat="server" PlaceHolder="Password:" MaxLength="30" Type="password"></asp:TextBox>

            <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" ControlToValidate="PasswordTextBox" runat="server" ErrorMessage="Password must be filled in" Text="*"></asp:RequiredFieldValidator>

            <div class="formFooter">
                <asp:ValidationSummary ID="ValidationSummary" runat="server" CssClass="validator"></asp:ValidationSummary>
                <asp:Button ID="TeacherLogInButton" runat="server" Text="Log In" OnClick="TeacherLogInButton_Click" />
                &nbsp;<asp:Button ID="TeacherCancelButton" runat="server" Text="Cancel" OnClick="TeacherCancelButton_Click" CausesValidation="false" />
            </div>
        </div>
    </form>
</body>
</html>
