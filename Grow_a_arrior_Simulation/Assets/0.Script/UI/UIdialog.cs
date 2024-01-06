using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AnchorPresets
{
    TopLeft,
    TopCenter,
    TopRight,

    MiddleLeft,
    MiddleCenter,
    MiddleRight,

    BottomLeft,
    BottonCenter,
    BottomRight,
    BottomStretch,

    VertStretchLeft,
    VertStretchRight,
    VertStretchCenter,

    HorStretchTop,
    HorStretchMiddle,
    HorStretchBottom,

    StretchAll
}

//UI에 담길 함수들을 컴포넌트들을 저장할 곳
public class UIdialog : MonoBehaviour
{
    protected RectTransform m_rectTransform;

    public virtual void Init()
    {
        m_rectTransform = transform as RectTransform;
        
    }

    public virtual void Logout()
    {

    }

    //UI생성시 위치 초기화
    public virtual void SetPullpresets()
    {
        m_rectTransform.anchorMin = new Vector2(0, 0);
        m_rectTransform.anchorMax = new Vector2(1, 1);
        m_rectTransform.anchoredPosition = Vector2.zero;
    }
}
