using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public enum eOPENUI
{
    NONE,
    HERO,
    EQUIP,
    SKILL,
    DUNGEON,
    SUMMON,

}


//사실상 UI매니저라 생각해야 될듯함. 나중에 분리할 수 있으면 분리 할 수도 있음.
//왜 플레이 매니저에 이렇게 UI가 있냐 !! 라고 생각이 되긴하는데 방치형 게임 모작이라 UI가 게임의 중요요소라 판단되어서..??
public class GamePlayManager : Singleton<GamePlayManager>
{
    Dictionary<System.Type, UIdialog> m_UIdialogs = new Dictionary<System.Type, UIdialog>();

    Dictionary<System.Type, string> paths = new Dictionary<System.Type, string>();

    public Canvas m_canvas;
    public void Init()
    {
        /*FindCanvas();
        Addpaths<UIWealth>("UI/UIWealth");
        CreateUI<UIWealth>();*/
    }


    #region UIManager의 등장으로 사용되지 않을 코드 그래도 나중에 볼 수 있으니 남겨두는 코드
    /*void FindCanvas()
    {
        if(m_canvas == null)
        {
            m_canvas = GameObject.FindObjectOfType<Canvas>();
        }
        else
        {
            Debug.Log("GamePlayerManager:FindCanvas()[have canvas]");
            return;
        }
    }

    public T Addpaths<T>(string path) where T : UIdialog
    {
        System.Type type = typeof(T);
        if(paths.ContainsKey(type))
        {
            Debug.LogError("GamePlayManager:Addpaths()[have : " +type.ToString());
            return default(T);
        }

        paths.Add(type, path);

        return default(T);
    }

    public void CreateUI()
    {

    }

    public T CreateUI<T>() where T : UIdialog // 모노비헤이비어 없으면 addcomponent가 작동하지않음. 즉 컴포넌트로 인정하지않음
    {
        if (m_UIdialogs.ContainsKey(typeof(T)) == false)
        {
            System.Type type = typeof(T);
            GameObject _obj = GameObject.Instantiate( LoadResouce(type));//바로 만들어주면서 리소스 넣어주기 //new GameObject(typeof(T).Name);
            _obj.name = type.Name;
            if(m_canvas != null)
            {
                _obj.transform.SetParent(m_canvas.transform);
            }
            else
            {
                Debug.LogError("GamePlayManager:CreateUI()[no have : canvas");
                FindCanvas();
                _obj.transform.SetParent(m_canvas.transform);
            }
            T _component = _obj.GetComponent<T>();
            RectTransform rect = _obj.transform as RectTransform;
            *//*if (rect != null)
            {
                ne
                rect.anchoredPosition = Vector2.zero;
                
            }
            else
            {
                Debug.LogError("GamePlayManager:CreateUI()[no have rect]");
            }*//*
            _component.Init();
            m_UIdialogs.Add(typeof(T), _component);
            return _component;
        }
        return null;
    }


    public GameObject LoadResouce(System.Type type) // UIdialog만들면서 리소스불러오기 (나중에는 에셋 불러오기로 바꿀것)
    {
        if(type == null )
        {
            return null;
        }

        GameObject _res = Resources.Load<GameObject>(paths[type]);
        if(_res == null)
        {
            Debug.LogError("GamePlayManager:LoadResouce()[NO have _res]" + _res);
        }

        return _res;
    }*/
    #endregion
}
