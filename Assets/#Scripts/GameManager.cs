using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 게임매니저 싱글톤 선언
    public static GameManager instance = null;

    public GameLogic gameLogic;

    public Button startButton;
    public Button restartButton;
    public Button resultButton;


    [Header("UI Panels")]
    public GameObject startPanel;
    public GameObject restartPanel;
    public GameObject resultPanel;
    public GameObject endGamePanel;


    public e_Level e_Level = e_Level.first;

    private void Awake()
    {
        // 매니저 인스턴스화
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gameLogic.SetState(FSM_GAME_STATE.READY);

        // gameLogic.SetState(FSM_GAME_STATE.PLAY);
        startButton.onClick.AddListener(() => { gameLogic.SetState(FSM_GAME_STATE.START); });
        restartButton.onClick.AddListener(() => { gameLogic.SetState(FSM_GAME_STATE.READY); });
        resultButton.onClick.AddListener(() => { gameLogic.SetState(FSM_GAME_STATE.RESULT); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


public enum e_Level
{
    first,
    second,
    third
}