<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ItemAdd.aspx.cs" Inherits="ShoppingListWebApp.Pages.ItemAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <head>
        <meta charset="UTF-8">
        <link rel="stylesheet" href="ItemAdd.css">

        <div id="docwrap">
            <section id="list-holder">
                <h1>Item List</h1>
                <div id="adder">
                    <p>
                        <strong>Add an item:</strong>
                        <input type="text" id="new-item-text" />
                        <button id="add-button">Add to list</button>
                    </p>
                </div>
                <ul id="list">
                </ul>
            </section>
        </div>
</asp:Content>
