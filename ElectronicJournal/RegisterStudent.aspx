<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterStudent.aspx.cs" Inherits="ElectronicJournal.RegisterStudent" %>

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

            <asp:DropDownList ID="ClassDropDownList" runat="server">
                <asp:ListItem Selected="True" Hidden="True">Choose Class</asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
            </asp:DropDownList>

            <asp:RequiredFieldValidator ID="ClassRequiredFieldValidator" ControlToValidate="ClassDropDownList" runat="server" ErrorMessage="Class must be filled in" Text="*"></asp:RequiredFieldValidator>

            <asp:TextBox ID="PhoneTextBox" runat="server" PlaceHolder="Phone:" MaxLength="30"></asp:TextBox>

            <asp:RequiredFieldValidator ID="PhoneRequiredFieldValidator" ControlToValidate="PhoneTextBox" runat="server" ErrorMessage="Phone must be filled in" Text="*"></asp:RequiredFieldValidator>

            <asp:TextBox ID="EMailTextBox" runat="server" PlaceHolder="EMail:" MaxLength="30"></asp:TextBox>

            <asp:RequiredFieldValidator ID="EMailRequiredFieldValidator" ControlToValidate="EMailTextBox" runat="server" ErrorMessage="EMail must be filled in" Text="*"></asp:RequiredFieldValidator>

            <asp:RegularExpressionValidator ID="EMailRegularExpressionValidator" ControlToValidate="EMailTextBox" runat="server" ErrorMessage="The EMail must be valid" Text="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

            <asp:TextBox ID="PasswordTextBox" runat="server" PlaceHolder="Password:" MaxLength="30" Type="password"></asp:TextBox>

            <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" ControlToValidate="PasswordTextBox" runat="server" ErrorMessage="Password must be filled in" Text="*"></asp:RequiredFieldValidator>

            <div class="formFooter">
                <asp:ValidationSummary ID="ValidationSummary" runat="server" CssClass="validator"></asp:ValidationSummary>
                <asp:Button ID="StudentRegisterButton" runat="server" Text="Register" OnClick="StudentRegisterButton_Click" />
                &nbsp;<asp:Button ID="StudentCancelButton" runat="server" Text="Cancel" OnClick="StudentCancelButton_Click" CausesValidation="false" />
            </div>
        </div>
    </form>
</body>
</html>
