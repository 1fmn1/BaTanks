Imports System.Runtime.InteropServices

Module SR2D
    Public Enum Op
        DefaultOp
        Paint
        AlphaTest
        AlphaBlend
        Add2D
        Add
        Mul
        Mul2X
        Max
        Min
        Blend
    End Enum

    Public Enum ColChannel
        ChBlue = 0
        ChGreen = 1
        ChRed = 2
        ChAlpha = 3
    End Enum

    Public Enum Transform
        None = 0
        FlipX = 1
        FlipY = 2
        FlipXY = 3
        RotCCW = 4
        RotCW = 5
        FlipXRotCCW = 6
        FlipYRotCCW = 7
        FlipXRotCW = 7
        FlipYRotCW = 6
    End Enum

    <DllImport("SR2D.dll", EntryPoint:="ARGB_")> _
    Public Function ARGB(ByVal A As Byte, ByVal R As Byte, ByVal G As Byte, ByVal B As Byte) As Integer
    End Function
    <DllImport("SR2D.dll", EntryPoint:="ARGB_")> _
    Public Function BitMask(ByVal i As Integer) As Integer
    End Function
End Module
