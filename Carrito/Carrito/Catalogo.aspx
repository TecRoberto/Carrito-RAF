<%@ Page Title="Catálogo" Language="vb" AutoEventWireup="false" MasterPageFile="Principal.Master" CodeBehind="Catalogo.aspx.vb" Inherits="Carrito.Catalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%">
        <tr>
            <td style="height: 30px; width: 230px; text-align: justify;">&nbsp;<asp:Label ID="Label1" runat="server" Text="Bienvenido"></asp:Label>
&nbsp;<asp:Label ID="lblsesion" runat="server" Text="Label" style="text-align: justify"></asp:Label>
            &nbsp;<asp:Image ID="imguser" runat="server" Height="50px" Width="50px" ImageAlign="AbsMiddle" />
            </td>
            <td style="height: 30px; text-align: justify;">
                <asp:Button ID="btncerrar" runat="server" Height="28px" Text="Cerrar sesión" />
            </td>
        </tr>
        </table>
    <br />
    <br />
    <div style="margin-left: 10%">
        <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1" RepeatColumns="3" Width="100%">
            <ItemTemplate>
                <table style="width: 100%; " frame="border">
                    <tr>
                        <td style="height: 20px; text-align: center">
                            <asp:ImageButton ID="ImageButton1" runat="server" Height="80px" ImageUrl='<%# Eval("foto") %>' Width="130px" OnClick="ImageButton1_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <asp:Label ID="codproductoLabel" runat="server" Text='<%# Eval("codproducto", "{0}") %>' Visible="False" />
                            <br />
                            <asp:Label ID="desproductoLabel" runat="server" Text='<%# Eval("descripcion", "{0}") %>' />
                            <br />
                            <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="S/. "></asp:Label>
                            <asp:Label ID="preproductoLabel" runat="server" ForeColor="Red" Text='<%# Eval("precio", "{0:N}") %>' />
                            <br />
                            <asp:Label ID="canproductoLabel" runat="server" Text='<%# Eval("cantidad", "{0:N}") %>' Visible="False" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; height: 73px;">
                            <asp:Button ID="btnañadir" runat="server" CommandName="seleccionar" Text="Añadir al carrito" OnClick="btnañadir_Click" style="height: 26px" />
                            <asp:Image ID="Image1" runat="server" Height="26px" ImageAlign="Top" ImageUrl="~/images/Shop-Basket.png" Width="26px" />
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListarTodos" TypeName="ComponenteNegocio.ProductosCN">
        </asp:ObjectDataSource>
    
        
        
        <br />
    
        
        
        <br />
    
        
        
    </div>

</asp:Content>
