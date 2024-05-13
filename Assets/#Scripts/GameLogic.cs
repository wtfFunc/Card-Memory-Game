using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class GameLogic : MonoBehaviour
{


    [Header("Scriptable Object")]
    public List<StageScriptableBase> stageDataTables;
    public CardScriptableBase cards;

    [ReadOnly]
    private FsmClass<FSM_GAME_STATE> fsmLogic = new FsmClass<FSM_GAME_STATE>();



    [SerializeField]
    public FSM_GAME_STATE curFsmState { get { return fsmLogic.getCurState.getStateType; }  }

    private void Awake()
    {
        InitFSM();
        SetState(FSM_GAME_STATE.START);

    }

    private void Update()
    {
        fsmLogic.Update();
    }



    // Game State FSM Initalize ¸Å¼­µå
    private void InitFSM()
    {
        fsmLogic.AddFsm(new FsmGamePlay());
        fsmLogic.AddFsm(new FsmGameOption());
        fsmLogic.AddFsm(new FsmGameStart());
    }

    private void SetState(FSM_GAME_STATE state)
    {
        fsmLogic.SetState(state);
    }
    



}