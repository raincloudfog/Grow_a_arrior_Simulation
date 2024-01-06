using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIWealth : UIdialog
{
    public TMP_Text m_gold;
    public TMP_Text m_diamond;

    public override void Init()
    {
        base.Init();
        //SetPullpresets();
    }

    public override void Logout()
    {
        base.Logout();
    }
}
