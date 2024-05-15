using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 프로젝트 시작 이후 게임을 준비하는 FSM
/// </summary>
public class FsmGameReady : FsmState<FSM_GAME_STATE>
{
    private GameLogic m_gameLogic;

    


    public FsmGameReady(GameLogic gameLogic) : base(FSM_GAME_STATE.READY)
    {
        m_gameLogic = gameLogic;
    }


    public override void Enter()
    {
        // 게임 시작 UI 노출 및 초기화
        base.Enter();

        m_gameLogic.Init();
        // 덱세팅
        m_gameLogic.ClearDeck();
        m_gameLogic.CreateDeck(m_gameLogic.cards);
        // 덱 노출
        // m_gameLogic.ResetOnStageCard();
        GameManager.instance.restartPanel.SetActive(false);
        GameManager.instance.startPanel.SetActive(true);
        GameManager.instance.resultPanel.SetActive(false);

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
