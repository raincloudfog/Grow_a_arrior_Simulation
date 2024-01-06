using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;


public enum ePLAYER_STAT
{
    HP,
    DAMAGE,
    CRITICAL
}

//게임데이터 플레이어
public class GDPlayer
{
    public int Hp_lv;
    public int Damage_lv;
    public float Critical_lv;


    public void LevelUp(ePLAYER_STAT stat)
    {
        switch (stat)
        {
            case ePLAYER_STAT.HP:
                Hp_lv++;
                break;
            case ePLAYER_STAT.DAMAGE:
                Damage_lv++;
                break;
            case ePLAYER_STAT.CRITICAL:
                Critical_lv++;
                break;
        }
    }
}

public class GameDataPlayer : GameData
{
    GDPlayer m_Player = new GDPlayer();

    public override void Init()
    {
        base.Init();
    }

    public GDPlayer GetPlayer { get { return m_Player; } set { m_Player = value; } }
    
}
