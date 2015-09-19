Imports System.Data
Imports System.Data.SqlClient
Imports ComponenteEntidad
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common




Public Class VentasCD
    'Private db As Database = DataMyBaseFactory.CreateDataMyBase()
    'Private Const nombreprocedimiento1 As String = "PA_Ventas"
    'Private Const nombreprocedimiento2 As String = "PA_DetalleVentas"
    'Private Const nombreTabla As String = "VENTA"
    Private Shared ReadOnly _instancia As New VentasCD
    Public Shared ReadOnly Property Instancia() As VentasCD
        Get
            Return _instancia
        End Get
    End Property
    Public Function InsertarVenta(ByVal ven As Venta) As Boolean
        Dim cnn As New SqlConnection(Conexion.Instancia.cadenaconexion)
        cnn.Open()
        Dim Sqlcmd As New SqlCommand("PA_Ventas", cnn)
        Sqlcmd.CommandType = CommandType.StoredProcedure
        Sqlcmd.Parameters.Add("@VEN_Codigo", SqlDbType.Char, 10).Value = ven.Codigo
        Sqlcmd.Parameters.Add("@VEN_Fecha", SqlDbType.Date).Value = ven.Fecha
        Sqlcmd.Parameters.Add("@CLI_Codigo", SqlDbType.Char, 10).Value = ven.CodigoClie
        Sqlcmd.Parameters.Add("@VEN_IGV", SqlDbType.Float).Value = ven.IGV
        Sqlcmd.Parameters.Add("@VEN_SubTotal", SqlDbType.Float).Value = ven.SubTotal
        Sqlcmd.Parameters.Add("@VEN_Total", SqlDbType.Float).Value = ven.TotalVenta
        Sqlcmd.Parameters.Add("@VEN_Estado", SqlDbType.VarChar, 20).Value = ven.Estado
        Sqlcmd.ExecuteNonQuery()
        cnn.Close()
        cnn.Dispose()
        Return True
    End Function
    Public Function InsertarDetalle(ByVal dv As DetalleVenta) As Boolean
        Dim cnn As New SqlConnection(Conexion.Instancia.cadenaconexion)
        cnn.Open()
        Dim Sqlcmd1 As New SqlCommand("PA_DetalleVentas", cnn)
        Sqlcmd1.CommandType = CommandType.StoredProcedure
        Sqlcmd1.CommandType = CommandType.StoredProcedure
        Sqlcmd1.Parameters.Add("@VEN_Codigo", SqlDbType.Char, 10).Value = dv.Codigo
        Sqlcmd1.Parameters.Add("@IDProducto", SqlDbType.Char, 10).Value = dv.CodigoPro
        Sqlcmd1.Parameters.Add("@DV_Cantidad", SqlDbType.Float).Value = dv.Cantidad
        Sqlcmd1.Parameters.Add("@DV_Precio", SqlDbType.Float).Value = dv.Precio
        Sqlcmd1.Parameters.Add("@DV_SubTotal", SqlDbType.Float, 20).Value = dv.SubTotal
        Sqlcmd1.ExecuteNonQuery()
        cnn.Close()
        cnn.Dispose()
        Return True
    End Function
    'Public Overridable Function crear(ven As Venta) As Boolean
    '    Dim cnn As New SqlConnection(Conexion.Instancia.cadenaconexion)
    '    cnn.Open()
    '    Dim T As DbTransaction = cnn.BeginTransaction()
    '    T.Commit()

    '    Try
    '        'VEN_Codigo, VEN_Fecha, CLIE_Codigo, VEN_IGV, VEN_SubTotal, VEN_TotalVenta, VEN_Estado
    '        Dim Sqlcmd As New SqlCommand("PA_Ventas", cnn)
    '        Sqlcmd.CommandType = CommandType.StoredProcedure
    '        Sqlcmd.Parameters.Add("@VEN_Codigo", SqlDbType.Char, 10).Value = ven.Codigo
    '        Sqlcmd.Parameters.Add("@VEN_Fecha", SqlDbType.VarChar, 50).Value = ven.Fecha
    '        Sqlcmd.Parameters.Add("@CLI_Codigo", SqlDbType.Char, 10).Value = ven.CodigoClie
    '        Sqlcmd.Parameters.Add("@VEN_IGV", SqlDbType.Float).Value = ven.IGV
    '        Sqlcmd.Parameters.Add("@VEN_SubTotal", SqlDbType.Float).Value = ven.SubTotal
    '        Sqlcmd.Parameters.Add("@VEN_Total", SqlDbType.Float).Value = ven.TotalVenta
    '        Sqlcmd.Parameters.Add("@VEN_Estado", SqlDbType.VarChar, 20).Value = ven.Estado
    '        'Sqlcmd.ExecuteNonQuery()

    '        Dim huboexito As Integer = Sqlcmd.ExecuteNonQuery()
    '        If huboexito = 0 Then
    '            Throw New Exception("Error")

    '        End If
    '        Dim codventa As String = ven.Codigo
    '        For Each itemx As DetalleVenta In ven.DetalleVenta

    '            'VEN_Codigo, PRO_Codigo, DV_Cantidad, DV_Precio, DV_SubTotal
    '            Dim Sqlcmd1 As New SqlCommand("PA_DetalleVentas", cnn)
    '            Sqlcmd1.CommandType = CommandType.StoredProcedure
    '            Sqlcmd1.CommandType = CommandType.StoredProcedure
    '            Sqlcmd1.Parameters.Add("@VEN_Codigo", SqlDbType.Char, 10).Value = codventa
    '            Sqlcmd1.Parameters.Add("@IDProducto", SqlDbType.Char, 10).Value = itemx.CodigoPro
    '            Sqlcmd1.Parameters.Add("@DV_Cantidad", SqlDbType.Float).Value = itemx.Cantidad
    '            Sqlcmd1.Parameters.Add("@DV_Precio", SqlDbType.Float).Value = itemx.Precio
    '            Sqlcmd1.Parameters.Add("@DV_SubTotal", SqlDbType.Float, 20).Value = itemx.SubTotal
    '            'Sqlcmd1.ExecuteNonQuery()
    '            huboexito = Sqlcmd.ExecuteNonQuery()
    '            If huboexito = 0 Then
    '                Throw New Exception("Error")

    '            End If
    '        Next
    '        T.Commit()
    '        cnn.Close()
    '        cnn.Dispose()
    '        Return True

    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '        T.Rollback()

    '    End Try

    'End Function

    Public contador As String
    Public Function UltimoCod() As List(Of Venta)
        Dim cnn As New SqlConnection(Conexion.Instancia.cadenaconexion)
        cnn.Open()
        Dim sqlcmd As New SqlCommand("select count(VEN_Codigo),max (VEN_Codigo) from VENTA", cnn)
        sqlcmd.CommandType = CommandType.Text
        Dim PaTable As SqlDataReader = sqlcmd.ExecuteReader
        Dim Coleccion As New List(Of Venta)
        While PaTable.Read
            Me.contador = Convert.ToString(PaTable.GetInt32(0))
            If contador = "0" Then
                Coleccion.Add(New Venta(PaTable.GetInt32(0).ToString()))

            Else
                Coleccion.Add(New Venta(PaTable.GetString(1)))

            End If
        End While
        cnn.Close()
        cnn.Dispose()
        Return Coleccion
    End Function


End Class
