using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        // ī�� �ѹ� �����ֱ� (�ø����)

        // 

        base.Enter();

    }
    public override void Loop()
    {

        base.Loop();
    }
    public override void End()
    {
        base.End();
    }


}