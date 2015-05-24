<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  
    <title></title>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("[id$=Date_Of_Birth_Txtbx]").datepicker({
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: 'http://jqueryui.com/demos/datepicker/images/calendar.gif'
            });
        });
    </script>
    <style type="text/css">
        .auto-style1 {
            font-size: medium;
        }
        .auto-style2 {
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Zookeeper] WHERE [StaffID] = @StaffID" InsertCommand="INSERT INTO [Zookeeper] ([StaffID], [Firstname], [Lastname], [Phonenumber], [DateofBirth], [Email]) VALUES (@StaffID, @Firstname, @Lastname, @Phonenumber, @DateofBirth, @Email)" SelectCommand="SELECT * FROM [Zookeeper]" UpdateCommand="UPDATE [Zookeeper] SET [Firstname] = @Firstname, [Lastname] = @Lastname, [Phonenumber] = @Phonenumber, [DateofBirth] = @DateofBirth, [Email] = @Email WHERE [StaffID] = @StaffID">
            <DeleteParameters>
                <asp:Parameter Name="StaffID" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="StaffID" Type="String" />
                <asp:Parameter Name="Firstname" Type="String" />
                <asp:Parameter Name="Lastname" Type="String" />
                <asp:Parameter Name="Phonenumber" Type="String" />
                <asp:Parameter DbType="Date" Name="DateofBirth" />
                <asp:Parameter Name="Email" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Firstname" Type="String" />
                <asp:Parameter Name="Lastname" Type="String" />
                <asp:Parameter Name="Phonenumber" Type="String" />
                <asp:Parameter DbType="Date" Name="DateofBirth" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="StaffID" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
        <h1>Jay Thom Zokeeper Management Window</h1>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" DataKeyNames="StaffID" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="StaffID" HeaderText="StaffID" ReadOnly="True" SortExpression="StaffID" />
                <asp:BoundField DataField="Firstname" HeaderText="Firstname" SortExpression="Firstname" />
                <asp:BoundField DataField="Lastname" HeaderText="Lastname" SortExpression="Lastname" />
                <asp:BoundField DataField="Phonenumber" HeaderText="Phonenumber" SortExpression="Phonenumber" />
                <asp:BoundField DataField="DateofBirth" HeaderText="DateofBirth" SortExpression="DateofBirth" DataFormatString="{0:M/d/yy}" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="Back_To_Animal_Btn" runat="server" OnClick="Back_To_Animal_Btn_Click" Text="Back to animal" />
        <br />
        <br />
        <span class="auto-style2">The Details</span><span class="auto-style1"><br />
        <br />
        Staff ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Staff_ID_Lbl" runat="server" Text="none selected"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OR&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Staff_ID_Txtbx" runat="server" MaxLength="6" Width="153px">type here for new staff</asp:TextBox>
        <br />
        <br />
        <asp:Label ID="First_Name_Lbl" runat="server" Text="First Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="First_Name_Txtbx" runat="server"></asp:TextBox>
        <br />
        <br />
        Last Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Last_Name_Txtbx" runat="server"></asp:TextBox>
        <br />
        <br />
        Phone number
        <asp:TextBox ID="Phone_NUmber_Txtbx" runat="server" OnTextChanged="Phone_NUmber_Txtbx_TextChanged"></asp:TextBox>
        <br />
        <br />
        Date Of Birth&nbsp;
        <asp:TextBox ID="Date_Of_Birth_Txtbx" runat="server"></asp:TextBox>
        <br />
        <br />
        Email&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Email_Txtbx" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Update_Btn" runat="server" Text="Update/Refresh" OnClick="Update_Btn_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Delete_Zookeeper_Btn" runat="server" Text="Delete" OnClick="Delete_Zookeeper_Btn_Click1" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Insert_Zookeeper_Btn" runat="server" Text="Insert" OnClick="Insert_Zookeeper_Btn_Click" />
        <br />
        <br />
        </span>
    </form>
</body>
</html>
