Public Class Cliente
    Private _Codigo As String
    Private _Dni As String
    Private _Nombres As String
    Private _Email As String
    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property
    Public Property Dni() As String
        Get
            Return _Dni
        End Get
        Set(ByVal value As String)
            _Dni = value
        End Set
    End Property
    Public Property Nombres() As String
        Get
            Return _Nombres
        End Get
        Set(ByVal value As String)
            _Nombres = value
        End Set
    End Property
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal aCodigo As String)
        _Codigo = aCodigo

    End Sub
    Public Sub New(ByVal aCodigo As String, ByVal aDni As String, ByVal aNombres As String, ByVal aEmail As String)
        _Codigo = aCodigo
        _Dni = aDni
        _Nombres = aNombres
        _Email = aEmail


    End Sub

End Class
