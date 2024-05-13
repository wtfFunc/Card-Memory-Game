using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmGamePlay : FsmState<FSM_GAME_STATE>
{
    private GameLogic m_gameLogic;

    public FsmGamePlay(GameLogic gameLogic) : base(FSM_GAME_STATE.PLAY)
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
