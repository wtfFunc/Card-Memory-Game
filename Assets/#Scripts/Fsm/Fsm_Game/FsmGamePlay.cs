using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmGamePlay : FsmState<FSM_GAME_STATE>
{

    public FsmGamePlay() : base(FSM_GAME_STATE.PLAY)
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
