Imports ComponenteEntidad
Imports ComponenteDatos
Imports ComponenteNegocio
Imports System.Data.SqlClient
Imports System.Web.Mail
Imports System.Net.Mail
Imports System.Net

Public Class listacomprados
    Inherits System.Web.UI.Page
    Dim IDVenta As String
    Sub autogenerarcodigoPer()
        Dim cnper As New VentaCN()
        Dim per As List(Of Venta) = cnper.UltimoCod()
        For Each ma As Venta In per
            Dim codigo As Integer
            codigo = Convert.ToInt32(ma.Codigo)
            codigo = codigo + 1
            If codigo < 10 Then
                ma.Codigo = "000" & codigo.ToString()
            End If
            If codigo < 100 AndAlso codigo > 9 Then
                ma.Codigo = "00" & codigo.ToString()
            End If
            If codigo < 1000 AndAlso codigo > 99 Then
                ma.Codigo = "0" & codigo.ToString()
            End If
            IDVenta = ma.Codigo
        Next
    End Sub
    Sub autogenerarcodigoClie()
        Dim cnper As New ClienteCN()
        Dim per As List(Of Cliente) = cnper.UltimoCod()
        For Each ma As Cliente In per
            Dim codigo As Integer
            codigo = Convert.ToInt32(ma.Codigo)
            codigo = codigo + 1
            If codigo < 10 Then
                ma.Codigo = "000" & codigo.ToString()
            End If
            If codigo < 100 AndAlso codigo > 9 Then
                ma.Codigo = "00" & codigo.ToString()
            End If
            If codigo < 1000 AndAlso codigo > 99 Then
                ma.Codigo = "0" & codigo.ToString()
            End If
            txtCodigo.Text = ma.Codigo
        Next
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox3.Focus()
        'If Session("usuario") = "" Then
        '    Response.Redirect("~/inicio.aspx")
        'End If

        'lblsesion.Text = Session("usuario")
        'imguser.ImageUrl = "usuarios/" + Session("usuario") + ".png"

        If Page.IsPostBack = False Then
            cargarcarrito()
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("Catalogo.aspx")

    End Sub

    Sub cargarcarrito()
        Dim GV As New GridView
        GvwCarrito.DataSource = Session("Canasta")
        GvwCarrito.DataBind()
        Call Button1_Click(Button1, Nothing)
    End Sub

    Private Sub GvwCarrito_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GvwCarrito.RowCommand
        Dim DS As New DataSet
        DS = CType(Session("Canasta"), DataSet)
        Dim DT As New DataTable
        DT = DS.Tables("Canasta")
        Dim i As Integer
        Dim cod, codb As String
        If e.CommandName = "Borrar" Then
            cod = e.CommandArgument.ToString
            For i = 0 To DT.Rows.Count - 1
                codb = DT.Rows(i).Item(0).ToString
                If codb = cod Then
                    DT.Rows(i).Delete()
                    DT.AcceptChanges()
                    Exit For
                End If
            Next
        End If
        cargarcarrito()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim i As Integer
        Dim total, prec, subtotal, igv, TotalPagar As Double
        Dim cod, des As String
        Dim cant, stock As Integer
        Dim obj As CANASTADS = CType(Session("Canasta"), CANASTADS)

        For i = 0 To GvwCarrito.Rows.Count - 1
            cod = (GvwCarrito.Rows(i).Cells(1).Text)
            des = (GvwCarrito.Rows(i).Cells(2).Text)
            prec = Double.Parse(GvwCarrito.Rows(i).Cells(3).Text)
            cant = CType(GvwCarrito.Rows(i).Cells(0).FindControl("TextBox1"), TextBox).Text
            stock = (GvwCarrito.Rows(i).Cells(6).Text)
            subtotal = cant * prec
            stock = stock - cant
            'Actualiza la canasta
            GvwCarrito.Rows(i).Cells(5).Text = subtotal
            GvwCarrito.Rows(i).Cells(7).Text = stock
            If stock.ToString() = 0 Then
                MsgBox(Title:="AVISO", Prompt:="Producto agotado")
            End If
            For Each objDR In obj.CANASTA.Rows
                If objDR("codproducto") = cod Then
                    objDR("canproducto") = cant
                    objDR("subtotal") = subtotal
                    objDR("stock1") = stock
                    Exit For
                End If
            Next
            total = total + subtotal
            igv = (total * 1.19) - total
            TotalPagar = total + igv

        Next
        Lblsubtotal.Text = total.ToString("0.00")
        LblIgv.Text = igv.ToString("0.00")
        LblTotal.Text = TotalPagar.ToString("0.00")
    End Sub

    Protected Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Session.Remove("usuario")
        Session.Remove("Canasta")
        Response.Redirect("~/inicio.aspx")
    End Sub

    Protected Sub btncomprar_Click(sender As Object, e As EventArgs) Handles btncomprar.Click
        autogenerarcodigoPer()
        If CheckBox1.Checked = False Then
            Dim clie As New Cliente()
            Dim ccn As New ClienteCN()
            clie.Codigo = txtCodigo.Text
            clie.Nombres = TextBox2.Text
            clie.Dni = TextBox3.Text
            clie.Email = TextBox4.Text
            ccn.insertarCliente(clie)
        End If

        Dim ven As New Venta()
        Dim venCN As New VentaCN()
        ven.Codigo = IDVenta
        ven.CodigoClie = txtCodigo.Text
        ven.Estado = "Aceptada"
        ven.Fecha = Date.Now.ToShortDateString()
        ven.IGV = Convert.ToDouble(LblIgv.Text)
        ven.SubTotal = Convert.ToDouble(Lblsubtotal.Text)
        ven.TotalVenta = Convert.ToDouble(LblTotal.Text)
        venCN.insertarVenta(ven)

        For Each row As GridViewRow In GvwCarrito.Rows
            Dim detalle As New DetalleVenta()
            detalle.Codigo = IDVenta
            detalle.CodigoPro = CStr(row.Cells(1).Text)
            detalle.Precio = Convert.ToDouble(CStr(row.Cells(3).Text))
            detalle.SubTotal = Convert.ToDouble(CStr(row.Cells(5).Text))
            detalle.Cantidad = Convert.ToDouble(CType(row.Cells(4).FindControl("TextBox1"), TextBox).Text)
            venCN.insertarDetalle(detalle)
            'MsgBox(Convert.ToDouble(CType(row.Cells(4).FindControl("TextBox1"), TextBox).Text))
        Next
        
        'ESTA PARTE DEL CODIGO ES PARA ENVIAR UN CORREO ELECTRONICO
        Dim correo As New System.Net.Mail.MailMessage
        Dim smtp As New System.Net.Mail.SmtpClient
        Try
            correo.To.Clear()
            correo.Body = ""
            correo.Subject = ""

            correo.Body = "Numero de Compra: " + IDVenta +
                " DNI: " + TextBox3.Text +
                " Señor: " + TextBox2.Text +
                " Usted realizo una compra de varios productos por un monto de: " + "S/." + LblTotal.Text
               
            correo.Subject = "Verificacion de Compra en CARRITO DE 'COMPRAS PLEKLE'"
            correo.IsBodyHtml = True
            correo.To.Add(Trim(TextBox4.Text))

            'ojo el correo que va abajito tiene q ser de gmail pero este manda a cualkier dominio OK
            correo.From = New MailAddress("joseurbina1292@gmail.com")
            smtp.Credentials = New NetworkCredential("joseurbina1292@gmail.com", "jose12061992")

            'Datos importantes no modificables para tener acceso a las cuentas

            smtp.Host = "smtp.gmail.com"
            smtp.Port = 587
            smtp.EnableSsl = True

            smtp.Send(correo)
            MsgBox("El mensaje fue enviado correctamente. ", MsgBoxStyle.Information, "Mensaje")

        Catch ex As Exception
            MsgBox(ex.Message, "Mensajeria 1.0 vb.net ®" & ex.Message)
        End Try
    End Sub

    Protected Sub GvwCarrito_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GvwCarrito.SelectedIndexChanged

    End Sub
    Sub BuscarPorDni()
        Dim ds As DataSet
        Dim dt As DataTable
        Dim dr As DataRow
        Dim ca As New ClaseAyuda()
        ds = ca.BuscarClientePorDni(TextBox3.Text)
        dt = ds.Tables(0)
        For i As Integer = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            TextBox2.Text = ((Convert.ToString(dr("CLIE_NombresyAp"))))
            TextBox4.Text = ((Convert.ToString(dr("CLIE_Email"))))
            txtCodigo.Text = ((Convert.ToString(dr("CLIE_Codigo"))))
            TextBox2.Enabled = False
            TextBox4.Enabled = False
            TextBox3.Enabled = True
            TextBox2.Focus()
            CheckBox1.Checked = True
        Next
        If dt.Rows.Count = 0 Then
            Response.Write("<script  type='text/javascript'>alert('EL Cliente no Existe');</script>")
            'MsgBox("El CLiente no existe")
            autogenerarcodigoClie()
            txtCodigo.Enabled = False
            TextBox2.Enabled = True
            TextBox4.Enabled = True
            CheckBox1.Checked = False
            TextBox2.Focus()
            Return
        End If

    End Sub
    Protected Sub btnVerifica_Click(sender As Object, e As EventArgs) Handles btnVerifica.Click
        BuscarPorDni()
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        GvwCarrito.DataSource = Nothing
        GvwCarrito.DataBind()
        Session.Remove("Canasta")
        Response.Redirect("Catalogo.aspx")
    End Sub

    Protected Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class