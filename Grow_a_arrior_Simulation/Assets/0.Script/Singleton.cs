using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//모노비헤이비어가 있는 스크립트만 상속 가능
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T m_instance;
    
    public static T Instance
    {
        get
        {
            if(m_instance == null)
            {
                T[] _finds = FindObjectsOfType<T>();
                if(_finds.Length > 0)
                {
                    m_instance = _finds[0];
                    DontDestroyOnLoad(m_instance);
                }

                if(_finds.Length > 1)
                {
                    for (int i = 1; i < _finds.Length; i++)
                    {
                        Destroy(_finds[i].gameObject);
                    }
                    Debug.LogError("There is more than one " + typeof(T).Name + "in ther Scene");
                }

                if(null == m_instance)
                {
                    GameObject _createGameObject = new GameObject(typeof(T).Name);
                    DontDestroyOnLoad(_createGameObject);
                    m_instance = _createGameObject.AddComponent<T>();
                }
            }

            return m_instance;
        }
    }   
}
