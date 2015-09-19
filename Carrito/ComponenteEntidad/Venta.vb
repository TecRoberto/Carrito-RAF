Public Class Venta
    'VEN_Codigo, VEN_Fecha, CLIE_Codigo, VEN_IGV, VEN_SubTotal, VEN_TotalVenta, VEN_Estado
    Private _Codigo As String
    Private _Fecha As String
    Private _CodigoClie As String
    Private _IGV As Double
    Private _SubTotal As Double
    Private _TotalVenta As Double
    Private _Estado As String


    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property
    Public Property Fecha() As String
        Get
            Return _Fecha
        End Get
        Set(ByVal value As String)
            _Fecha = value
        End Set
    End Property
    Public Property CodigoClie() As String
        Get
            Return _CodigoClie
        End Get
        Set(ByVal value As String)
            _CodigoClie = value
        End Set
    End Property
    Public Property TotalVenta() As Double
        Get
            Return _TotalVenta
        End Get
        Set(ByVal value As Double)
            _TotalVenta = value
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
    Public Property IGV() As Double
        Get
            Return _IGV
        End Get
        Set(ByVal value As Double)
            _IGV = value
        End Set
    End Property
    Public Property Estado() As String
        Get
            Return _Estado
        End Get
        Set(ByVal value As String)
            _Estado = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal aCodigo As String)
        _Codigo = aCodigo

    End Sub
    Public Sub New(ByVal aCodigo As String, ByVal aFecha As String, ByVal aCodigoClie As String, ByVal aTotalVenta As Double,
                   ByVal aSubTotal As Double, ByVal aIgv As Double, ByVal aEstado As String)
        _Codigo = aCodigo
        _CodigoClie = aCodigoClie
        _Estado = aEstado
        _Fecha = aFecha
        _IGV = aIgv
        _SubTotal = aSubTotal
        _TotalVenta = aTotalVenta

    End Sub
    Dim detalle As List(Of DetalleVenta) = New List(Of DetalleVenta)
    Public Property DetalleVenta() As List(Of DetalleVenta)
        Get
            Return detalle

        End Get
        Set(value As List(Of DetalleVenta))

            detalle = value

        End Set

    End Property
End Class
