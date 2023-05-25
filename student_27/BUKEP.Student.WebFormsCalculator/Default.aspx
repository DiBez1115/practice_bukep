<%@ Page Title="Calculator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BUKEP.Student.WebFormsCalculator._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="calculator">
    <h1 class="titel-web-api">Калькулятор</h1>
        <p class="inputting-expression">
            <input class ="output" value ="0" id="expression" runat="server" type="text" readonly="readonly"/>
        </p>
        <p class="firs-row-button">
            <asp:Button class="buttons" ID="Button1" runat="server" Height="50px" Text="C" Width="50px" OnClick ="DeleteExpression"/>
            <asp:Button class ="buttons" ID="Button2" runat="server" Height="50px" Text="⌫" Width="50px" OnClick ="DelitItem" />
        </p>
        <p class="second-row-button">
            <asp:Button class ="buttons" ID="Button3" runat="server" Height="50px" Text="^" Width="50px" OnClick ="AddElement" />
            <asp:Button class ="buttons" ID="Button4" runat="server" Height="50px" Text="(" Width="50px" OnClick ="AddElement" />
            <asp:Button class ="buttons" ID="Button5" runat="server" Height="50px" Text=")" Width="50px" OnClick ="AddElement" />
            <asp:Button class ="buttons" ID="Button6" runat="server" Height="50px" Text="÷" Width="50px" OnClick ="AddElement" />
        </p>
        <p class="third-row-button">
            <asp:Button class ="buttons" ID="Button7" runat="server" Height="50px" Text="7" Width="50px" OnClick ="AddElement" />
            <asp:Button class ="buttons" ID="Button8" runat="server" Height="50px" Text="8" Width="50px" OnClick ="AddElement" />
            <asp:Button class ="buttons" ID="Button9" runat="server" Height="50px" Text="9" Width="50px" OnClick ="AddElement" />
            <asp:Button class ="buttons" ID="Button10" runat="server" Height="50px" Text="×" Width="50px" OnClick ="AddElement" />
        </p>
        <p class="fourth-row-button">
            <asp:Button class ="buttons" ID="Button11" runat="server" Height="50px" Text="6" Width="50px" OnClick ="AddElement" />
            <asp:Button class ="buttons" ID="Button12" runat="server" Height="50px" Text="5" Width="50px" OnClick ="AddElement" />
            <asp:Button class ="buttons" ID="Button13" runat="server" Height="50px" Text="4" Width="50px" OnClick ="AddElement"/>
            <asp:Button class ="buttons" ID="Button14" runat="server" Height="50px" Text="-" Width="50px" OnClick ="AddElement"/>
        </p>
        <p class="firth-row-button">
            <asp:Button class ="buttons" ID="Button15" runat="server" Height="50px" Text="3" Width="50px" OnClick ="AddElement"/>
            <asp:Button class ="buttons" ID="Button16" runat="server" Height="50px" Text="2" Width="50px" OnClick ="AddElement"/>
            <asp:Button class ="buttons" ID="Button17" runat="server" Height="50px" Text="1" Width="50px" OnClick ="AddElement" />
            <asp:Button class ="buttons" ID="Button18" runat="server" Height="50px" Text="+" Width="50px" OnClick ="AddElement"/>
        </p>
        <p class="fourth-row-button">
            <asp:Button class ="buttons" ID="Button19" runat="server" Height="50px" Text="0" Width="50px" OnClick ="AddElement"/>
            <asp:Button class ="buttons" ID="Button20" runat="server" Height="50px" Text="," Width="50px" OnClick ="AddElement"/>
            <asp:Button class ="buttons" ID="Button21" runat="server" Height="50px" Text="=" Width="50px" OnClick ="CalculateExpression"/>
        </p>
    </div>

</asp:Content>
