#pragma once

// CTransparentStatic

class CTransparentStatic : public CStatic
{
	DECLARE_DYNAMIC(CTransparentStatic)

public:
	CString m_Text;
	virtual void OnPaint();
	HBRUSH CtlColor(CDC* pDC, UINT nCtlColor);
	BOOL OnEraseBkgnd(CDC* pDC);
	CString m_text;
	void SetWindowTextA(LPCTSTR str);
	CTransparentStatic();
	virtual ~CTransparentStatic();

protected:
	DECLARE_MESSAGE_MAP()
};


