using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class UImaininterface : UIdialog
{
    //버튼
    public Button[] buttons;
    //버튼과 연결될 게임오브젝트
    //쓰으으으읍...흐으으으음...
    //게임 오브젝트들에도 또 스크립트가 들어가있을텐데
    //생성하는 방식을 생각해 봐야될거같다.
    public GameObject HeroUIobj;
    public GameObject EquipUIobj;
    public GameObject SkillUIobj;
    public GameObject DungeonUIobj;
    public GameObject SummonUIobj;

    //이곳에서는 딕셔너리에 버튼들이 담기게 하려고함.
    public override void Init()
    {
        base.Init();

        Debug.Log("UImaininterface:Init()[play Init()]");
        //만약 버튼에 함수가 있다면 다음으로 넘어가고 없다면 버튼에 맞는 함수 넣어주기
        //var랑 object사용하는 이유를 조금씩이라도 알아가는 중 같아 좋음.
        for (int i = 0; i < buttons.Length; i++)
        {
            var _Event = buttons[i].onClick.GetPersistentEventCount();
            Debug.Log("UImaininterface:Init()[_Event Count : "+ _Event);
            if (_Event > 0)
                continue;
            int buttonIndex = i; // i 값을 복사하여 클로저 문제 해결
            buttons[i].onClick.AddListener(() => OnbuttonClick(buttonIndex));
            //buttons[i].onClick.AddListener(() => OnbuttonClick(i)); //람다에서 i를 넣는거는 클로저 문제라고 하는데 좀더 찾아봐야겠다. 아마 매개변수 처럼 사용되는게아닐까 싶다.
            var eventCount = buttons[i].onClick.GetPersistentEventCount();
            if (eventCount > 0)
            {
                var methodName = buttons[i].onClick.GetPersistentMethodName(0);
                // 메소드 이름이 있다면 처리
                if (string.IsNullOrEmpty(methodName))
                {
                    // 메소드가 없는 경우
                    Debug.Log("No method assigned to the button click event.");
                }
                else
                {
                    // 메소드가 있는 경우
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
