Imports System.Data
Imports System.Data.SqlClient
Imports ComponenteEntidad

Public Class ProductosDA
    Private Shared ReadOnly _instancia As New ProductosDA
    Public Shared ReadOnly Property Instancia() As ProductosDA
        Get
            Return _instancia
        End Get
    End Property
    Public Function ListarTodos() As List(Of Productos)
        Dim cnn As New SqlConnection(Conexion.Instancia.cadenaconexion)
        cnn.Open()
        Dim sqlcmd As New SqlCommand("pa_productos_Listar", cnn)
        sqlcmd.CommandType = CommandType.StoredProcedure
        Dim PaTable As SqlDataReader = sqlcmd.ExecuteReader
        Dim Coleccion As New List(Of Productos)
        While PaTable.Read
            Coleccion.Add(New Productos(PaTable.Item(0), PaTable.Item(1), PaTable.Item(2), PaTable.Item(3), PaTable.Item(4)))
        End While
        cnn.Close()
        cnn.Dispose()
        Return Coleccion
    End Function

    Public Function ListarporCodigo(ByVal cod As String) As List(Of Productos)
        Dim dsDatos As New DataSet
        Dim cnn As New SqlConnection(Conexion.Instancia.cadenaconexion)
        cnn.Open()
        Dim sqlcmd As New SqlCommand("pa_productos_buscarcodigo", cnn)
        sqlcmd.CommandType = CommandType.StoredProcedure
        sqlcmd.Parameters.Add("@codproducto", SqlDbType.Char, 4).Value = cod
        Dim PaTable As SqlDataReader = sqlcmd.ExecuteReader
        Dim Coleccion As New List(Of Productos)
        While PaTable.Read
            Coleccion.Add(New Productos(PaTable.Item(0), PaTable.Item(1), PaTable.Item(2), PaTable.Item(3), PaTable.Item(4)))
        End While
        cnn.Close()
        cnn.Dispose()
        Return Coleccion
    End Function

    Public Function Insertar(ByVal Productos As Productos) As Boolean
        Dim cnn As New SqlConnection(Conexion.Instancia.cadenaconexion)
        cnn.Open()
        Dim Sqlcmd As New SqlCommand("pa_productos_insertar", cnn)
        Sqlcmd.CommandType = CommandType.StoredProcedure
        Sqlcmd.Parameters.Add("@codproducto", SqlDbType.Char, 4).Value = Productos.codproducto
        Sqlcmd.Parameters.Add("@desproducto", SqlDbType.VarChar, 100).Value = Productos.descripcion
        Sqlcmd.Parameters.Add("@preproducto", SqlDbType.Decimal).Value = Productos.precio
        Sqlcmd.Parameters.Add("@canproducto", SqlDbType.Int).Value = Productos.cantidad
        Sqlcmd.Parameters.Add("@foto", SqlDbType.VarChar, 20).Value = Productos.foto
        Sqlcmd.ExecuteNonQuery()
        cnn.Close()
        cnn.Dispose()
        Return True
    End Function

    Public Function Editar(ByVal Productos As Productos) As Boolean
        Dim cnn As New SqlConnection(Conexion.Instancia.cadenaconexion)
        cnn.Open()
        Dim Sqlcmd As New SqlCommand("pa_productos_modificar", cnn)
        Sqlcmd.CommandType = CommandType.StoredProcedure
        Sqlcmd.Parameters.Add("@codproducto", SqlDbType.Char, 4).Value = Productos.codproducto
        Sqlcmd.Parameters.Add("@desproducto", SqlDbType.VarChar, 100).Value = Productos.descripcion
        Sqlcmd.Parameters.Add("@preproducto", SqlDbType.Decimal).Value = Productos.precio
        Sqlcmd.Parameters.Add("@canproducto", SqlDbType.Int).Value = Productos.cantidad
        Sqlcmd.Parameters.Add("@foto", SqlDbType.VarChar, 20).Value = Productos.foto
        Sqlcmd.ExecuteNonQuery()
        cnn.Close()
        cnn.Dispose()
        Return True
    End Function

    Public Function Eliminar(ByVal codproducto As String) As Boolean
        Dim cnn As New SqlConnection(Conexion.Instancia.cadenaconexion)
        cnn.Open()
        Dim Sqlcmd As New SqlCommand("pa_productos_eliminar", cnn)
        Sqlcmd.CommandType = CommandType.StoredProcedure
        Sqlcmd.Parameters.Add("@codproducto", SqlDbType.Char, 4).Value = codproducto
        Sqlcmd.ExecuteNonQuery()
        cnn.Close()
        cnn.Dispose()
        Return True
    End Function
End Class
