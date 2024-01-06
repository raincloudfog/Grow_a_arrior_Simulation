using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//사실상 UI들을 불러오는 역할을 할거같음 그러면 GamePlayManger에 있는 함수를 바꿔줄 필요가 있어보임
public class UIManager : MonoBehaviour
{
    static UIManager m_instance;

    public static UIManager Instance
    {
        get
        {
            if(m_instance == null)
            {
                var _obj = FindObjectOfType<UIManager>();
                m_instance = _obj;
            }
            
            //만약 찾았는데도 없다면 만들어주기
            //게임 오브젝트 꺼내오고 거기다가 겟 컴포넌트 사용해서 불러오기
            if(m_instance == null)
            {
                GameObject _obj = Instantiate( Resources.Load<GameObject>("UI/Canvas"));
                DontDestroyOnLoad(_obj);
                m_instance = _obj.GetComponent<UIManager>();
            }

            return m_instance;
        }
    }

    public UImaininterface m_UImaininterface;


    public void Init()
    {
        m_UImaininterface.Init();
    }
    
}
