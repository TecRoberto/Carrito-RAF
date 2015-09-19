Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data.SqlClient
Imports System.Data
Public Class ClaseAyuda
    Public da As SqlDataAdapter
    Dim cad As String = "Data Source=.;Initial Catalog=BDCANASTA;Integrated Security=True"

    Public Function BuscarClientePorDni(dni As String) As DataSet
        Dim ds As New DataSet()
        Dim con As New SqlConnection()
        con.ConnectionString = cad
        con.Open()
        da = New SqlDataAdapter("PA_BuscarClientePorDni", con)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@Dni", SqlDbType.Char, 10).Value = dni
        Try
            da.Fill(ds)

        Catch ex As Exception

            Throw ex

        End Try
        Return ds

    End Function

End Class
