// RollBtn.cpp : implementation file
//

#include "stdafx.h"
#include "TownHall.h"
#include "RollBtn.h"
#ifdef WIN32

// RollBtn

IMPLEMENT_DYNAMIC(RollBtn, CButton)

RollBtn::RollBtn()
{
	Over= Tracking = FALSE;
}
void RollBtn::SetBitmaps(UINT up1,UINT over1,UINT down1,UINT disabled1)
{
	up = up1;
	over = over1;
	down = down1;
	disabled = disabled1;
	bitmap = up;
	status = 0;
	Invalidate();
	RedrawWindow();
}

RollBtn::~RollBtn()
{
}


BEGIN_MESSAGE_MAP(RollBtn, CButton)
	ON_WM_ERASEBKGND()
	ON_WM_MOUSEMOVE()
	ON_WM_LBUTTONDOWN()
	ON_WM_LBUTTONUP()
END_MESSAGE_MAP()


BOOL RollBtn::OnEraseBkgnd(CDC *pDC)
{
	return TRUE;
}
// RollBtn message handlers
void RollBtn::DrawItem(LPDRAWITEMSTRUCT lpDIS)
{
	// use the main bitmap for up, the selected bitmap for down
	if(IsWindowEnabled())
	{
		switch(status)
		{
		case 0: bitmap = up;break;
		case 1: bitmap = over;break;
		case 2: bitmap =down;break;
		}
	}
	else bitmap = disabled;
	// draw the whole button
	CBitmap pBitmap;
	pBitmap.LoadBitmap(bitmap);
	CDC* pDC = CDC::FromHandle(lpDIS->hDC);
	CDC memDC;
	memDC.CreateCompatibleDC(pDC);
	CBitmap* pOld = memDC.SelectObject(&pBitmap);
	if (pOld == NULL)
		return;     // destructors will clean up

	CRect rect;
	rect.CopyRect(&lpDIS->rcItem);
	pDC->BitBlt(rect.left, rect.top, rect.Width(), rect.Height(),
		&memDC, 0, 0, SRCCOPY);
	memDC.SelectObject(pOld);
}
void RollBtn::OnMouseOver()
{
	Over = TRUE;
	status = 1;
	Invalidate();
	RedrawWindow();
}

void RollBtn::OnMouseOut()
{
	Over = FALSE;
	status = 0;
	Invalidate();
	RedrawWindow();
}
void RollBtn::OnMouseMove(UINT nFlags, CPoint point)
{
	if(status!=2)
	{
		if(IsWindowEnabled())
		{
			SetCapture();
			CRect wndRect;
			GetWindowRect(&wndRect);
			ScreenToClient(&wndRect);

			if (wndRect.PtInRect(point))
			{
				if (Over != TRUE)
				{
					OnMouseOver();
				}
			}
			else
			{
				ReleaseCapture();
				OnMouseOut();
			}
		}
	}
	CButton::OnMouseMove(nFlags, point);
}

void RollBtn::OnLButtonDown(UINT nFlags, CPoint point)
{
	status = 2;
	CButton::OnLButtonDown(nFlags, point);
}
void RollBtn::OnLButtonUp(UINT nFlags,CPoint point)
{
	if(Over) status = 1;
	else status =0;
	CButton::OnLButtonUp(nFlags, point);
	OnMouseMove(nFlags,point);
}
#endif
