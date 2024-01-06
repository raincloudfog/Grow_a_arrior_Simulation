using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǻ� UI���� �ҷ����� ������ �ҰŰ��� �׷��� GamePlayManger�� �ִ� �Լ��� �ٲ��� �ʿ䰡 �־��
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
            
            //���� ã�Ҵµ��� ���ٸ� ������ֱ�
            //���� ������Ʈ �������� �ű�ٰ� �� ������Ʈ ����ؼ� �ҷ�����
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
