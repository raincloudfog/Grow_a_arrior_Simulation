using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IObserver
{
    void Notify(Subject subject);
}



public class Subject
{
    protected bool m_isNotify = false;
    //옵저버가 담길 공간
    protected List<IObserver> m_observerList = new List<IObserver>();


    //옵저버 초기화
    public virtual void Clear()
    {
        m_observerList.Clear();
    }

    //옵저버 추가하기
    public virtual void Attach(IObserver observer)
    {
        if (observer == null)
            return;
        if (m_observerList.Contains(observer))
            return;
        m_observerList.Add(observer);
    }

    //옵저버 빼기
    public virtual void Detach(IObserver observer)
    {
        if (observer == null)
            return;
        m_observerList.Remove(observer);
    }

    //옵저버 실행 시킬껀지 말껀지
    public void SetNotify(bool isNotify)
    {
        m_isNotify=isNotify;
    }

    //바로 옵저버 실행가능하게 하기
    public void SetNotify()
    {
        SetNotify(true);
    }

    //옵저버에게 전달하기
    public virtual void Notify()
    {
        for (int i = 0; i < m_observerList.Count; i++)
        {
            IObserver _observser = m_observerList[i];
            if (_observser == null)
                continue;
            _observser.Notify(this);
        }
    }

    //만약 옵저버 실행가능하게 되었다면 옵저버 실행하고 실행다했으니 멈춰주기
    public virtual void UpdateLogic()
    {
        if (m_isNotify == false)
            return;
        Notify();
        m_isNotify = false;
    }
}
