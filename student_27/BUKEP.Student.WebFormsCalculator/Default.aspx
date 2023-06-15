<%@ Page Title="Calculator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BUKEP.Student.WebFormsCalculator._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="calculator">
    <h1 class="titel-web-api">Калькулятор</h1>
        <p class="inputting-expression">
            <input type ="hidden" value ="null" id="idResult" runat="server" readonly="readonly"/>
            <input class ="output" value ="0" id="expression" runat="server" type="text" readonly="readonly"/>
        </p>
        <p class="data-base-controller">
            <asp:Button class="buttons" ID="ButtonToSaveResults" runat="server" Height="50px" Text="M" Width="50px" OnClick ="btnSavingResult_Click"/>
            <asp:Button class="buttons" ID="ButtonForPreviousResult" runat="server" Height="50px" Text="<S" Width="50px" OnClick ="btnOutputOfPreviousResult_Click" />
            <asp:Button class ="buttons" ID="ButtonForFollowingResult" runat="server" Height="50px" Text="S>" Width="50px" OnClick ="btnOutputOfFollowingResult_Click"/>
            <asp:Button class ="buttons" ID="buttonToClearAllCalculationResults" runat="server" Height="50px" Text="MC" Width="50px" OnClick ="btnCleanUpHistory_Click"/>
        </p>
        <p class="firs-row-button">
            <asp:Button class="buttons" ID="ClearingButton" runat="server" Height="50px" Text="C" Width="50px" OnClick ="btnDeleteExpression_Click"/>
            <asp:Button class ="buttons" ID="ButtonDeleteItem" runat="server" Height="50px" Text="⌫" Width="50px" OnClick ="btnDeleteItem_Click" />
        </p>
        <p class="second-row-button">
            <asp:Button class ="buttons" ID="ButtonOfDegree" runat="server" Height="50px" Text="^" Width="50px" OnClick ="btnAddElement_Click" />
            <asp:Button class ="buttons" ID="OpenBracketButton" runat="server" Height="50px" Text="(" Width="50px" OnClick ="btnAddElement_Click" />
            <asp:Button class ="buttons" ID="ClosingBracketButton" runat="server" Height="50px" Text=")" Width="50px" OnClick ="btnAddElement_Click" />
            <asp:Button class ="buttons" ID="DividingButton" runat="server" Height="50px" Text="÷" Width="50px" OnClick ="btnAddElement_Click" />
        </p>
        <p class="third-row-button">
            <asp:Button class ="buttons" ID="ButtonWithNumberSeven" runat="server" Height="50px" Text="7" Width="50px" OnClick ="btnAddElement_Click" />
            <asp:Button class ="buttons" ID="ButtonWithNumberEight" runat="server" Height="50px" Text="8" Width="50px" OnClick ="btnAddElement_Click" />
            <asp:Button class ="buttons" ID="ButtonWithNumberNine" runat="server" Height="50px" Text="9" Width="50px" OnClick ="btnAddElement_Click" />
            <asp:Button class ="buttons" ID="ButtonMultiply" runat="server" Height="50px" Text="×" Width="50px" OnClick ="btnAddElement_Click" />
        </p>
        <p class="fourth-row-button">
            <asp:Button class ="buttons" ID="ButtonWithNumberSix" runat="server" Height="50px" Text="6" Width="50px" OnClick ="btnAddElement_Click" />
            <asp:Button class ="buttons" ID="ButtonWithNumberFive" runat="server" Height="50px" Text="5" Width="50px" OnClick ="btnAddElement_Click" />
            <asp:Button class ="buttons" ID="ButtonWithNumberFour" runat="server" Height="50px" Text="4" Width="50px" OnClick ="btnAddElement_Click"/>
            <asp:Button class ="buttons" ID="ButtonSubtractions" runat="server" Height="50px" Text="-" Width="50px" OnClick ="btnAddElement_Click"/>
        </p>
        <p class="firth-row-button">
            <asp:Button class ="buttons" ID="ButtonWithNumberThree" runat="server" Height="50px" Text="3" Width="50px" OnClick ="btnAddElement_Click"/>
            <asp:Button class ="buttons" ID="ButtonWithNumberTwo" runat="server" Height="50px" Text="2" Width="50px" OnClick ="btnAddElement_Click"/>
            <asp:Button class ="buttons" ID="ButtonWithNumberOne" runat="server" Height="50px" Text="1" Width="50px" OnClick ="btnAddElement_Click" />
            <asp:Button class ="buttons" ID="ButtonAddingUp" runat="server" Height="50px" Text="+" Width="50px" OnClick ="btnAddElement_Click"/>
        </p>
        <p class="sixth-row-button">
            <asp:Button class ="buttons" ID="ButtonWithNumber" runat="server" Height="50px" Text="0" Width="50px" OnClick ="btnAddElement_Click"/>
            <asp:Button class ="buttons" ID="ButtonWithComma" runat="server" Height="50px" Text="," Width="50px" OnClick ="btnAddElement_Click"/>
            <asp:Button class ="buttons" ID="ButtonEqual" runat="server" Height="50px" Text="=" Width="50px" OnClick ="btnCalculateExpression_Click"/>
        </p>
    </div>

</asp:Content>
