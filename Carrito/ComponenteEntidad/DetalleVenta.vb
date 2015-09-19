Public Class DetalleVenta
    'VEN_Codigo, PRO_Codigo, DV_Cantidad, DV_Precio, DV_SubTotal
    Private _Codigo As String
    Private _CodigoPro As String
    Private _Cantidad As Double
    Private _Precio As Double
    Private _SubTotal As Double
    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property
    Public Property CodigoPro() As String
        Get
            Return _CodigoPro
        End Get
        Set(ByVal value As String)
            _CodigoPro = value
        End Set
    End Property
    Public Property Cantidad() As Double
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Double)
            _Cantidad = value
        End Set
    End Property
    Public Property Precio() As Double
        Get
            Return _Precio
        End Get
        Set(ByVal value As Double)
            _Precio = value
        End Set
    End Property
    Public Property SubTotal() As Double
        Get
            Return _SubTotal
        End Get
        Set(ByVal value As Double)
            _SubTotal = value
        End Set
    End Property
    Public Sub DetalleVenta()

    End Sub
End Class
