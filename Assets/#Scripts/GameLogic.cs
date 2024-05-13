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





    private void Awake()
    {
        InitFSM();
        SetState(FSM_GAME_STATE.START);

    }


    private void Update()
    {
        fsmLogic.Update();
    }



    // Game State FSM Initalize 매서드
    private void InitFSM()
    {
        // FSM 모듈에 의존성 주입
        fsmLogic.AddFsm(new FsmGamePlay(this));
        fsmLogic.AddFsm(new FsmGameOption(this));
        fsmLogic.AddFsm(new FsmGameStart(this));
    }

    private void SetState(FSM_GAME_STATE state)
    {
        fsmLogic.SetState(state);
    }

    
    IEnumerator FlipCard()
    {
        WaitForSeconds FlipRate = new WaitForSeconds(0.5f);



        while (true)
        {


            break;
        }
        yield return null;
    }


}