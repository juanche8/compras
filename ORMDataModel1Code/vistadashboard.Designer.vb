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

    <NonPersistent()>
    Partial Public Class vistadashboard
        Inherits XPLiteObject
        Dim fCantidad As Decimal
        Public Property Cantidad() As Decimal
            Get
                Return fCantidad
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("Cantidad", fCantidad, value)
            End Set
        End Property
        Dim fResponsable As String
        <Size(200)>
        Public Property Responsable() As String
            Get
                Return fResponsable
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Responsable", fResponsable, value)
            End Set
        End Property
        Dim fFechaPedido As DateTime
        Public Property FechaPedido() As DateTime
            Get
                Return fFechaPedido
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("FechaPedido", fFechaPedido, value)
            End Set
        End Property
        Dim fAutorizadoPor As String
        <Size(255)>
        Public Property AutorizadoPor() As String
            Get
                Return fAutorizadoPor
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("AutorizadoPor", fAutorizadoPor, value)
            End Set
        End Property
        Dim fUrgente As String
        <Size(20)>
        Public Property Urgente() As String
            Get
                Return fUrgente
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Urgente", fUrgente, value)
            End Set
        End Property
        Dim fSectores_Sector As String
        <Size(80)>
        Public Property Sectores_Sector() As String
            Get
                Return fSectores_Sector
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Sectores_Sector", fSectores_Sector, value)
            End Set
        End Property
        Dim fProducto As String
        Public Property Producto() As String
            Get
                Return fProducto
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Producto", fProducto, value)
            End Set
        End Property
        Dim fEstado As String
        <Size(50)>
        Public Property Estado() As String
            Get
                Return fEstado
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Estado", fEstado, value)
            End Set
        End Property
    End Class

End Namespace
