using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������Ʈ ���� ���� ������ �غ��ϴ� FSM
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
        // ����
        base.Loop();
    }
    public override void End()
    {
        // ����
        base.End();
    }
}
