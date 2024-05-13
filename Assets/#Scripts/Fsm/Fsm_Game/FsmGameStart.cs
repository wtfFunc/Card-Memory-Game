using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmGameStart : FsmState<FSM_GAME_STATE>
{

    public FsmGameStart() : base(FSM_GAME_STATE.START)
    {

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