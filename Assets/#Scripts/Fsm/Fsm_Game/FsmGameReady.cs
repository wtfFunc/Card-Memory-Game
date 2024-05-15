using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������Ʈ ���� ���� ������ �غ��ϴ� FSM
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
        // ���� ���� UI ���� �� �ʱ�ȭ
        base.Enter();

        m_gameLogic.Init();
        // ������
        m_gameLogic.ClearDeck();
        m_gameLogic.CreateDeck(m_gameLogic.cards);
        // �� ����
        // m_gameLogic.ResetOnStageCard();
        GameManager.instance.restartPanel.SetActive(false);
        GameManager.instance.startPanel.SetActive(true);
        GameManager.instance.resultPanel.SetActive(false);

    }
    public override void Loop()
    {
        // ����
        base.Loop();
    }
    public override void End()
    {
        // ����
        base.End();
    }
}
