Imports ComponenteDatos
Imports ComponenteEntidad
Public Class VentaCN
    Public Function insertarVenta(ByVal ven As Venta) As Boolean
        Try
            Dim vcn As New VentasCD
            Return vcn.InsertarVenta(ven)

        Catch ex As Exception
            Throw New Exception(ex.Message)

        End Try
    End Function
    Public Function insertarDetalle(ByVal dv As DetalleVenta) As Boolean
        Try
            Dim vcn As New VentasCD
            Return vcn.InsertarDetalle(dv)

        Catch ex As Exception
            Throw New Exception(ex.Message)

        End Try
    End Function
   
    Public Function UltimoCod() As List(Of Venta)
        Dim cd As New VentasCD()
        Return cd.UltimoCod()
    End Function
End Class
