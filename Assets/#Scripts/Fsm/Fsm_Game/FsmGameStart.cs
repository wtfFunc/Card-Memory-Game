using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������Ʈ ���� ���� ���� Start�� ����ϴ� FSM
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
        // Ÿ�̸� �ʱ�ȭ

        // ī�� �迭 �ʱ�ȭ
        m_gameLogic.ResetOnStageCard();
        // // ī�� �ѹ� �����ֱ� (�ø����)
        m_gameLogic.StartFlipCard();

        GameManager.instance.restartPanel.SetActive(true);
        GameManager.instance.resultPanel.SetActive(false);
        GameManager.instance.startPanel.SetActive(false);
        base.Enter();

    }
    public override void Loop()
    {
        // ��ġ ����
        m_gameLogic.TouchToCard();
        m_gameLogic.LoopTimer();
        base.Loop();
    }
    public override void End()
    {
        base.End();
    }


}