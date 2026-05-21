<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterTeacher.aspx.cs" Inherits="ElectronicJournal.RegisterTeacher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title class="title">Registration</title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="form">
            <asp:TextBox ID="FirstNameTextBox" runat="server" PlaceHolder="First Name:" MaxLength="30"></asp:TextBox>

            <asp:RequiredFieldValidator ID="FirstNameRequiredFieldValidator" ControlToValidate="FirstNameTextBox" runat="server" ErrorMessage="First Name must be filled in" Text="*"></asp:RequiredFieldValidator>

            <asp:TextBox ID="LastNameTextBox" runat="server" PlaceHolder="Last Name:" MaxLength="30"></asp:TextBox>

            <asp:RequiredFieldValidator ID="LastNameRequiredFieldValidator" ControlToValidate="LastNameTextBox" runat="server" ErrorMessage="Last Name must be filled in" Text="*"></asp:RequiredFieldValidator>

            <asp:DropDownList ID="SchoolDropDownList" runat="server">
                <asp:ListItem Selected="True" Hidden="True">Choose School</asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
            </asp:DropDownList>

            <asp:RequiredFieldValidator ID="SchoolFieldValidator" ControlToValidate="SchoolDropDownList" runat="server" ErrorMessage="School must be filled in" Text="*"></asp:RequiredFieldValidator>

            <asp:DropDownList ID="SubjectDropDownList" runat="server">
                <asp:ListItem Selected="True" Hidden="True">Choose Subject</asp:ListItem>
                <asp:ListItem>Математика</asp:ListItem>
                <asp:ListItem>Русский язык</asp:ListItem>
                <asp:ListItem>Литература</asp:ListItem>
                <asp:ListItem>Химия</asp:ListItem>
                <asp:ListItem>Биология</asp:ListItem>
                <asp:ListItem>Иностранный язык</asp:ListItem>
                <asp:ListItem>Физкультура</asp:ListItem>
            </asp:DropDownList>

            <asp:RequiredFieldValidator ID="SubjectRequiredFieldValidator" ControlToValidate="SubjectDropDownList" runat="server" ErrorMessage="Subject must be filled in" Text="*"></asp:RequiredFieldValidator>

            <asp:TextBox ID="PhoneTextBox" runat="server" PlaceHolder="Phone:" MaxLength="30"></asp:TextBox>

            <asp:RequiredFieldValidator ID="PhoneRequiredFieldValidator" ControlToValidate="PhoneTextBox" runat="server" ErrorMessage="Phone must be filled in" Text="*"></asp:RequiredFieldValidator>

            <asp:TextBox ID="EMailTextBox" runat="server" PlaceHolder="EMail:" MaxLength="30"></asp:TextBox>

            <asp:RequiredFieldValidator ID="EMailRequiredFieldValidator" ControlToValidate="EMailTextBox" runat="server" ErrorMessage="EMail must be filled in" Text="*"></asp:RequiredFieldValidator>

            <asp:RegularExpressionValidator ID="EMailRegularExpressionValidator" ControlToValidate="EMailTextBox" runat="server" ErrorMessage="The EMail must be valid" Text="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

            <asp:TextBox ID="PasswordTextBox" runat="server" PlaceHolder="Password:" MaxLength="30" Type="password"></asp:TextBox>

            <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" ControlToValidate="PasswordTextBox" runat="server" ErrorMessage="Password must be filled in" Text="*"></asp:RequiredFieldValidator>

            <div class="formFooter">
                <asp:ValidationSummary ID="ValidationSummary" runat="server" CssClass="validator"></asp:ValidationSummary>
                <asp:Button ID="TeacherRegisterButton" runat="server" Text="Register" OnClick="TeacherRegisterButton_Click" />
                &nbsp;<asp:Button ID="TeacherCancelButton" runat="server" Text="Cancel" OnClick="TeacherCancelButton_Click" CausesValidation="false" />
            </div>
        </div>
    </form>
</body>
</html>
