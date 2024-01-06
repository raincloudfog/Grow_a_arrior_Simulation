using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : Singleton<GameDataManager>
{
    Dictionary<System.Type, GameData> m_GameDatas = new Dictionary<System.Type, GameData>();

    public void Init()
    {
        AddData<GameData_Wealth>();
        AddData<GameDataPlayer>();
    }


    //TGameData == T 그냥 제네릭이다. // 추가 new() 이걸 즉 새로 만들어지는 클래스만 사용가능하다.
    void AddData<TGameData>() where TGameData : GameData , new()
    {
        System.Type type = typeof(TGameData);
        if(m_GameDatas.ContainsKey(type))
        {
            Debug.LogError("GameDataManager:AddData() [ have : " + type.ToString());
            return;
        }

        m_GameDatas.Add(type, new TGameData());
    }

    public GameData_Wealth GetWealthData()
    {
        System.Type type = typeof(GameData_Wealth);
        GameData data = m_GameDatas[type];
        GameData_Wealth dataWealth = data as GameData_Wealth;
        return dataWealth;
    }

    public GameDataPlayer GetPlayerData()
    {
        System.Type type = typeof(GameDataPlayer);
        GameData data = m_GameDatas[type];
        GameDataPlayer dataWealth = data as GameDataPlayer;
        return dataWealth;
    }



    //업데이트 추가 대비용
    public void Update()
    {
        var _var =m_GameDatas.GetEnumerator();

        while(_var.MoveNext())
        {
            _var.Current.Value.UpdateLogic();
        }
    }
}
