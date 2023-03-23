<%@ Page Title="AddItemSL" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddItemSL.aspx.cs" Inherits="ShoppingListWebApp.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <link rel="stylesheet" href="AddItemSL.css">
    </head>
    <body>
        <main>
            <h2>Shopping List</h2>
            <form action="">
                <input type="text" placeholder="Item">
                <input type="text" placeholder="Quantity">
                <input type="submit" value="Add To List" class="submit">
            </form>
            <section class="list">
                <h3>Total Items:</h3>
            </section>
        </main>

        <script src="./script.js"></script>

    </body>
    </html>

</asp:Content>
