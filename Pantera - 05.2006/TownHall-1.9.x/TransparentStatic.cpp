// TransparentStatic.cpp : implementation file
//
#ifdef WIN32 // linux support

#include "stdafx.h"
#include "TransparentStatic.h"


// CTransparentStatic
IMPLEMENT_DYNAMIC(CTransparentStatic, CStatic)
CTransparentStatic::CTransparentStatic()
{
}

CTransparentStatic::~CTransparentStatic()
{
}


BEGIN_MESSAGE_MAP(CTransparentStatic, CStatic)
	ON_WM_CTLCOLOR_REFLECT()
	ON_WM_ERASEBKGND()
	ON_WM_PAINT()
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
void CTransparentStatic::OnPaint()
{
	LOGFONT lf;
	memset(&lf,0,sizeof(LOGFONT));
	lf.lfHeight = 80;
	lf.lfWeight = FW_BOLD;
	strcpy(lf.lfFaceName,"Arial");
	CFont myf;
	CPaintDC dc(this);
	VERIFY(myf.CreatePointFontIndirect(&lf,&dc));
	CRect client_rect;
	GetClientRect(client_rect);
	CFont *pFont = dc.SelectObject(&myf);
	dc.SetBkMode(TRANSPARENT);
	m_text.Empty();
	GetWindowText(m_text);
	dc.SetTextColor(RGB(255,255,255));
	dc.DrawText(m_text,client_rect,DT_LEFT);
	dc.SelectObject(pFont);
	myf.DeleteObject();
}

void CTransparentStatic::SetWindowTextA(LPCTSTR str)
{
	CStatic::SetWindowTextA(str);
	CRect Rect;
	GetClientRect(&Rect);
	ClientToScreen(&Rect);
	CWnd *Parent = GetParent();
	Parent->ScreenToClient(&Rect);
	Parent->InvalidateRect(&Rect);
	Parent->UpdateWindow();
}
HBRUSH CTransparentStatic::CtlColor(CDC* pDC, UINT nCtlColor)
{
	pDC->SetTextColor(RGB(255,255,255));
	pDC->SetBkMode(TRANSPARENT);
	HBRUSH brush = (HBRUSH)GetStockObject(HOLLOW_BRUSH);
	return brush;
}

BOOL CTransparentStatic::OnEraseBkgnd(CDC* pDC)
{
	return TRUE;
}

#endif // WIN32
