Module modAPI

    'Private Declare Function QueryPerformanceCounter Lib "kernel32" (lpPerformanceCount As int64) As Long
    'Private Declare Function QueryPerformanceFrequency Lib "kernel32" (lpFrequency As Int64) As Long
    Public Declare Function GetTickCount Lib "kernel32" Alias "GetTickCount" () As Long
    Dim QSpeed As Double, Ri As Double

    'Public Function QTime() As Double
    '    Dim QD As Long, T As Double

    '    QueryPerformanceCounter(QD)
    '    If QD.dw1 < 0& Then T = QD.dw1 + 4294967296.0# Else T = QD.dw1
    '    If QD.dw2 < 0& Then T = T + (QD.dw2 + 4294967296.0#) * 4294967296.0# Else T = T + QD.dw2 * 4294967296.0#
    '    QTime = T * QSpeed
    'End Function

    'Public Sub QTimeInit()
    '    Dim QD As int64

    '    QueryPerformanceFrequency(QD)
    '    If QD.dw1 < 0& Then QSpeed = QD.dw1 + 4294967296.0# Else QSpeed = QD.dw1
    '    If QD.dw2 < 0& Then QSpeed = QSpeed + (QD.dw2 + 4294967296.0#) * 4294967296.0# Else QSpeed = QSpeed + QD.dw2 * 4294967296.0#
    '    QSpeed = 1.0# / QSpeed
    'End Sub

    Public Function Rand() As Single
        Ri = 1.314 * Ri + 1.737
        If Ri > 983732.3456 Then Ri = Ri * 0.3141
        Rand = Ri - Int(Ri)
    End Function

    Public Sub RandInit(ByVal R As Single)
        Ri = R
    End Sub

End Module
