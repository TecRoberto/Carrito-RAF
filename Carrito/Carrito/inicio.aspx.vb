Imports System.Data.SqlClient

Public Class inicio
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection("Data Source=.;Initial Catalog=BDCANASTA;Integrated Security=True")
    Dim ds As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        'cn.Open()
        'Dim consulta As New SqlDataAdapter("select Usuario from USUARIOS where Usuario='" + txtuser.Text + "' and Contraseña='" + txtpass.Text + "'", cn)
        'consulta.Fill(ds, "USUARIOS")
        'If ds.Tables("USUARIOS").Rows.Count > 0 Then
        '    Session("usuario") = (ds.Tables("USUARIOS").Rows(0)(0)).ToString.Trim
        '    If (txtuser.Text <> Session("usuario")) Then
        '        Response.Redirect("~/inicio.aspx")
        '    Else
        Response.Redirect("~/Catalogo.aspx")
        'End If
        'End If
    End Sub
End Class