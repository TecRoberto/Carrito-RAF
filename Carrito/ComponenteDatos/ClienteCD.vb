Imports System.Data
Imports System.Data.SqlClient
Imports ComponenteEntidad
Public Class ClienteCD
    Private Shared ReadOnly _instancia As New ClienteCD
    Public Shared ReadOnly Property Instancia() As ClienteCD
        Get
            Return _instancia
        End Get
    End Property
    Public Function InsertarCliente(ByVal clie As Cliente) As Boolean
        Dim cnn As New SqlConnection(Conexion.Instancia.cadenaconexion)
        cnn.Open()
        '@Codigo, @Dni,@nombres, @email
        Dim Sqlcmd As New SqlCommand("PA_Cliente", cnn)
        Sqlcmd.CommandType = CommandType.StoredProcedure
        Sqlcmd.Parameters.Add("@Codigo", SqlDbType.Char, 10).Value = clie.Codigo
        Sqlcmd.Parameters.Add("@Dni", SqlDbType.Char, 10).Value = clie.Dni
        Sqlcmd.Parameters.Add("@nombres", SqlDbType.VarChar, 50).Value = clie.Nombres
        Sqlcmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = clie.Email
        Sqlcmd.ExecuteNonQuery()
        cnn.Close()
        cnn.Dispose()
        Return True
    End Function
    Public contador As String
    Public Function UltimoCod() As List(Of Cliente)
        Dim cnn As New SqlConnection(Conexion.Instancia.cadenaconexion)
        cnn.Open()
        Dim sqlcmd As New SqlCommand("select count(CLIE_Codigo),max (CLIE_Codigo) from CLIENTES", cnn)
        sqlcmd.CommandType = CommandType.Text
        Dim PaTable As SqlDataReader = sqlcmd.ExecuteReader
        Dim Coleccion As New List(Of Cliente)
        While PaTable.Read
            Me.contador = Convert.ToString(PaTable.GetInt32(0))
            If contador = "0" Then
                Coleccion.Add(New Cliente(PaTable.GetInt32(0).ToString()))

            Else
                Coleccion.Add(New Cliente(PaTable.GetString(1)))
            End If
        End While
        cnn.Close()
        cnn.Dispose()
        Return Coleccion
    End Function
    Public Function BuscarPorDni(ByVal dni As String) As List(Of Cliente)
        Dim dsDatos As New DataSet
        Dim cnn As New SqlConnection(Conexion.Instancia.cadenaconexion)
        cnn.Open()
        Dim sqlcmd As New SqlCommand("[PA_BuscarClientePorDni]", cnn)
        sqlcmd.CommandType = CommandType.StoredProcedure
        sqlcmd.Parameters.Add("@Dni", SqlDbType.Char, 10).Value = dni
        Dim PaTable As SqlDataReader = sqlcmd.ExecuteReader
        Dim Coleccion As New List(Of Cliente)
        While PaTable.Read
            Coleccion.Add(New Cliente(PaTable.Item(0), PaTable.Item(1), PaTable.Item(2), PaTable.Item(3)))
        End While
        cnn.Close()
        cnn.Dispose()
        Return Coleccion
    End Function
End Class
