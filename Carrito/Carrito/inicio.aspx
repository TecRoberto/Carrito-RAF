<%@ Page Title="Inicio" Language="vb" AutoEventWireup="false" MasterPageFile="Principal.Master" CodeBehind="inicio.aspx.vb" Inherits="Carrito.inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 8%"> 
     
      <div id="profile" style="margin-left: 15%">
          <h3>Iniciar sesión</h3>
           <table style="width: 281px">
        <tr>
            <td class="auto-style3" style="height: 33px">
                <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
            </td>
            <td style="height: 33px; width: 185px;">
                <asp:Image ID="Image1" runat="server" Height="22px" ImageUrl="images/user.png" Width="22px" ImageAlign="AbsMiddle" />
                <asp:TextBox ID="txtuser" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3" style="height: 32px">
                <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
            </td>
            <td style="width: 185px; height: 32px;">
                <asp:Image ID="Image2" runat="server" Height="20px" ImageUrl="images/key.png" Width="22px" ImageAlign="AbsMiddle" />
                <asp:TextBox ID="txtpass" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" BackColor="#E0D5B7" Font-Bold="True" ForeColor="#FF3300" />
            </td>
            <td style="width: 185px">&nbsp;</td>
        </tr>
    </table>
    </div>
   
    <div id="welcome" style="margin-left: 10%; text-align: justify;">
         <h3>Carrito de compras</h3>
        <div style="margin-left: 38%">
                <img src="images/logo.jpg" width="140px" height="120px" alt="Pic 1" class="right" />
        </div>
           
      </div>
        </div>
</asp:Content>
