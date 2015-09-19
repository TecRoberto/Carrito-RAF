Public Class Productos
    Private _codproducto As String
    Private _descripcion As String
    Private _precio As Double
    Private _cantidad As Integer
    Private _foto As String
    Public Property codproducto() As String
        Get
            Return _codproducto
        End Get
        Set(ByVal value As String)
            _codproducto = value
        End Set
    End Property
    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    Public Property precio() As Double
        Get
            Return _precio
        End Get
        Set(ByVal value As Double)
            _precio = value
        End Set
    End Property
    Public Property cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property
    Public Property foto() As String
        Get
            Return _foto
        End Get
        Set(ByVal value As String)
            _foto = value
        End Set
    End Property
    Public Sub New(ByVal ccodproducto As String, ByVal cdesproducto As String, ByVal cprecio As Double, ByVal ccantidad As Integer, ByVal cfoto As String)
        _codproducto = ccodproducto
        _descripcion = cdesproducto
        _precio = cprecio
        _cantidad = ccantidad
        _foto = cfoto
    End Sub
End Class
