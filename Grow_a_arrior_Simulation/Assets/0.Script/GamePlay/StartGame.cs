using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameDataManager.Instance.Init();
        GamePlayManager.Instance.Init();
        UIManager.Instance.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
