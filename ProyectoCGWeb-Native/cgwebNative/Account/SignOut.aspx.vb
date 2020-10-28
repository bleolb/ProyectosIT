Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Partial Class SignOut
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs)
        If Request.IsAuthenticated Then
            ' Redireccionar a la página principal si se autentica el usuario.
            Response.Redirect("~/")
        End If
    End Sub
End Class
