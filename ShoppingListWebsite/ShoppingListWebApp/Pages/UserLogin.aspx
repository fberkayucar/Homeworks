<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="ShoppingListWebApp.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <head>
        <meta charset="UTF-8">
        <link rel="stylesheet" href="Userlogin.css">
    </head>
    <body>
        <div class="log-form">
            <h2>Enter Username</h2>
            <form runat="server">
                <asp:TextBox ID="Userlogintxt" runat="server" name="Userlogintxt" title="username" placeholder="username" />
                <button type="submit" class="btn" onclick="Btn" >Login</button>
            </form>
        </div>
    </body>
</asp:Content>
