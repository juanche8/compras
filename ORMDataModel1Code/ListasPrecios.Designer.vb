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

    Partial Public Class ListasPrecios
        Inherits XPLiteObject
        Dim fIdLista As Integer
        <Key(True)>
        Public Property IdLista() As Integer
            Get
                Return fIdLista
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IdLista", fIdLista, value)
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
        Dim fIdProducto As Integer
        Public Property IdProducto() As Integer
            Get
                Return fIdProducto
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IdProducto", fIdProducto, value)
            End Set
        End Property
        Dim fPrecioBase As Decimal
        Public Property PrecioBase() As Decimal
            Get
                Return fPrecioBase
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PrecioBase", fPrecioBase, value)
            End Set
        End Property
        Dim fPrecioUnitario As Decimal
        Public Property PrecioUnitario() As Decimal
            Get
                Return fPrecioUnitario
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PrecioUnitario", fPrecioUnitario, value)
            End Set
        End Property
        Dim fDescuento As Decimal
        Public Property Descuento() As Decimal
            Get
                Return fDescuento
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("Descuento", fDescuento, value)
            End Set
        End Property
        Dim fFechaModificacion As DateTime
        Public Property FechaModificacion() As DateTime
            Get
                Return fFechaModificacion
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("FechaModificacion", fFechaModificacion, value)
            End Set
        End Property
        Dim fObservaciones As String
        <Size(SizeAttribute.Unlimited)>
        Public Property Observaciones() As String
            Get
                Return fObservaciones
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Observaciones", fObservaciones, value)
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
    End Class

End Namespace