<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: medium;
        }
        .auto-style2 {
            font-size: xx-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Animal] WHERE [AnimalID] = @AnimalID" InsertCommand="INSERT INTO [Animal] ([AnimalID], [AnimalType], [Nickname], [Age], [Gender], [StaffID]) VALUES (@AnimalID, @AnimalType, @Nickname, @Age, @Gender, @StaffID)" SelectCommand="SELECT * FROM [Animal]" UpdateCommand="UPDATE [Animal] SET [AnimalType] = @AnimalType, [Nickname] = @Nickname, [Age] = @Age, [Gender] = @Gender, [StaffID] = @StaffID WHERE [AnimalID] = @AnimalID">
            <DeleteParameters>
                <asp:Parameter Name="AnimalID" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="AnimalID" Type="String" />
                <asp:Parameter Name="AnimalType" Type="String" />
                <asp:Parameter Name="Nickname" Type="String" />
                <asp:Parameter Name="Age" Type="Double" />
                <asp:Parameter Name="Gender" Type="String" />
                <asp:Parameter Name="StaffID" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="AnimalType" Type="String" />
                <asp:Parameter Name="Nickname" Type="String" />
                <asp:Parameter Name="Age" Type="Double" />
                <asp:Parameter Name="Gender" Type="String" />
                <asp:Parameter Name="StaffID" Type="String" />
                <asp:Parameter Name="AnimalID" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <h1>Jay Thom Animal management window</h1>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" DataKeyNames="AnimalID" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="AnimalID" HeaderText="AnimalID" ReadOnly="True" SortExpression="AnimalID" />
                <asp:BoundField DataField="AnimalType" HeaderText="AnimalType" SortExpression="AnimalType" />
                <asp:BoundField DataField="Nickname" HeaderText="Nickname" SortExpression="Nickname" />
                <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                <asp:BoundField DataField="StaffID" HeaderText="StaffID" SortExpression="StaffID" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <asp:Button ID="Go_To_ZooKeeper_Btn" runat="server" OnClick="Go_To_ZooKeeper_Btn_Click" Text="Go to zoo keeper" />
        <br />
        <br />
        <span class="auto-style2">The Details</span><span class="auto-style1"><br />
        Animal ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Animal_Id_Lbl" runat="server" Text="none selected"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OR&nbsp;
        <asp:TextBox ID="Animal_ID_Txtbx" runat="server" MaxLength="6" Width="147px">type here for new animal</asp:TextBox>
        <br />
        <br />
        Animal Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="Animal_Type_DropDown" runat="server">
            <asp:ListItem Text="tiger" Value="horse" />
            <asp:ListItem Text="elephant" Value="bat" />
            <asp:ListItem Text="giraffe" Value="giraffe" />
            <asp:ListItem Text="monkey" Value="monkey" />
            <asp:ListItem Text="lion" Value="lion" />
            <asp:ListItem Text="lamb" Value="lamb" />
            <asp:ListItem Text="wolf" Value="wolf" />
            <asp:ListItem Text="bat" Value="bat" />
            <asp:ListItem Text="butterfly" Value="butterfly" />
            <asp:ListItem Text="bison" Value="bison" />
            <asp:ListItem Text="pig" Value="pig" />
                       <asp:ListItem Text="snake" Value="snake" />
            <asp:ListItem Text="lima" Value="lima" />
            <asp:ListItem Text="camel" Value="camel" />
        </asp:DropDownList>
        <br />
        <br />
        Nickname&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Nick_Name_Txtbx" runat="server"></asp:TextBox>
        <br />
        <br />
        Age&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Age_Txtbx" runat="server"></asp:TextBox>
        <br />
        <br />
        Gender&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="Gender_DropDown" runat="server">
            <asp:ListItem Text="male" Value="male" />
            <asp:ListItem Text="female" Value="female" />
        </asp:DropDownList>
        <br />
        <br />
        Zookeeper&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="Zookeeper_Dropdown" runat="server" OnLoad="Zookeeper_Dropdown_Load">
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <asp:Button ID="Update_Btn" runat="server" OnClick="Update_Btn_Click" Text="Update/Refresh" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Delete_Animal_Btn" runat="server" OnClick="Delete_Animal_Btn_Click" Text="Delete" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Insert_Animal_Btn" runat="server" Text="Insert" OnClick="Insert_Animal_Btn_Click" />
        </span>
    </form>
</body>
</html>
