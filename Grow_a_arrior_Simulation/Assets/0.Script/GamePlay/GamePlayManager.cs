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


//��ǻ� UI�Ŵ����� �����ؾ� �ɵ���. ���߿� �и��� �� ������ �и� �� ���� ����.
//�� �÷��� �Ŵ����� �̷��� UI�� �ֳ� !! ��� ������ �Ǳ��ϴµ� ��ġ�� ���� �����̶� UI�� ������ �߿��Ҷ� �ǴܵǾ..??
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


    #region UIManager�� �������� ������ ���� �ڵ� �׷��� ���߿� �� �� ������ ���ܵδ� �ڵ�
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

    public T CreateUI<T>() where T : UIdialog // �������̺�� ������ addcomponent�� �۵���������. �� ������Ʈ�� ������������
    {
        if (m_UIdialogs.ContainsKey(typeof(T)) == false)
        {
            System.Type type = typeof(T);
            GameObject _obj = GameObject.Instantiate( LoadResouce(type));//�ٷ� ������ָ鼭 ���ҽ� �־��ֱ� //new GameObject(typeof(T).Name);
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


    public GameObject LoadResouce(System.Type type) // UIdialog����鼭 ���ҽ��ҷ����� (���߿��� ���� �ҷ������ �ٲܰ�)
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
