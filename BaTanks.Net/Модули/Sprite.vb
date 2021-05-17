Imports System.Runtime.InteropServices

Friend Class Sprite
  Private Structure BITMAPINFOHEADER
    Dim biSize As Integer
    Dim biWidth As Integer
    Dim biHeight As Integer
    Dim biPlanes As Short
    Dim biBitCount As Short
    Dim biCompression As Integer
    Dim biSizeImage As Integer
    Dim biXPelsPerMeter As Double
    Dim biClrUsed As Double
  End Structure

  Private Structure BITMAPINFO
    Dim bmiHeader As BITMAPINFOHEADER
    Dim bmiColors As Integer
  End Structure

  <System.Runtime.InteropServices.DllImport("gdi32")> _
  Private Shared Function SetDIBitsToDevice(ByVal hDC As HandleRef, ByVal x As Integer, ByVal y As Integer, ByVal Dx As Integer, ByVal Dy As Integer, ByVal SrcX As Integer, ByVal SrcY As Integer, ByVal Scan As Integer, ByVal NumScans As Integer, ByRef Bits As Integer, ByRef BitsInfo As BITMAPINFO, ByVal wUsage As Integer) As Integer
  End Function

  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="COPY_MEMORY")> _
  Private Shared Sub CopyMemory(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal Length As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="CLEAR_C")> _
  Private Shared Sub SClearC(ByRef Dest As Integer, ByVal W As Integer, ByVal H As Integer, ByVal WD As Integer, ByVal c As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="V_MUL_ADD")> _
  Private Shared Sub SMulAdd(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal W As Integer, ByVal H As Integer, ByVal WS As Integer, ByVal WD As Integer, ByVal VMul As Integer, ByVal VAdd As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="MASK_V_MUL_ADD")> _
  Private Shared Sub SMaskMulAdd(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal pMask As Integer, ByVal W As Integer, ByVal H As Integer, ByVal MaskEx As Integer, ByVal WS As Integer, ByVal WD As Integer, ByVal WM As Integer, ByVal NotMask As Integer, ByVal VMul As Integer, ByVal VAdd As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="MASK_CLEAR_C")> _
  Private Shared Sub SMaskClearC(ByVal pDest As Integer, ByVal pMask As Integer, ByVal W As Integer, ByVal H As Integer, ByVal MaskEx As Integer, ByVal WD As Integer, ByVal WM As Integer, ByVal c As Integer, ByVal NotMask As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="MASK_INTERSECT")> _
  Private Shared Function SMaskIS(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal W As Integer, ByVal H As Integer, ByVal WS As Integer, ByVal WD As Integer, ByVal MaskEx As Integer) As Integer
  End Function
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="RESIZE")> _
  Private Shared Sub SResize(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal WS As Integer, ByVal HS As Integer, ByVal WD As Integer, ByVal HD As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="FLIP_X")> _
  Private Shared Sub SFlipX(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal W As Integer, ByVal H As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="FLIP_Y")> _
  Private Shared Sub SFlipY(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal W As Integer, ByVal H As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="FLIP_XY")> _
  Private Shared Sub SFlipXY(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal W As Integer, ByVal H As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="ROT_CW")> _
  Private Shared Sub SRotCW(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal WS As Integer, ByVal HS As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="ROT_CCW")> _
  Private Shared Sub SRotCCW(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal WS As Integer, ByVal HS As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="FLIP_X_ROT_CCW")> _
  Private Shared Sub SFlipXRotCCW(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal WS As Integer, ByVal HS As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="FLIP_Y_ROT_CCW")> _
  Private Shared Sub SFlipYRotCCW(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal WS As Integer, ByVal HS As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="DRAW_ROT")> _
  Private Shared Sub SDrawRot(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal L As Integer, ByVal T As Integer, ByVal W As Integer, ByVal H As Integer, ByVal Sx As Integer, ByVal Sy As Integer, ByVal Dx As Integer, ByVal Dy As Integer, ByVal sw As Integer, ByVal sh As Integer, ByVal dw As Integer, ByVal SinA As Integer, ByVal CosA As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="DRAW_ROT_AA")> _
  Private Shared Sub SDrawRotAA(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal L As Integer, ByVal T As Integer, ByVal W As Integer, ByVal H As Integer, ByVal Sx As Integer, ByVal Sy As Integer, ByVal Dx As Integer, ByVal Dy As Integer, ByVal sw As Integer, ByVal sh As Integer, ByVal dw As Integer, ByVal SinA As Integer, ByVal CosA As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="ADD_COLOR_KEY")> _
  Private Shared Sub SAddColorKey(ByVal pSrc As Integer, ByVal W As Integer, ByVal H As Integer, ByVal cKey As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="BPP_32TO24")> _
  Private Shared Sub Bpp32to24(ByRef Src As Integer, ByRef Dest As Byte, ByVal Width As Integer, ByVal Height As Integer, ByVal Stride As Integer)
  End Sub

  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="PAINT")> _
  Private Shared Sub SPaint(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal W As Integer, ByVal H As Integer, ByVal WS As Integer, ByVal WD As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="MOD_2X")> _
  Private Shared Sub SMul2X(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal W As Integer, ByVal H As Integer, ByVal WS As Integer, ByVal WD As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="ADD_2D")> _
  Private Shared Sub SAdd2D(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal W As Integer, ByVal H As Integer, ByVal WS As Integer, ByVal WD As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="ADD_")> _
  Private Shared Sub SAdd(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal W As Integer, ByVal H As Integer, ByVal WS As Integer, ByVal WD As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="MOD_")> _
  Private Shared Sub SMul(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal W As Integer, ByVal H As Integer, ByVal WS As Integer, ByVal WD As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="ALPHA_T")> _
  Private Shared Sub SAlphaTest(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal W As Integer, ByVal H As Integer, ByVal WS As Integer, ByVal WD As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="ALPHA_B")> _
  Private Shared Sub SAlphaBlend(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal W As Integer, ByVal H As Integer, ByVal WS As Integer, ByVal WD As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="MOVE_BYTE")> _
  Private Shared Sub SMoveByte(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal W As Integer, ByVal H As Integer, ByVal WS As Integer, ByVal WD As Integer, ByVal MoveSrc As Integer, ByVal MoveDest As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="MOVE_BIT")> _
  Private Shared Sub SMoveBit(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal W As Integer, ByVal H As Integer, ByVal WS As Integer, ByVal WD As Integer, ByVal MoveSrc As Integer, ByVal MoveDest As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="MAX_")> _
  Private Shared Sub SMax(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal W As Integer, ByVal H As Integer, ByVal WS As Integer, ByVal WD As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="MIN_")> _
  Private Shared Sub SMin(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal W As Integer, ByVal H As Integer, ByVal WS As Integer, ByVal WD As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="BLEND")> _
  Private Shared Sub SBlend(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal W As Integer, ByVal H As Integer, ByVal WS As Integer, ByVal WD As Integer, ByVal k As Integer)
  End Sub

  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="MASK_PAINT")> _
  Private Shared Sub SMaskPaint(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal pMask As Integer, ByVal W As Integer, ByVal H As Integer, ByVal MaskEx As Integer, ByVal WS As Integer, ByVal WD As Integer, ByVal WM As Integer, ByVal NotMask As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="MASK_MOD_2X")> _
  Private Shared Sub SMaskMul2X(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal pMask As Integer, ByVal W As Integer, ByVal H As Integer, ByVal MaskEx As Integer, ByVal WS As Integer, ByVal WD As Integer, ByVal WM As Integer, ByVal NotMask As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="MASK_ADD_2D")> _
  Private Shared Sub SMaskAdd2D(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal pMask As Integer, ByVal W As Integer, ByVal H As Integer, ByVal MaskEx As Integer, ByVal WS As Integer, ByVal WD As Integer, ByVal WM As Integer, ByVal NotMask As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="MASK_ADD")> _
  Private Shared Sub SMaskAdd(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal pMask As Integer, ByVal W As Integer, ByVal H As Integer, ByVal MaskEx As Integer, ByVal WS As Integer, ByVal WD As Integer, ByVal WM As Integer, ByVal NotMask As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="MASK_MOD")> _
  Private Shared Sub SMaskMul(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal pMask As Integer, ByVal W As Integer, ByVal H As Integer, ByVal MaskEx As Integer, ByVal WS As Integer, ByVal WD As Integer, ByVal WM As Integer, ByVal NotMask As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="MASK_ALPHA_T")> _
  Private Shared Sub SMaskAlphaTest(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal pMask As Integer, ByVal W As Integer, ByVal H As Integer, ByVal MaskEx As Integer, ByVal WS As Integer, ByVal WD As Integer, ByVal WM As Integer, ByVal NotMask As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="MASK_ALPHA_B")> _
  Private Shared Sub SMaskAlphaBlend(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal pMask As Integer, ByVal W As Integer, ByVal H As Integer, ByVal MaskEx As Integer, ByVal WS As Integer, ByVal WD As Integer, ByVal WM As Integer, ByVal NotMask As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="MASK_MOVE_BYTE")> _
  Private Shared Sub SMaskMoveByte(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal pMask As Integer, ByVal W As Integer, ByVal H As Integer, ByVal MaskEx As Integer, ByVal WS As Integer, ByVal WD As Integer, ByVal WM As Integer, ByVal NotMask As Integer, ByVal MoveSrc As Integer, ByVal MoveDest As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="MASK_MOVE_BIT")> _
  Private Shared Sub SMaskMoveBit(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal pMask As Integer, ByVal W As Integer, ByVal H As Integer, ByVal MaskEx As Integer, ByVal WS As Integer, ByVal WD As Integer, ByVal WM As Integer, ByVal NotMask As Integer, ByVal MoveSrc As Integer, ByVal MoveDest As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="MASK_MAX")> _
  Private Shared Sub SMaskMax(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal pMask As Integer, ByVal W As Integer, ByVal H As Integer, ByVal MaskEx As Integer, ByVal WS As Integer, ByVal WD As Integer, ByVal WM As Integer, ByVal NotMask As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="MASK_MIN")> _
  Private Shared Sub SMaskMin(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal pMask As Integer, ByVal W As Integer, ByVal H As Integer, ByVal MaskEx As Integer, ByVal WS As Integer, ByVal WD As Integer, ByVal WM As Integer, ByVal NotMask As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="MASK_BLEND")> _
  Private Shared Sub SMaskBlend(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal pMask As Integer, ByVal W As Integer, ByVal H As Integer, ByVal MaskEx As Integer, ByVal WS As Integer, ByVal WD As Integer, ByVal WM As Integer, ByVal NotMask As Integer, ByVal k As Integer)
  End Sub

  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="EBM_")> _
  Private Shared Sub SDrawEBM(ByVal pBMap As Integer, ByVal pDest As Integer, ByVal pLMap As Integer, ByVal W As Integer, ByVal H As Integer, ByVal WB As Integer, ByVal WD As Integer, ByVal WL As Integer, ByVal HL As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="EBM_EX")> _
  Private Shared Sub SDrawEBMEx(ByVal pBMap As Integer, ByVal pDest As Integer, ByVal pLMap As Integer, ByVal W As Integer, ByVal H As Integer, ByVal WB As Integer, ByVal WD As Integer, ByVal WL As Integer, ByVal HL As Integer, ByVal xx As Integer, ByVal yy As Integer, ByVal HD As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="DPBM_")> _
  Private Shared Sub SDrawDPBM(ByVal pBMap As Integer, ByVal pDest As Integer, ByVal W As Integer, ByVal H As Integer, ByVal c As Integer, ByVal WS As Integer, ByVal WD As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="DPBM_POINT")> _
  Private Shared Sub SDrawDPBMPoint(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal W As Integer, ByVal H As Integer, ByVal WS As Integer, ByVal WD As Integer, ByVal Lx As Integer, ByVal Ly As Integer, ByVal Lz As Integer, ByVal Br As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="MASK_DPBM_POINT")> _
  Private Shared Sub SMaskDrawDPBMPoint(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal pMask As Integer, ByVal MaskEx As Integer, ByVal W As Integer, ByVal H As Integer, ByVal WS As Integer, ByVal WD As Integer, ByVal WM As Integer, ByVal Lx As Integer, ByVal Ly As Integer, ByVal Lz As Integer, ByVal Br As Integer, ByVal NotMask As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="MASK_DPBM")> _
  Private Shared Sub SMaskDrawDPBM(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal pMask As Integer, ByVal W As Integer, ByVal H As Integer, ByVal c As Integer, ByVal MaskEx As Integer, ByVal WS As Integer, ByVal WD As Integer, ByVal WM As Integer, ByVal NotMask As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="MASK_EBM")> _
  Private Shared Sub SMaskDrawEBM(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal pMask As Integer, ByVal pLMap As Integer, ByVal MaskEx As Integer, ByVal W As Integer, ByVal H As Integer, ByVal WS As Integer, ByVal WD As Integer, ByVal WM As Integer, ByVal WL As Integer, ByVal HL As Integer, ByVal NotMask As Integer)
  End Sub
  <System.Runtime.InteropServices.DllImport("SR2D", EntryPoint:="MASK_EBM_EX")> _
  Private Shared Sub SMaskDrawEBMEx(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal pMask As Integer, ByVal pLMap As Integer, ByVal MaskEx As Integer, ByVal W As Integer, ByVal H As Integer, ByVal WS As Integer, ByVal WD As Integer, ByVal WM As Integer, ByVal WL As Integer, ByVal HL As Integer, ByVal NotMask As Integer, ByVal xx As Integer, ByVal yy As Integer, ByVal HD As Integer)
  End Sub

  Dim meWidth, meHeight As Integer
  Dim meOp As SR2D.Op
  Dim meTop, meLeft, meRight, meBottom As Integer
  Dim cBuf() As Integer
  Dim meBFactor As Integer
  Dim bi32BitInfo As BITMAPINFO
  Dim GCH As GCHandle
  Dim PTR As Integer

  Private Function TransformCoordAbs(ByVal L2 As Integer, ByVal R2 As Integer, ByVal T2 As Integer, ByVal B2 As Integer, ByVal W2 As Integer, ByRef W As Integer, ByRef H As Integer, ByRef P1 As Integer, ByRef P2 As Integer) As Boolean
    Dim T, L, R, B As Integer

    L = If(0 >= L2, 0, L2)
    R = If(meWidth <= R2, meWidth, R2)
    If L >= R Then Exit Function
    T = If(0 >= T2, 0, T2)
    B = If(meHeight <= B2, meHeight, B2)
    If T >= B Then Exit Function

    TransformCoordAbs = True
    W = R - L
    H = B - T

    P1 = (T * meWidth + L) << 2
    P2 = ((T - T2) * W2 + L - L2) << 2
  End Function

  Private Function TransformCoord2(ByVal L2 As Integer, ByVal R2 As Integer, ByVal T2 As Integer, ByVal B2 As Integer, ByVal W2 As Integer, ByRef W As Integer, ByRef H As Integer, ByRef P1 As Integer, ByRef P2 As Integer) As Boolean
    Dim T, L, R, B As Integer

    L = If(meLeft >= L2, meLeft, L2)
    R = If(meRight <= R2, meRight, R2)
    If L >= R Then Exit Function
    T = If(meTop >= T2, meTop, T2)
    B = If(meBottom <= B2, meBottom, B2)
    If T >= B Then Exit Function

    TransformCoord2 = True
    W = R - L
    H = B - T

    P1 = ((T - meTop) * meWidth + L - meLeft) << 2
    P2 = ((T - T2) * W2 + L - L2) << 2
  End Function

  Private Function TransformCoord3(ByVal L2 As Integer, ByVal R2 As Integer, ByVal T2 As Integer, ByVal B2 As Integer, ByVal L3 As Integer, ByVal R3 As Integer, ByVal T3 As Integer, ByVal B3 As Integer, ByVal W2 As Integer, ByVal W3 As Integer, ByRef W As Integer, ByRef H As Integer, ByRef P1 As Integer, ByRef P2 As Integer, ByRef P3 As Integer) As Boolean
    Dim T, L, R, B As Integer

    L = If(meLeft >= L2, meLeft, L2)
    If L < L3 Then L = L3
    R = If(meRight <= R2, meRight, R2)
    If R > R3 Then R = R3
    If L >= R Then Exit Function
    T = If(meTop >= T2, meTop, T2)
    If T < T3 Then T = T3
    B = If(meBottom <= B2, meBottom, B2)
    If B > b3 Then B = b3
    If T >= B Then Exit Function

    TransformCoord3 = True
    W = R - L
    H = B - T

    P1 = ((T - meTop) * meWidth + L - meLeft) << 2
    P2 = ((T - T2) * W2 + L - L2) << 2
    P3 = ((T - T3) * W3 + L - L3) << 2
  End Function

  Public Sub ClearBuffer(ByVal c As Integer)
    If meRight <= meLeft Then Exit Sub
    If meBottom <= meTop Then Exit Sub
    SClearC(cBuf(meLeft + meTop * meWidth), meRight - meLeft, meBottom - meTop, meWidth, c)
  End Sub

  Public Sub MaskClearBuffer(ByRef SrcMask As Sprite, ByVal MaskX As Integer, ByVal MaskY As Integer, ByVal c As Integer, ByVal Mask As Integer, Optional ByVal NotMask As Boolean = False)
    Dim Mp, W, H, Dp As Integer

    If Not TransformCoord2(MaskX, MaskX + SrcMask.Width, MaskY, MaskY + SrcMask.Height, SrcMask.Width, W, H, Dp, Mp) Then Exit Sub

    Dp = Dp + DataPTR(meLeft, meTop)
    Mp = Mp + SrcMask.PTR

    SMaskClearC(Dp, Mp, W, H, Mask, meWidth, SrcMask.Width, c, NotMask)
  End Sub

  Public Sub ClearRect(ByVal PLeft As Integer, ByVal PRight As Integer, ByVal Top As Integer, ByVal Bottom As Integer, ByVal c As Integer)
    If PLeft < meLeft Then PLeft = meLeft
    If PRight > meRight Then PRight = meRight
    If PRight <= PLeft Then Exit Sub
    If Top < meTop Then Top = meTop
    If Bottom > meBottom Then Bottom = meBottom
    If Bottom <= Top Then Exit Sub
    SClearC(cBuf(PLeft + Top * meWidth), PRight - PLeft, Bottom - Top, meWidth, c)
  End Sub

  Public Sub DrawRotate(ByRef Src As Sprite, ByVal Sx As Integer, ByVal Sy As Integer, ByVal Dx As Integer, ByVal Dy As Integer, ByVal Angle As Single, Optional ByVal AA As Boolean = False)
    Dim sw, sh As Integer
    Dim ddx, ddy As Integer
    Dim SinA, CosA As Integer
    Dim T, L, R, B As Integer
    Dim x, y As Integer

    If meRight <= meLeft Then Exit Sub
    If meBottom <= meTop Then Exit Sub
    sw = Src.Width
    sh = Src.Height
    ddx = (Dx << 16) + &H8000
    ddy = (Dy << 16) + &H8000
    SinA = System.Math.Sin(Angle) * &H10000
    CosA = System.Math.Cos(Angle) * &H10000

    L = ddx - Sx * CosA - Sy * SinA
    R = L
    x = ddx - (Sx - sw) * CosA - Sy * SinA
    If L > x Then L = x
    If R < x Then R = x
    x = ddx - Sx * CosA - (Sy - sh) * SinA
    If L > x Then L = x
    If R < x Then R = x
    x = ddx - (Sx - sw) * CosA - (Sy - sh) * SinA
    If L > x Then L = x
    If R < x Then R = x

    T = ddy - Sy * CosA + Sx * SinA
    B = T
    y = ddy - (Sy - sh) * CosA + Sx * SinA
    If T > y Then T = y
    If B < y Then B = y
    y = ddy - Sy * CosA + (Sx - sw) * SinA
    If T > y Then T = y
    If B < y Then B = y
    y = ddy - (Sy - sh) * CosA + (Sx - sw) * SinA
    If T > y Then T = y
    If B < y Then B = y

    L = L >> 16
    If L < meLeft Then L = meLeft
    T = T >> 16
    If T < meTop Then T = meTop
    R = R >> 16
    If R >= meRight Then R = meRight Else R = R + 1
    B = B >> 16
    If B >= meBottom Then B = meBottom Else B = B + 1
    If AA Then
      SDrawRotAA(Src.PTR, PTR, L, T, R, B, Sx, Sy, Dx, Dy, sw, sh, meWidth, SinA, CosA)
    Else
      SDrawRot(Src.PTR, PTR, L, T, R, B, Sx, Sy, Dx, Dy, sw, sh, meWidth, SinA, CosA)
    End If
  End Sub

  Public Sub DrawDPBM(ByRef Src As Sprite, ByVal Sx As Integer, ByVal Sy As Integer, ByVal Lx As Integer, ByVal Ly As Integer, ByVal Lz As Integer, Optional ByVal Brite As Single = 1, Optional ByVal PointLite As Boolean = False)
    Dim Sp, W, H, Dp As Integer

    If Not TransformCoord2(Sx, Sx + Src.Width, Sy, Sy + Src.Height, Src.Width, W, H, Dp, Sp) Then Exit Sub

    Dp = Dp + DataPTR(meLeft, meTop)
    Sp = Sp + Src.PTR

    If PointLite Then
      If meLeft < Sx Then Lx = Lx - Sx Else Lx = Lx - meLeft
      If meTop < Sy Then Ly = Ly - Sy Else Ly = Ly - meTop
      If Brite < -2 Then
        Brite = -2
      ElseIf Brite > 2 Then
        Brite = 2
      End If
      SDrawDPBMPoint(Sp, Dp, W, H, Src.Width, meWidth, Lx, Ly, Lz, Brite * &H100000)
    Else
      SDrawDPBM(Sp, Dp, W, H, ColFromLite(Lx, Ly, Lz, Brite), Src.Width, meWidth)
    End If
  End Sub

  Public Sub MaskDrawDPBM(ByRef Src As Sprite, ByRef SrcMask As Sprite, ByVal Sx As Integer, ByVal Sy As Integer, ByVal MaskX As Integer, ByVal MaskY As Integer, ByVal Mask As Integer, ByVal Lx As Integer, ByVal Ly As Integer, ByVal Lz As Integer, Optional ByVal Brite As Single = 1, Optional ByVal NotMask As Boolean = False, Optional ByVal PointLite As Boolean = False)
    Dim Dp, H, W, Sp, Mp As Integer

    If Not TransformCoord3(Sx, Sx + Src.Width, Sy, Sy + Src.Height, MaskX, MaskX + SrcMask.Width, MaskY, MaskY + SrcMask.Height, Src.Width, SrcMask.Width, W, H, Dp, Sp, Mp) Then Exit Sub

    Dp = Dp + PTR
    Sp = Sp + Src.PTR
    Mp = Mp + SrcMask.PTR

    If PointLite Then
      If meLeft < Sx Then
        If MaskX < Sx Then
          Lx = Lx - Sx
        Else
          Lx = Lx - MaskX
        End If
      Else
        If MaskX < meLeft Then
          Lx = Lx - meLeft
        Else
          Lx = Lx - MaskX
        End If
      End If

      If meTop < Sy Then
        If MaskY < Sy Then
          Ly = Ly - Sy
        Else
          Ly = Ly - MaskY
        End If
      Else
        If MaskY < meTop Then
          Ly = Ly - meTop
        Else
          Ly = Ly - MaskY
        End If
      End If

      If Brite < -2 Then
        Brite = -2
      ElseIf Brite > 2 Then
        Brite = 2
      End If
      SMaskDrawDPBMPoint(Sp, Dp, Mp, Mask, W, H, Src.Width, meWidth, SrcMask.Width, Lx, Ly, Lz, Brite * &H100000, NotMask)
    Else
      SMaskDrawDPBM(Sp, Dp, Mp, W, H, ColFromLite(Lx, Ly, Lz, Brite), Mask, Src.Width, meWidth, SrcMask.Width, NotMask)
    End If
  End Sub

  Public Sub Draw(ByRef Src As Sprite, ByVal Sx As Integer, ByVal Sy As Integer, Optional ByVal Op As SR2D.Op = SR2D.Op.DefaultOp)
    Dim Sp, W, H, Dp As Integer

    If Not TransformCoord2(Sx, Sx + Src.Width, Sy, Sy + Src.Height, Src.Width, W, H, Dp, Sp) Then Exit Sub

    Dp = Dp + DataPTR(meLeft, meTop)
    Sp = Sp + Src.PTR

    If Op = SR2D.Op.DefaultOp Then Op = Src.Op
    Select Case Op
      Case SR2D.Op.Paint
        SPaint(Sp, Dp, W, H, Src.Width, meWidth)
      Case SR2D.Op.AlphaTest
        SAlphaTest(Sp, Dp, W, H, Src.Width, meWidth)
      Case SR2D.Op.AlphaBlend
        SAlphaBlend(Sp, Dp, W, H, Src.Width, meWidth)
      Case SR2D.Op.Add2D
        SAdd2D(Sp, Dp, W, H, Src.Width, meWidth)
      Case SR2D.Op.Add
        SAdd(Sp, Dp, W, H, Src.Width, meWidth)
      Case SR2D.Op.Mul2X
        SMul2X(Sp, Dp, W, H, Src.Width, meWidth)
      Case SR2D.Op.Mul
        SMul(Sp, Dp, W, H, Src.Width, meWidth)
      Case SR2D.Op.Blend
        SBlend(Sp, Dp, W, H, Src.Width, meWidth, Src.BlendFactor)
      Case SR2D.Op.Max
        SMax(Sp, Dp, W, H, Src.Width, meWidth)
      Case SR2D.Op.Min
        SMin(Sp, Dp, W, H, Src.Width, meWidth)
    End Select
  End Sub

  Public Sub MaskDraw(ByRef Src As Sprite, ByRef SrcMask As Sprite, ByVal Sx As Integer, ByVal Sy As Integer, ByVal MaskX As Integer, ByVal MaskY As Integer, ByVal Mask As Integer, Optional ByVal NotMask As Boolean = False, Optional ByVal Op As SR2D.Op = SR2D.Op.DefaultOp)
    Dim Dp, H, W, Sp, Mp As Integer

    If Not TransformCoord3(Sx, Sx + Src.Width, Sy, Sy + Src.Height, MaskX, MaskX + SrcMask.Width, MaskY, MaskY + SrcMask.Height, Src.Width, SrcMask.Width, W, H, Dp, Sp, Mp) Then Exit Sub

    Dp = Dp + PTR
    Sp = Sp + Src.PTR
    Mp = Mp + SrcMask.PTR

    If Op = SR2D.Op.DefaultOp Then Op = Src.Op
    Select Case Op
      Case SR2D.Op.Paint
        SMaskPaint(Sp, Dp, Mp, W, H, Mask, Src.Width, meWidth, SrcMask.Width, NotMask)
      Case SR2D.Op.Mul2X
        SMaskMul2X(Sp, Dp, Mp, W, H, Mask, Src.Width, meWidth, SrcMask.Width, NotMask)
      Case SR2D.Op.Add2D
        SMaskAdd2D(Sp, Dp, Mp, W, H, Mask, Src.Width, meWidth, SrcMask.Width, NotMask)
      Case SR2D.Op.Add
        SMaskAdd(Sp, Dp, Mp, W, H, Mask, Src.Width, meWidth, SrcMask.Width, NotMask)
      Case SR2D.Op.Mul
        SMaskMul(Sp, Dp, Mp, W, H, Mask, Src.Width, meWidth, SrcMask.Width, NotMask)
      Case SR2D.Op.Blend
        SMaskBlend(Sp, Dp, Mp, W, H, Mask, Src.Width, meWidth, SrcMask.Width, NotMask, Src.BlendFactor)
      Case SR2D.Op.AlphaTest
        SMaskAlphaTest(Sp, Dp, Mp, W, H, Mask, Src.Width, meWidth, SrcMask.Width, NotMask)
      Case SR2D.Op.AlphaBlend
        SMaskAlphaBlend(Sp, Dp, Mp, W, H, Mask, Src.Width, meWidth, SrcMask.Width, NotMask)
      Case SR2D.Op.Max
        SMaskMax(Sp, Dp, Mp, W, H, Mask, Src.Width, meWidth, SrcMask.Width, NotMask)
      Case SR2D.Op.Min
        SMaskMin(Sp, Dp, Mp, W, H, Mask, Src.Width, meWidth, SrcMask.Width, NotMask)
    End Select
  End Sub

  Public Function MaskInterSector(ByRef Src As Sprite, ByVal Sx As Integer, ByVal Sy As Integer, ByVal Mask As Integer) As Integer
    Dim Sp, W, H, Dp As Integer

    If Not TransformCoordAbs(Sx, Sx + Src.Width, Sy, Sy + Src.Height, Src.Width, W, H, Dp, Sp) Then Exit Function

    Dp = Dp + PTR
    Sp = Sp + Src.PTR

    MaskInterSector = SMaskIS(Sp, Dp, W, H, Src.Width, meWidth, Mask)
  End Function

  Public Sub DrawEBM(ByRef SRCBump As Sprite, ByRef SRCCol As Sprite, ByVal Sx As Integer, ByVal Sy As Integer, Optional ByVal DestSpace As Boolean = False)
    Dim Sp, H, W, Dp, Cp As Integer

    If Not TransformCoord2(Sx, Sx + SRCBump.Width, Sy, Sy + SRCBump.Height, SRCBump.Width, W, H, Dp, Sp) Then Exit Sub

    Dp = Dp + PTR
    Sp = Sp + SRCBump.PTR
    Cp = SRCCol.PTR

    If DestSpace Then
      If Sx < 0 Then Sx = 0
      If Sy < 0 Then Sy = 0
      SDrawEBMEx(Sp, Dp, Cp, W, H, SRCBump.Width, meWidth, SRCCol.Width, SRCCol.Height, Sx, Sy, meHeight)
    Else
      SDrawEBM(Sp, Dp, Cp, W, H, SRCBump.Width, meWidth, SRCCol.Width, SRCCol.Height)
    End If
  End Sub

  Public Sub MaskDrawEBM(ByRef SRCBump As Sprite, ByRef SrcMask As Sprite, ByRef SRCCol As Sprite, ByVal Sx As Integer, ByVal Sy As Integer, ByVal MaskX As Integer, ByVal MaskY As Integer, ByVal Mask As Integer, Optional ByVal NotMask As Boolean = False, Optional ByVal DestSpace As Boolean = False)
    Dim Mp, Dp, W, H, Sp, Cp As Integer

    If Not TransformCoord3(Sx, Sx + SRCBump.Width, Sy, Sy + SRCBump.Height, MaskX, MaskX + SrcMask.Width, MaskY, MaskY + SrcMask.Height, SRCBump.Width, SrcMask.Width, W, H, Dp, Sp, Mp) Then Exit Sub

    Dp = Dp + PTR
    Sp = Sp + SRCBump.PTR
    Mp = Mp + SrcMask.PTR
    Cp = SRCCol.PTR

    If DestSpace Then
      If Sx < 0 Then Sx = 0
      If Sy < 0 Then Sy = 0
      SMaskDrawEBMEx(Sp, Dp, Mp, Cp, Mask, W, H, SRCBump.Width, meWidth, SrcMask.Width, SRCCol.Width, SRCCol.Height, NotMask, Sx, Sy, meHeight)
    Else
      SMaskDrawEBM(Sp, Dp, Mp, Cp, Mask, W, H, SRCBump.Width, meWidth, SrcMask.Width, SRCCol.Width, SRCCol.Height, NotMask)
    End If
  End Sub

  Public Sub MulAddS2X(ByRef Src As Sprite, ByVal Sx As Integer, ByVal Sy As Integer, ByVal Mul As Integer, ByVal Add As Integer)
    Dim Sp, W, H, Dp As Integer

    If Not TransformCoord2(Sx, Sx + Src.Width, Sy, Sy + Src.Height, Src.Width, W, H, Dp, Sp) Then Exit Sub

    Dp = Dp + DataPTR(meLeft, meTop)
    Sp = Sp + Src.PTR

    SMulAdd(Sp, Dp, W, H, Src.Width, meWidth, Mul, Add)
  End Sub

  Public Sub MaskMulAddS2X(ByRef Src As Sprite, ByRef SrcMask As Sprite, ByVal Sx As Integer, ByVal Sy As Integer, ByVal MaskX As Integer, ByVal MaskY As Integer, ByVal Mul As Integer, ByVal Add As Integer, ByVal Mask As Integer, Optional ByVal NotMask As Boolean = False)
    Dim Dp, H, W, Sp, Mp As Integer

    If Not TransformCoord3(Sx, Sx + Src.Width, Sy, Sy + Src.Height, MaskX, MaskX + SrcMask.Width, MaskY, MaskY + SrcMask.Height, Src.Width, SrcMask.Width, W, H, Dp, Sp, Mp) Then Exit Sub

    Dp = Dp + PTR
    Sp = Sp + Src.PTR
    Mp = Mp + SrcMask.PTR

    SMaskMulAdd(Sp, Dp, Mp, W, H, Mask, Src.Width, meWidth, SrcMask.Width, -CShort(NotMask), Mul, Add)
  End Sub

  Public Sub MoveByte(ByRef Src As Sprite, ByVal Sx As Integer, ByVal Sy As Integer, ByVal chSrc As SR2D.ColChannel, ByVal chDest As SR2D.ColChannel)
    Dim Sp, W, H, Dp As Integer

    If Not TransformCoord2(Sx, Sx + Src.Width, Sy, Sy + Src.Height, Src.Width, W, H, Dp, Sp) Then Exit Sub

    Dp = Dp + DataPTR(meLeft, meTop)
    Sp = Sp + Src.PTR

    SMoveByte(Sp, Dp, W, H, Src.Width, meWidth, chSrc, chDest)
  End Sub

  Public Sub MoveBit(ByRef Src As Sprite, ByVal Sx As Integer, ByVal Sy As Integer, ByVal mbSrc As Integer, ByVal mbDest As Integer)
    Dim Sp, W, H, Dp As Integer

    If Not TransformCoord2(Sx, Sx + Src.Width, Sy, Sy + Src.Height, Src.Width, W, H, Dp, Sp) Then Exit Sub

    Dp = Dp + DataPTR(meLeft, meTop)
    Sp = Sp + Src.PTR

    SMoveBit(Sp, Dp, W, H, Src.Width, meWidth, mbSrc, mbDest)
  End Sub

  Public Sub MaskMoveByte(ByRef Src As Sprite, ByRef SrcMask As Sprite, ByVal Sx As Integer, ByVal Sy As Integer, ByVal MaskX As Integer, ByVal MaskY As Integer, ByVal chSrc As SR2D.ColChannel, ByVal chDest As SR2D.ColChannel, ByVal Mask As Integer, Optional ByVal NotMask As Boolean = False)
    Dim Dp, H, W, Sp, Mp As Integer

    If Not TransformCoord3(Sx, Sx + Src.Width, Sy, Sy + Src.Height, MaskX, MaskX + SrcMask.Width, MaskY, MaskY + SrcMask.Height, Src.Width, SrcMask.Width, W, H, Dp, Sp, Mp) Then Exit Sub

    Dp = Dp + PTR
    Sp = Sp + Src.PTR
    Mp = Mp + SrcMask.PTR

    SMaskMoveByte(Sp, Dp, Mp, W, H, Mask, Src.Width, meWidth, SrcMask.Width, -CShort(NotMask), chSrc, chDest)
  End Sub

  Public Sub MaskMoveBit(ByRef Src As Sprite, ByRef SrcMask As Sprite, ByVal Sx As Integer, ByVal Sy As Integer, ByVal MaskX As Integer, ByVal MaskY As Integer, ByVal mbSrc As Integer, ByVal mbDest As Integer, ByVal Mask As Integer, Optional ByVal NotMask As Boolean = False)
    Dim Dp, H, W, Sp, Mp As Integer

    If Not TransformCoord3(Sx, Sx + Src.Width, Sy, Sy + Src.Height, MaskX, MaskX + SrcMask.Width, MaskY, MaskY + SrcMask.Height, Src.Width, SrcMask.Width, W, H, Dp, Sp, Mp) Then Exit Sub

    Dp = Dp + PTR
    Sp = Sp + Src.PTR
    Mp = Mp + SrcMask.PTR

    SMaskMoveBit(Sp, Dp, Mp, W, H, Mask, Src.Width, meWidth, SrcMask.Width, -CShort(NotMask), mbSrc, mbDest)
  End Sub

  Public Sub TileDraw(ByRef Src As Sprite, ByVal Dx As Integer, ByVal Dy As Integer, ByVal W As Integer, ByVal H As Integer, Optional ByVal Sx As Integer = 0, Optional ByVal Sy As Integer = 0, Optional ByVal Op As SR2D.Op = SR2D.Op.DefaultOp)
    Dim meT, meL, meR, meB As Integer
    Dim sw, x, y, sh As Integer

    meL = meLeft
    meR = meRight
    meT = meTop
    meB = meBottom

    Do
      If Dx > meLeft Then If Dx < meRight Then meLeft = Dx Else Exit Do
      If Dy > meTop Then If Dy < meBottom Then meTop = Dy Else Exit Do
      If Dx + W <= meLeft Then Exit Do Else If Dx + W < meRight Then meRight = Dx + W
      If Dy + H <= meTop Then Exit Do Else If Dy + H < meBottom Then meBottom = Dy + H
      sh = Src.Height
      sw = Src.Width
      Sx = Sx - Int((Sx + sw) / sw) * sw
      Sy = Sy - Int((Sy + sh) / sh) * sh
      For y = Dy + Sy To meBottom - 1 Step sh
        For x = Dx + Sx To meRight - 1 Step sw
          Draw(Src, x, y, Op)
        Next x
      Next y
    Loop While False

    meLeft = meL
    meRight = meR
    meTop = meT
    meBottom = meB
  End Sub

  Private Sub Init(Optional ByVal W As Integer = 0, Optional ByVal H As Integer = 0, Optional ByVal Op As SR2D.Op = SR2D.Op.DefaultOp)
    If Op <> SR2D.Op.DefaultOp Then meOp = Op
    If W <= 0 And H <= 0 Then Exit Sub
    If W = meWidth And H = meHeight Then Exit Sub
    If W > 0 Then meWidth = W
    If H > 0 Then meHeight = H
    SetLockRect(0, meWidth, 0, meHeight)
    If GCH.IsAllocated Then GCH.Free()
    ReDim cBuf(meWidth * meHeight - 1)
    GCH = GCHandle.Alloc(cBuf, GCHandleType.Pinned)
    PTR = GCH.AddrOfPinnedObject.ToInt32
    With bi32BitInfo.bmiHeader
      .biBitCount = 32
      .biPlanes = 1
      .biSize = Len(bi32BitInfo.bmiHeader)
      .biWidth = meWidth
      .biHeight = -meHeight
      .biSizeImage = (meWidth * meHeight) << 2
    End With
  End Sub

  Private Sub LoadFromBitmap(ByVal Bmp As Bitmap, Optional ByVal Trans As SR2D.Transform = SR2D.Transform.None, Optional ByVal W As Integer = 0, Optional ByVal H As Integer = 0, Optional ByVal ColorKey As Integer = -1)
    Dim BmpDest As Bitmap

    If W < 1 Then W = Bmp.Width
    If H < 1 Then H = Bmp.Height
    If Bmp.PixelFormat = Imaging.PixelFormat.Format32bppArgb Then
      BmpDest = Bmp
    Else
      BmpDest = New Bitmap(Bmp.Width, Bmp.Height, Imaging.PixelFormat.Format32bppArgb)
      Using G As Graphics = Graphics.FromImage(BmpDest)
        G.DrawImage(Bmp, 0, 0, Bmp.Width, Bmp.Height)
      End Using
    End If

    If Trans = SR2D.Transform.None And W = Bmp.Width And H = Bmp.Height Then
      Init(W, H)
      Dim BMD As Imaging.BitmapData = BmpDest.LockBits(Rectangle.Round(BmpDest.GetBounds(GraphicsUnit.Pixel)), Imaging.ImageLockMode.ReadOnly, Imaging.PixelFormat.Format32bppArgb)
      Marshal.Copy(BMD.Scan0, cBuf, 0, W * H)
      BmpDest.UnlockBits(BMD)
      BmpDest.Dispose()
    Else
      Dim Spr As New Sprite(BmpDest)
      LoadFromSprite(Spr, Trans, W, H, ColorKey)
      Spr = Nothing
    End If
    If ColorKey >= 0 Then AddColorKey(ColorKey) : Op = SR2D.Op.AlphaTest
  End Sub

  Private Sub LoadFromSprite(ByVal Src As Sprite, Optional ByVal Trans As SR2D.Transform = SR2D.Transform.None, Optional ByVal W As Integer = 0, Optional ByVal H As Integer = 0, Optional ByVal ColorKey As Integer = -1)
    Dim fResize As Boolean
    Dim Ar() As Integer
    Dim D As Integer

    If W <= 0 Then W = Src.Width Else If W <> Src.Width Then fResize = True
    If H <= 0 Then H = Src.Height Else If H <> Src.Height Then fResize = True
    If fResize Then
      Init(W, H, Src.Op)
      If Trans = SR2D.Transform.None Then
        SResize(Src.PTR, PTR, Src.Width, Src.Height, meWidth, meHeight)
      ElseIf W * H > Src.Width * Src.Height Then
        ReDim Ar(Src.Width * Src.Height - 1)
        W = Src.Width : H = Src.Height
        Transform(Src.PTR, Marshal.UnsafeAddrOfPinnedArrayElement(Ar, 0), W, H, Trans)
        If Trans > SR2D.Transform.FlipXY Then D = W : W = H : H = D
        SResize(Marshal.UnsafeAddrOfPinnedArrayElement(Ar, 0), PTR, W, H, meWidth, meHeight)
      Else
        ReDim Ar(W * H - 1)
        If Trans > SR2D.Transform.FlipXY Then D = W : W = H : H = D
        SResize(Src.PTR, Marshal.UnsafeAddrOfPinnedArrayElement(Ar, 0), Src.Width, Src.Height, W, H)
        Transform(Marshal.UnsafeAddrOfPinnedArrayElement(Ar, 0), PTR, W, H, Trans)
      End If
    Else
      If Trans > SR2D.Transform.FlipXY Then D = W : W = H : H = D
      Init(W, H, Src.Op)
      Transform(Src.PTR, PTR, W, H, Trans)
    End If
    If ColorKey >= 0 Then AddColorKey(ColorKey) : Op = SR2D.Op.AlphaTest
  End Sub

  Private Sub LoadFromFile(ByVal FileName As String, Optional ByVal Trans As SR2D.Transform = SR2D.Transform.None, Optional ByVal W As Integer = 0, Optional ByVal H As Integer = 0, Optional ByVal ColorKey As Integer = -1)
    Dim Bmp As Bitmap = Bitmap.FromFile(FileName)
    LoadFromBitmap(Bmp, Trans, W, H, ColorKey)
    Bmp.Dispose()
  End Sub

  Public Sub SaveToFile(ByVal FileName As String, ByVal Format As System.Drawing.Imaging.ImageFormat, Optional ByVal WithAlpha As Boolean = False)
    Dim Bmp As Bitmap

    If WithAlpha Then
      Bmp = New Bitmap(meWidth, meHeight, meWidth << 2, Imaging.PixelFormat.Format32bppArgb, PTR)
    Else
      Bmp = New Bitmap(meWidth, meHeight, meWidth << 2, Imaging.PixelFormat.Format32bppRgb, PTR)
    End If
    Bmp.Save(FileName, Format)
    Bmp.Dispose()
  End Sub

  Private Sub Transform(ByVal pSrc As Integer, ByVal pDest As Integer, ByVal W As Integer, ByVal H As Integer, ByVal Trans As SR2D.Transform)
    Select Case Trans
      Case SR2D.Transform.FlipX
        SFlipX(pSrc, pDest, W, H)
      Case SR2D.Transform.FlipY
        SFlipY(pSrc, pDest, W, H)
      Case SR2D.Transform.FlipXY
        SFlipXY(pSrc, pDest, W, H)
      Case SR2D.Transform.RotCCW
        SRotCCW(pSrc, pDest, W, H)
      Case SR2D.Transform.RotCW
        SRotCW(pSrc, pDest, W, H)
      Case SR2D.Transform.FlipXRotCCW
        SFlipXRotCCW(pSrc, pDest, W, H)
      Case SR2D.Transform.FlipYRotCCW
        SFlipYRotCCW(pSrc, pDest, W, H)
      Case Else
        CopyMemory(pSrc, pDest, (W * H) << 2)
    End Select
  End Sub

  Public Sub SetLockRect(Optional ByVal PLeft As Integer = -1, Optional ByVal PRight As Integer = -1, Optional ByVal Top As Integer = -1, Optional ByVal Bottom As Integer = -1)
    If PLeft >= 0 And PLeft < meWidth Then meLeft = PLeft Else meLeft = 0
    If PRight > PLeft And PRight <= meWidth Then meRight = PRight Else meRight = meWidth
    If Top >= 0 And Top < meHeight Then meTop = Top Else meTop = 0
    If Bottom > Top And Bottom <= meHeight Then meBottom = Bottom Else meBottom = meHeight
  End Sub

  Public ReadOnly Property Width() As Integer
    Get
      Width = meWidth
    End Get
  End Property

  Public ReadOnly Property Height() As Integer
    Get
      Height = meHeight
    End Get
  End Property

  Public Property Op() As SR2D.Op
    Get
      Op = meOp
    End Get
    Set(ByVal Value As SR2D.Op)
      If Value <> SR2D.Op.DefaultOp Then meOp = Value
    End Set
  End Property

  Public Property BlendFactor() As Integer
    Get
      BlendFactor = meBFactor
    End Get
    Set(ByVal Value As Integer)
      meBFactor = Value
    End Set
  End Property

  Public ReadOnly Property DataPTR(ByVal x As Integer, ByVal y As Integer) As Integer
    Get
      DataPTR = PTR + ((x + y * meWidth) << 2)
    End Get
  End Property

  Public Sub PaintToDevice(ByVal hDC As HandleRef)
    SetDIBitsToDevice(hDC, 0, 0, meWidth, meHeight, 0, 0, 0, meHeight, cBuf(0), bi32BitInfo, 0)
  End Sub

  Public Sub AddColorKey(ByVal ColorKey As Integer)
    SAddColorKey(PTR, meWidth, meHeight, ColorKey)
  End Sub

  Public Sub SetPixel(ByVal x As Integer, ByVal y As Integer, ByVal c As Integer)
    If x < meLeft Then Exit Sub
    If x >= meRight Then Exit Sub
    If y < meTop Then Exit Sub
    If y >= meBottom Then Exit Sub
    cBuf(x + y * meWidth) = c
  End Sub

  Public Function GetPixel(ByVal x As Integer, ByVal y As Integer) As Integer
    If x < 0 Then Exit Function
    If x >= meWidth Then Exit Function
    If y < 0 Then Exit Function
    If y >= meHeight Then Exit Function
    GetPixel = cBuf(x + y * meWidth)
  End Function

  Private Function ColFromLite(ByVal x As Integer, ByVal y As Integer, ByVal z As Integer, ByVal Brite As Single) As Integer
    Dim R, G, B As Integer
    Dim k As Single

    If Brite < 0 Then Brite = 0
    If Brite > 1 Then Brite = 1
    k = 127.4999 * Brite / System.Math.Sqrt(x * x + y * y + z * z)

    R = x * k : R = R + 128
    G = y * k : G = G + 128
    B = z * k : B = B + 128

    ColFromLite = (R << 16) + (G << 8) + B
  End Function

  Public Sub New(ByVal Bmp As Bitmap, Optional ByVal Trans As SR2D.Transform = SR2D.Transform.None, Optional ByVal W As Integer = 0, Optional ByVal H As Integer = 0, Optional ByVal ColorKey As Integer = -1)
    MyBase.New()
    LoadFromBitmap(Bmp, Trans, W, H, ColorKey)
  End Sub

  Public Sub New(ByVal Src As Sprite, Optional ByVal Trans As SR2D.Transform = SR2D.Transform.None, Optional ByVal W As Integer = 0, Optional ByVal H As Integer = 0, Optional ByVal ColorKey As Integer = -1)
    MyBase.New()
    LoadFromSprite(Src, Trans, W, H, ColorKey)
  End Sub

  Public Sub New(ByVal FileName As String, Optional ByVal Trans As SR2D.Transform = SR2D.Transform.None, Optional ByVal W As Integer = 0, Optional ByVal H As Integer = 0, Optional ByVal ColorKey As Integer = -1)
    MyBase.New()
    LoadFromFile(FileName, Trans, W, H, ColorKey)
  End Sub

  Public Sub New(ByVal W As Integer, ByVal H As Integer, Optional ByVal Op As SR2D.Op = SR2D.Op.Paint)
    MyBase.New()
        If Op = SR2D.Op.DefaultOp Then Op = SR2D.Op.Paint
    Init(W, H, Op)
  End Sub

  Protected Overrides Sub Finalize()
    If GCH.IsAllocated Then GCH.Free()
    MyBase.Finalize()
  End Sub
End Class
