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
    //�������� ��� ����
    protected List<IObserver> m_observerList = new List<IObserver>();


    //������ �ʱ�ȭ
    public virtual void Clear()
    {
        m_observerList.Clear();
    }

    //������ �߰��ϱ�
    public virtual void Attach(IObserver observer)
    {
        if (observer == null)
            return;
        if (m_observerList.Contains(observer))
            return;
        m_observerList.Add(observer);
    }

    //������ ����
    public virtual void Detach(IObserver observer)
    {
        if (observer == null)
            return;
        m_observerList.Remove(observer);
    }

    //������ ���� ��ų���� ������
    public void SetNotify(bool isNotify)
    {
        m_isNotify=isNotify;
    }

    //�ٷ� ������ ���డ���ϰ� �ϱ�
    public void SetNotify()
    {
        SetNotify(true);
    }

    //���������� �����ϱ�
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

    //���� ������ ���డ���ϰ� �Ǿ��ٸ� ������ �����ϰ� ����������� �����ֱ�
    public virtual void UpdateLogic()
    {
        if (m_isNotify == false)
            return;
        Notify();
        m_isNotify = false;
    }
}
