﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------
Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports System.ComponentModel
Namespace MontagneAdministracion

    Partial Public Class Usuarios
        Inherits XPLiteObject
        Dim fUsuarioID As String
        <Key()>
        <Size(30)>
        Public Property UsuarioID() As String
            Get
                Return fUsuarioID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("UsuarioID", fUsuarioID, value)
            End Set
        End Property
        Dim fContraseña As String
        <Size(60)>
        Public Property Contraseña() As String
            Get
                Return fContraseña
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Contraseña", fContraseña, value)
            End Set
        End Property
        Dim fApellidos As String
        <Size(30)>
        Public Property Apellidos() As String
            Get
                Return fApellidos
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Apellidos", fApellidos, value)
            End Set
        End Property
        Dim fNombres As String
        <Size(30)>
        Public Property Nombres() As String
            Get
                Return fNombres
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Nombres", fNombres, value)
            End Set
        End Property
        Dim fTelfonoParticular As String
        <Size(10)>
        Public Property TelfonoParticular() As String
            Get
                Return fTelfonoParticular
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TelfonoParticular", fTelfonoParticular, value)
            End Set
        End Property
        Dim fTelefonoCelular As String
        <Size(10)>
        Public Property TelefonoCelular() As String
            Get
                Return fTelefonoCelular
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TelefonoCelular", fTelefonoCelular, value)
            End Set
        End Property
        Dim fArea As String
        <Size(30)>
        Public Property Area() As String
            Get
                Return fArea
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Area", fArea, value)
            End Set
        End Property
        Dim fSeccionOficina As String
        <Size(30)>
        Public Property SeccionOficina() As String
            Get
                Return fSeccionOficina
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SeccionOficina", fSeccionOficina, value)
            End Set
        End Property
        Dim fEmail As String
        <Size(30)>
        Public Property Email() As String
            Get
                Return fEmail
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Email", fEmail, value)
            End Set
        End Property
        Dim fAprueba As Integer
        Public Property Aprueba() As Integer
            Get
                Return fAprueba
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Aprueba", fAprueba, value)
            End Set
        End Property
        Dim fCotiza As Integer
        Public Property Cotiza() As Integer
            Get
                Return fCotiza
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Cotiza", fCotiza, value)
            End Set
        End Property
        Dim fHabilitado As Integer
        Public Property Habilitado() As Integer
            Get
                Return fHabilitado
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Habilitado", fHabilitado, value)
            End Set
        End Property
    End Class

End Namespace
