using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 프로젝트 시작 이후 게임 Start를 담당하는 FSM
/// </summary>
public class FsmGameStart : FsmState<FSM_GAME_STATE>
{
    private GameLogic m_gameLogic;

    public FsmGameStart(GameLogic gameLogic) : base(FSM_GAME_STATE.START)
    {
        m_gameLogic = gameLogic;
    }


    public override void Enter()
    {
        // 타이머 초기화

        // 카드 배열 초기화
        m_gameLogic.ResetOnStageCard();
        // // 카드 한번 보여주기 (플립모션)
        m_gameLogic.StartFlipCard();

        GameManager.instance.restartPanel.SetActive(true);
        GameManager.instance.resultPanel.SetActive(false);
        GameManager.instance.startPanel.SetActive(false);
        base.Enter();

    }
    public override void Loop()
    {
        // 터치 루프
        m_gameLogic.TouchToCard();
        m_gameLogic.LoopTimer();
        base.Loop();
    }
    public override void End()
    {
        base.End();
    }


}