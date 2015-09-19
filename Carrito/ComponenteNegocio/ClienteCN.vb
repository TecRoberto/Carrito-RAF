Imports ComponenteDatos
Imports ComponenteEntidad
Public Class ClienteCN
    Public Function insertarCliente(ByVal ven As Cliente) As Boolean
        Try
            Dim vcn As New ClienteCD
            Return vcn.InsertarCliente(ven)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Function UltimoCod() As List(Of Cliente)
        Dim cd As New ClienteCD()
        Return cd.UltimoCod()
    End Function
    Public Function BuscarPorDni(ByVal dni As String) As List(Of Cliente)
        Return ClienteCD.Instancia.BuscarPorDni(dni)
    End Function
End Class
