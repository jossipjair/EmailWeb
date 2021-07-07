Imports System.Data
Imports System.Data.SqlClient

Public Class Clientes

    Public Conexion As New SqlConnection("data source=ALUMNO4;initial catalog=DBFINANCIERA;integrated security=true")
    Public ds As DataSet
    Public adp As SqlDataAdapter


    Public Function Mostrar_Clientes() As DataTable

        adp = New SqlDataAdapter("select * from clientes", Conexion)
        ds = New DataSet
        adp.Fill(ds, "clientes")

        Return ds.Tables(0)

    End Function

End Class
