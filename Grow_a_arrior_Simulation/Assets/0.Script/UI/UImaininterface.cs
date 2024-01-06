using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class UImaininterface : UIdialog
{
    //��ư
    public Button[] buttons;
    //��ư�� ����� ���ӿ�����Ʈ
    //����������...����������...
    //���� ������Ʈ�鿡�� �� ��ũ��Ʈ�� �������ٵ�
    //�����ϴ� ����� ������ ���ߵɰŰ���.
    public GameObject HeroUIobj;
    public GameObject EquipUIobj;
    public GameObject SkillUIobj;
    public GameObject DungeonUIobj;
    public GameObject SummonUIobj;

    //�̰������� ��ųʸ��� ��ư���� ���� �Ϸ�����.
    public override void Init()
    {
        base.Init();

        Debug.Log("UImaininterface:Init()[play Init()]");
        //���� ��ư�� �Լ��� �ִٸ� �������� �Ѿ�� ���ٸ� ��ư�� �´� �Լ� �־��ֱ�
        //var�� object����ϴ� ������ ���ݾ��̶� �˾ư��� �� ���� ����.
        for (int i = 0; i < buttons.Length; i++)
        {
            var _Event = buttons[i].onClick.GetPersistentEventCount();
            Debug.Log("UImaininterface:Init()[_Event Count : "+ _Event);
            if (_Event > 0)
                continue;
            int buttonIndex = i; // i ���� �����Ͽ� Ŭ���� ���� �ذ�
            buttons[i].onClick.AddListener(() => OnbuttonClick(buttonIndex));
            //buttons[i].onClick.AddListener(() => OnbuttonClick(i)); //���ٿ��� i�� �ִ°Ŵ� Ŭ���� ������� �ϴµ� ���� ã�ƺ��߰ڴ�. �Ƹ� �Ű����� ó�� ���Ǵ°Ծƴұ� �ʹ�.
            var eventCount = buttons[i].onClick.GetPersistentEventCount();
            if (eventCount > 0)
            {
                var methodName = buttons[i].onClick.GetPersistentMethodName(0);
                // �޼ҵ� �̸��� �ִٸ� ó��
                if (string.IsNullOrEmpty(methodName))
                {
                    // �޼ҵ尡 ���� ���
                    Debug.Log("No method assigned to the button click event.");
                }
                else
                {
                    // �޼ҵ尡 �ִ� ���
                    Debug.Log($"Method assigned to the button click event: {methodName}");
                }
            }
        }
    }

    public override void Logout()
    {
        base.Logout();
    }

    void OnbuttonClick(int buttonIndex)
    {
        switch (buttonIndex)
        {
            case 0:
                ShowUI(HeroUIobj); break;
                case 1:
                ShowUI(EquipUIobj); break;
                case 2:
                ShowUI(SkillUIobj); break;
                case 3: ShowUI(DungeonUIobj); break;
                case 4:
                ShowUI(SummonUIobj); break;
                default:
                break;
        }
    }

    void ShowUI(GameObject targetUI)
    {
        Debug.Log("UImaininterface:ShowUI():[Play ShowUI]");
        targetUI.SetActive(true);
    }
}
