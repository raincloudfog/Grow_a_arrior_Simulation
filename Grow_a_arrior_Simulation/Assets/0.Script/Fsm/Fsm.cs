using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fsm<T> 
{
    //���°� ��� ��ųʸ�
    protected Dictionary<T, FsmState<T>> m_stateList = new Dictionary<T, FsmState<T>>();
    //���� Ÿ���� ����
    protected FsmState<T> m_state;

    public FsmState<T> getState { get { return m_state; } }

    //�ش� Fsm�� Ÿ��
    public T GetStateType
    {
         get
        {
            if(m_state == null)
                return default(T);
            return m_state.StateType;
        }
    }

    //Fsm�ʱⰪ
    public virtual void Init()
    {

    }

    public virtual void Clear()
    {
        m_stateList.Clear();
        m_state = null;
    }

    //���� �߰�
    public virtual void AddFsm(FsmState<T> _state)
    {
        if(_state == null)
        {
            Debug.LogError("Fsm:AddFsm()[_state == null]");
            return;
        }

        if (m_stateList.ContainsKey(_state.StateType)  == false)
        {
            m_stateList.Add(_state.StateType, _state);
            
        }
        else
        {
            Debug.LogError("Fsm:AddFsm()[ have state :" + _state.StateType);
        }
    }

    //�ش� ������Ʈ �ٲٱ�
    public virtual void SetState(T _stateType)
    {
        if(m_stateList.ContainsKey(_stateType) == false)
        {
            Debug.LogError("Fsm:Setstate()[ no have state : " + _stateType);
            return;
        }

        //���� ����
        FsmState<T> _nextState = m_stateList[_stateType];
        //�ٴ� �������¶� ������¶� ���ٸ�
        if(_nextState == m_state)
        {
            Debug.LogError("Fsm:SetState()[ m_state == _nextStae]");
        }

        //���� ���°� �ִٸ� ������ �Լ� ����
        if(m_state != null)
        {
            m_state.Exit();
        }

        m_state = _nextState;
        m_state.Enter();
    }

    //fsm ������Ʈ
    public virtual void UpdateLogic()
    {
        if (m_state == null)
            return;
        m_state.UpdateLogic();
    }
    
}


public class FsmState<T>
{
    //���� Ÿ��
    protected T m_stateType;

    public T StateType { get { return m_stateType; } }

    //�����ڷ� ���鶧 Ÿ�� �������ֱ�
    public FsmState(T stateType)
    { m_stateType = stateType; }

    public virtual void Enter()
    {

    }

    public virtual void UpdateLogic()
    {

    }

    public virtual void Exit() 
    {

    }
}