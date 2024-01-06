using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum eSTATUP { }



public class StatUpUI : UIdialog
{
    public Button[] StatUPUIButtons;

    public TMP_Text DamageUPUItext;
    public TMP_Text HpUPUItext;
    public TMP_Text CriticalUpUItext;
    public TMP_Text CriDamageUPUItext;

    int Damagetxt = 0;
    int HPtxt = 0;
    int Criticaltxt = 0;
    int CriDamagetxt = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < StatUPUIButtons.Length; i++)
        {
            var _Event = StatUPUIButtons[i].onClick.GetPersistentEventCount();
            if (_Event > 0)
                continue;
            int buttonIndex = i;
            StatUPUIButtons[i].onClick.AddListener(() => OnbuttonClick(buttonIndex));
            
        }
    }

    public void OnbuttonClick(int buttonIndex)
    {
         switch (buttonIndex)
        {
            case 0:
                DamageUPUIButton(); break;
            case 1:
                HpUPUIButton(); break;
            case 2:
                CriticalUpUIButton(); break;
            case 3: CriDamageUPUIButton(); break;            
            default:
                break;            
        }
    }

    
    // 지금 당장은 돈이 없어도 구매가 가능 나중에는 돈이 없으면 구매못하는 방식으로 만들것.
    public void DamageUPUIButton()
    {
        GameDataManager.Instance.GetWealthData().Wealth.MinusWealth(1, eWEALTH_DATA.GOLD);
        GameDataManager.Instance.GetPlayerData().GetPlayer.LevelUp(ePLAYER_STAT.DAMAGE);
        ++Damagetxt;
        DamageUPUItext.text = Damagetxt.ToString();
    }
    public void HpUPUIButton()
    {
        GameDataManager.Instance.GetWealthData().Wealth.MinusWealth(1, eWEALTH_DATA.GOLD);
        GameDataManager.Instance.GetPlayerData().GetPlayer.LevelUp(ePLAYER_STAT.HP);

        ++HPtxt;
        HpUPUItext.text = Damagetxt.ToString();
    }
    public void CriticalUpUIButton()
    {
        GameDataManager.Instance.GetWealthData().Wealth.MinusWealth(1, eWEALTH_DATA.GOLD);
        GameDataManager.Instance.GetPlayerData().GetPlayer.LevelUp(ePLAYER_STAT.CRITICAL);

        ++Criticaltxt;
        CriticalUpUItext.text = Damagetxt.ToString();
    }
    public void CriDamageUPUIButton()
    {
        GameDataManager.Instance.GetWealthData().Wealth.MinusWealth(1, eWEALTH_DATA.GOLD);
        GameDataManager.Instance.GetPlayerData().GetPlayer.LevelUp(ePLAYER_STAT.DAMAGE);

        ++CriDamagetxt;
        CriDamageUPUItext.text = Damagetxt.ToString();
    }
}
