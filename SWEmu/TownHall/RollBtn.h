#ifdef WIN32
#pragma once

// RollBtn

class RollBtn : public CButton
{
	DECLARE_DYNAMIC(RollBtn)

public:
	RollBtn();
	virtual ~RollBtn();
	UINT up,over,bitmap,down,disabled;
	void DrawItem(LPDRAWITEMSTRUCT lpDIS);
	void OnMouseOver();
	void OnLButtonDown(UINT nFlags, CPoint point);
	void OnMouseOut();
	void OnMouseMove(UINT nFlags, CPoint point);
	void SetBitmaps(UINT,UINT,UINT,UINT);
	void OnLButtonUp(UINT nFlags,CPoint point);
	int status;
	BOOL OnEraseBkgnd(CDC* pDC);
	BOOL Tracking,Over;
protected:
	DECLARE_MESSAGE_MAP()
};

#endif
