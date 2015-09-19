Imports ComponenteEntidad
Imports ComponenteDatos
Imports ComponenteNegocio
Imports System.Data.SqlClient

Public Class Catalogo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Session("usuario") = "" Then
        '    Response.Redirect("~/inicio.aspx")
        'End If

        'lblsesion.Text = Session("usuario")
        'imguser.ImageUrl = "usuarios/" + Session("usuario") + ".png"

    End Sub

    Protected Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Session.Remove("usuario")
        Session.Remove("Canasta")
        Response.Redirect("~/inicio.aspx")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataList1_ItemCommand(source As Object, e As DataListCommandEventArgs) Handles DataList1.ItemCommand
        Dim cod, des As String
        Dim can As Integer
        Dim pre As Double
        If e.CommandName = "seleccionar" Then
            DataList1.SelectedIndex = e.Item.ItemIndex
            cod = CType(DataList1.SelectedItem.FindControl("codproductoLabel"), Label).Text
            des = CType(DataList1.SelectedItem.FindControl("desproductoLabel"), Label).Text
            pre = CType(DataList1.SelectedItem.FindControl("preproductoLabel"), Label).Text
            can = CType(DataList1.SelectedItem.FindControl("canproductoLabel"), Label).Text
            AgregarIdprod(cod, des, pre, can)
        End If
    End Sub
    Public Function Producto() As CANASTADS
        Dim obj As CANASTADS = CType(Session("Canasta"), CANASTADS)
        If obj Is Nothing Then
            obj = New CANASTADS()
            Session("Canasta") = obj
        End If
        Return obj
    End Function
    Public Sub AgregarIdprod(ByVal cod As String, ByVal des As String, ByVal pre As Double, ByVal can As Integer)
        Try
            Dim obj As CANASTADS = Me.Producto
            Dim fila As CANASTADS.CANASTARow = obj.CANASTA.NewCANASTARow()
            fila.codproducto = cod
            fila.desproducto = des
            fila.preproducto = pre
            fila.canproducto = 1
            fila.subtotal = pre * 1
            fila.stock = can
            obj.CANASTA.Rows.Add(fila)
        Catch ex As Exception
            MsgBox(Title:="AVISO", Prompt:="Usted ya agrego éste producto al carrito")
            '    'Response.Write("<script language='JavaScript'>alert('Usted ya agrego éste producto al carrito');</script>")
        End Try
    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs)
        Response.Redirect("~/listacomprados.aspx")
    End Sub

    Protected Sub btnañadir_Click(sender As Object, e As EventArgs)
       
    End Sub
End Class