using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FsmGameOption : FsmState<FSM_GAME_STATE>
{
    private GameLogic m_gameLogic;

    public FsmGameOption(GameLogic gameLogic) : base(FSM_GAME_STATE.OPTION)
    {
        m_gameLogic = gameLogic;
    }


    public override void Enter()
    {
        
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

