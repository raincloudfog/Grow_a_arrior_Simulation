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


    //TGameData == T �׳� ���׸��̴�. // �߰� new() �̰� �� ���� ��������� Ŭ������ ��밡���ϴ�.
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



    //������Ʈ �߰� ����
    public void Update()
    {
        var _var =m_GameDatas.GetEnumerator();

        while(_var.MoveNext())
        {
            _var.Current.Value.UpdateLogic();
        }
    }
}
