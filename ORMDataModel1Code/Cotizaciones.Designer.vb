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

    Partial Public Class Cotizaciones
        Inherits XPLiteObject
        Dim fIdCotizacion As Integer
        <Key(True)>
        Public Property IdCotizacion() As Integer
            Get
                Return fIdCotizacion
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IdCotizacion", fIdCotizacion, value)
            End Set
        End Property
        Dim fIdPedido As Integer
        Public Property IdPedido() As Integer
            Get
                Return fIdPedido
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IdPedido", fIdPedido, value)
            End Set
        End Property
        Dim fIdProveedor As Integer
        Public Property IdProveedor() As Integer
            Get
                Return fIdProveedor
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IdProveedor", fIdProveedor, value)
            End Set
        End Property
        Dim fFechaCotizacion As DateTime
        Public Property FechaCotizacion() As DateTime
            Get
                Return fFechaCotizacion
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("FechaCotizacion", fFechaCotizacion, value)
            End Set
        End Property
        Dim fAutorizada As Integer
        Public Property Autorizada() As Integer
            Get
                Return fAutorizada
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Autorizada", fAutorizada, value)
            End Set
        End Property
        Dim fResponsable As String
        <Size(250)>
        Public Property Responsable() As String
            Get
                Return fResponsable
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Responsable", fResponsable, value)
            End Set
        End Property
        Dim fMoneda As Integer
        Public Property Moneda() As Integer
            Get
                Return fMoneda
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Moneda", fMoneda, value)
            End Set
        End Property
        <Association("CotizacionDetalleReferencesCotizaciones")>
        Public ReadOnly Property CotizacionDetalles() As XPCollection(Of CotizacionDetalle)
            Get
                Return GetCollection(Of CotizacionDetalle)("CotizacionDetalles")
            End Get
        End Property
    End Class

End Namespace
