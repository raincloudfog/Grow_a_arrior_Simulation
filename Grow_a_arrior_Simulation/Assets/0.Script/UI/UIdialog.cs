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

//UI�� ��� �Լ����� ������Ʈ���� ������ ��
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

    //UI������ ��ġ �ʱ�ȭ
    public virtual void SetPullpresets()
    {
        m_rectTransform.anchorMin = new Vector2(0, 0);
        m_rectTransform.anchorMax = new Vector2(1, 1);
        m_rectTransform.anchoredPosition = Vector2.zero;
    }
}
