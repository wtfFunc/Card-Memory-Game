using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 게임매니저 싱글톤 선언
    public static GameManager instance = null;

    public GameLogic gameLogic;

    


    private void Awake()
    {
        // 매니저 인스턴스화
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameLogic);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
