using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eWEALTH_DATA
{
    GOLD,
    DIAMOND,
    UPGRADESTONE,

}


public class GDWealth
{
    public int Gold;
    public int Diamond;
    public int UpgradeStone;
    
    public void PlusGold(int gold)
    {
        Gold += gold;
    }

    public void PlusDiamond(int dia)
    {
        Diamond += dia;
    }
    
    public void PlusUpgradeStone(int stone)
    {
        UpgradeStone += stone;
    }

    //재화 사용
    public void MinusWealth(int Num , eWEALTH_DATA data)
    {
        switch (data)
        {
            case eWEALTH_DATA.GOLD:
                if(Gold < Num)
                {
                    Debug.LogError("GameData_Wealth:SetWealth()[Gold < Money]");
                    break;
                }
                Gold -= Num;
                break;
            case eWEALTH_DATA.DIAMOND:
                if (Diamond < Num)
                {
                    Debug.LogError("GameData_Wealth:SetWealth()[Diamond < Money]");
                    break;
                }
                Diamond -= Num;

                break;
            case eWEALTH_DATA.UPGRADESTONE:
                if (UpgradeStone < Num)
                {
                    Debug.LogError("GameData_Wealth:SetWealth()[UpgradeStone < Money]");
                    break;
                }
                UpgradeStone -= Num;
                break;
            default:
                break;
        }
    }

    //세이브 로드 생성시에 사용할 생성자
    public GDWealth()
    {

    }
}

public class GameData_Wealth : GameData, IObserver
{
    GDWealth m_wealth = new GDWealth();

    public override void Init()
    {
        base.Init();
    }

    public void Notify(Subject subject)
    {
        //금화추가방식에다가 사용하려했지만 이부분을 어제 생각못했으니 나중에 바꿀 수 도있음.
        //m_wealth.SetWealth();
    }

    public GDWealth Wealth { get { return m_wealth; }  set { m_wealth = value; } }

    
    
}
