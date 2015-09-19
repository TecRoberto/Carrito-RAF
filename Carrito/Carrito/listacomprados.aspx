<%@ Page Title="Carrito" Language="vb" AutoEventWireup="false" MasterPageFile="Principal.Master" CodeBehind="listacomprados.aspx.vb" Inherits="Carrito.listacomprados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 8%">
    <div>
        &nbsp;<table style="width: 100%">
            <tr>
                <td style="height: 26px">Codigo Cliente:</td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtCodigo" runat="server" Width="58px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>DNI:</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="137px"></asp:TextBox>
                <asp:Button ID="btnVerifica" runat="server" Height="28px" Text="Verificar" Width="89px" />
                </td>
            </tr>
            <tr>
                <td style="height: 17px">Nombres y Apellidos:</td>
                <td style="height: 17px">
                    <asp:TextBox ID="TextBox2" runat="server" Width="301px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Correo Electronico:</td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Width="243px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Existe" />
                </td>
            </tr>
        </table>
    </div>
    <table style="width: 100%">
        <tr>
            <td style="height: 30px; width: 200px; text-align: justify;">&nbsp;<asp:Label ID="Label4" runat="server" Text="Bienvenido"></asp:Label>
&nbsp;<asp:Label ID="lblsesion" runat="server" Text="Label" style="text-align: justify"></asp:Label>
            &nbsp;<asp:Image ID="imguser" runat="server" Height="50px" Width="50px" ImageAlign="AbsMiddle" />
            </td>
            <td style="height: 30px; text-align: justify;">
                <asp:Button ID="btncerrar" runat="server" Height="28px" Text="Cerrar sesión" />
            </td>
        </tr>
        </table>
    <div>
    <table>
            <tr>
                <td align="center" bgcolor="#006699">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="White"
                Text="Mi Carrito de Compras"></asp:Label>
                </td>
            </tr>
        </table>
        <div>
                    <asp:GridView ID="GvwCarrito" runat="server" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                    CellPadding="0" Width="100%" PageSize="5" DataSourceID="SqlDataSource1">
                    <RowStyle ForeColor="#000066" />
                        <Columns> 
                        <asp:TemplateField HeaderText="Quitar"> 
                            <ItemTemplate>
                            <asp:ImageButton ID="imgEliminar" runat="server" CommandName="Borrar" CommandArgument='<%# Eval("codproducto") %>' Height="20px" ImageUrl="~/images/Eliminar.png" Width="20px" ImageAlign="AbsMiddle" />
                            </ItemTemplate>
                            </asp:TemplateField>
                        <asp:BoundField DataField="codproducto" HeaderText="Codigo" />
                        <asp:BoundField DataField="desproducto" HeaderText="Producto" />
                        <asp:BoundField DataField="preproducto" HeaderText="Precio" />
                        <asp:TemplateField HeaderText="Cantidad" > <ItemTemplate> <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("canproducto") %>' Width="40px"></asp:TextBox> </ItemTemplate> </asp:TemplateField>
                        <asp:BoundField DataField="subtotal" HeaderText="Subtotal" />
                        <asp:BoundField DataField="stock" HeaderText="Stock inicial Disponible"/>
                        <asp:BoundField DataField="stock1" HeaderText="Stock final Disponible" />
                        </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
            </div>
               <table>
            <tr>
                <td align="right" class="style2" style="width: 927px; height: 17px;">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Text="Subtotal S/." Font-Bold="True"></asp:Label>
                &nbsp;</td>
                <td align="right" class="style2" style="width: 483px; height: 17px;">
                <asp:Label ID="Lblsubtotal" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2" style="width: 927px; font-weight: bold;">
                    IGV S/.</td>
                <td align="right" class="style2" style="width: 483px">
                <asp:Label ID="LblIgv" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2" style="width: 927px; font-weight: bold;">
                    Total de Venta S/.</td>
                <td align="right" class="style2" style="width: 483px">
                <asp:Label ID="LblTotal" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" class="style2" colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Actualizar Datos" CommandName="seleccionar" Width="110px" />
                <asp:Button ID="Button2" runat="server" Text="Continuar Comprando" Width="143px" />
                    <asp:Button ID="btncomprar" runat="server" Text="Comprar" />
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" />
                </td>
            </tr>
        </table>
    </div>
        </div>
</asp:Content>
