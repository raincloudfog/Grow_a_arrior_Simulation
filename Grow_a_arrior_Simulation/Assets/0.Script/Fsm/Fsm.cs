using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fsm<T> 
{
    //상태가 담긴 딕셔너리
    protected Dictionary<T, FsmState<T>> m_stateList = new Dictionary<T, FsmState<T>>();
    //같은 타입의 상태
    protected FsmState<T> m_state;

    public FsmState<T> getState { get { return m_state; } }

    //해당 Fsm의 타입
    public T GetStateType
    {
         get
        {
            if(m_state == null)
                return default(T);
            return m_state.StateType;
        }
    }

    //Fsm초기값
    public virtual void Init()
    {

    }

    public virtual void Clear()
    {
        m_stateList.Clear();
        m_state = null;
    }

    //상태 추가
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

    //해당 스테이트 바꾸기
    public virtual void SetState(T _stateType)
    {
        if(m_stateList.ContainsKey(_stateType) == false)
        {
            Debug.LogError("Fsm:Setstate()[ no have state : " + _stateType);
            return;
        }

        //다음 상태
        FsmState<T> _nextState = m_stateList[_stateType];
        //근대 다음상태랑 현재상태랑 같다면
        if(_nextState == m_state)
        {
            Debug.LogError("Fsm:SetState()[ m_state == _nextStae]");
        }

        //현재 상태가 있다면 나가는 함수 실행
        if(m_state != null)
        {
            m_state.Exit();
        }

        m_state = _nextState;
        m_state.Enter();
    }

    //fsm 업데이트
    public virtual void UpdateLogic()
    {
        if (m_state == null)
            return;
        m_state.UpdateLogic();
    }
    
}


public class FsmState<T>
{
    //현재 타입
    protected T m_stateType;

    public T StateType { get { return m_stateType; } }

    //생성자로 만들때 타입 지정해주기
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