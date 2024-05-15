using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 프로젝트 시작 이후 게임을 준비하는 FSM
/// </summary>
public class FsmGameResult : FsmState<FSM_GAME_STATE>
{
    private GameLogic m_gameLogic;




    public FsmGameResult(GameLogic gameLogic) : base(FSM_GAME_STATE.RESULT)
    {
        m_gameLogic = gameLogic;
    }


    public override void Enter()
    {
        GameManager.instance.restartPanel.gameObject.SetActive(false);
        GameManager.instance.startPanel.gameObject.SetActive(false);
        GameManager.instance.restartPanel.gameObject.SetActive(true);

        base.Enter();

    }
    public override void Loop()
    {
        // 없음
        base.Loop();
    }
    public override void End()
    {
        // 없음
        base.End();
    }
}
