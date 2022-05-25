Imports MySql.Data.MySqlClient
Public Class Form1
    Public conexion As New MySqlConnection("server=10.1.0.4; database=Nuevo ;user=Prueba ; password='Prueba1'")
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conexion.Open()
            MsgBox("CONEXION REALIZADA 
CONECTADO BASE DE DATOS= Prueba@10.1.0.4")
            CargarDatos()
        Catch ex As Exception
            MsgBox("CONEXION FALLIDA" & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If conexion.State = ConnectionState.Closed Then
            conexion.Open()
        End If
        Dim cmd As New MySqlCommand("INSERT INTO NOMBRES VALUES(" & Me.TextBox1.Text & ",'" & Me.TextBox2.Text & "')", conexion)
        cmd.ExecuteNonQuery()
        MsgBox("Datos insertados correctamente")
        CargarDatos()
        Limpiar()
    End Sub

    Private Sub CargarDatos()
        Dim datos As New MySqlDataAdapter("SELECT * FROM NOMBRES", conexion)
        Dim ds As New DataSet()
        datos.Fill(ds, "NOMBRES")

        Me.DataGridView1.DataSource = ds.Tables("NOMBRES")
    End Sub

    Private Sub Limpiar()
        Me.TextBox1.Text = ""
        Me.TextBox2.Text = ""
    End Sub

End Class
