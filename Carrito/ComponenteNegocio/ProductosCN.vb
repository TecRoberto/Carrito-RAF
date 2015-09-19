Imports ComponenteDatos
Imports ComponenteEntidad

Public Class ProductosCN
    Public Sub New()
    End Sub
    Private Shared ReadOnly _instancia As New ProductosCN
    Public Shared ReadOnly Property Instancia() As ProductosCN
        Get
            Return _instancia
        End Get
    End Property
    Public Function ListarTodos() As List(Of Productos)
        Return ProductosDA.Instancia.ListarTodos
    End Function
    Public Function ListarporCodigo(ByVal cod As String) As List(Of Productos)
        Return ProductosDA.Instancia.ListarporCodigo(cod)
    End Function
    Public Function Insertar(ByVal Productos As Productos) As Boolean
        Return ProductosDA.Instancia.Insertar(Productos)
    End Function
    Public Function Editar(ByVal Productos As Productos) As Boolean
        Return ProductosDA.Instancia.Editar(Productos)
    End Function
    Public Function Eliminar(ByVal codproducto As String) As Boolean
        Return ProductosDA.Instancia.Eliminar(codproducto)
    End Function
End Class
