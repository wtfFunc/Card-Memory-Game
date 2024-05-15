using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ Ŭ���� �� �� ������ ��� FSM
/// </summary>
public class FsmGameResult : FsmState<FSM_GAME_STATE>
{
    private UILogic m_uiLogic;
    private GameLogic m_gameLogic;



    public FsmGameResult(UILogic uiLogic, GameLogic gameLogic) : base(FSM_GAME_STATE.RESULT)
    {
        m_uiLogic = uiLogic;
        m_gameLogic = gameLogic;
    }


    public override void Enter()
    {
        base.Enter();
        GameManager.instance.restartPanel.gameObject.SetActive(false);
        GameManager.instance.startPanel.gameObject.SetActive(false);

        GameManager.instance.resultPanel.gameObject.SetActive(true);

        m_uiLogic.ResultSequence();

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

        m_gameLogic.InitScore();
    }
}
