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
        // 타이머 초기화
        
        // 카드 배열 초기화

        // 카드 한번 보여주기 (플립모션)

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