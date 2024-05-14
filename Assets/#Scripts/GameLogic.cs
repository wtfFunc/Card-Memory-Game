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


    public GameObject cardPivotObject;


    private StageScriptableBase curStage;
    public StageScriptableBase CurStage { get {return curStage; }}
    


    private void Awake()
    {
        InitFSM();
        SetState(FSM_GAME_STATE.START);

        // 카드를 펼치려면 배열 위치가 필요함 어디를 기점으로 카드를 펼칠것인지
        curStage = stageDataTables[0];

        CreateDeck(cards);
        ResetOnStageCard();
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
    #region SetGameLogic
    public void SetStage(StageScriptableBase table)
    {
        curStage = table;


        return ;
    }


    #endregion

    #region GetGameLogic
    public StageScriptableBase GetStage()
    {
        return curStage;
    }
    #endregion

    #region Function

    public List<GameObject> cardObjects = new List<GameObject>(); // 그리드에 정렬할 오브젝트들
    public float gridWidth = 5;  // 그리드 가로 길이
    public float gridHeight = 5; // 그리드 세로 길이
    public float objectSpacing = 10f; // 오브젝트 간 간격

    public void ResetOnStageCard()
    {
        float x = (gridWidth / curStage.stage.xCount);  
        float z = (gridHeight / curStage.stage.yCount); 

        Debug.Log(gridWidth / 2);
        Debug.Log(0.5f * x * (curStage.stage.xCount-1));

        // 중앙 배치
        Vector3 pivot = new Vector3(0.5f * x * (curStage.stage.xCount - 1), 0f, 0.5f * z * (curStage.stage.yCount - 1));

        // 그리드의 각 행과 열을 반복하여 오브젝트를 배치
        for (int i = 0; i < curStage.stage.xCount; i++)
        {
            int yCount = i * curStage.stage.yCount;

            for (int j = 0; j < curStage.stage.yCount; j++)
            {

                Debug.Log("index = " + (yCount + j));
                cardObjects[yCount + j].transform.localPosition 
                    = new Vector3(x * i - pivot.x, 0f, z * j - pivot.z);

                cardObjects[yCount + j].transform.localScale = new Vector3(x * 0.1f, x * 0.1f, x * 0.1f);
            }
        }
    }

    public void CreateDeck(CardScriptableBase cardTableBase)
    {
        // 카드덱 초기화
        if(cardObjects.Count > 0)
        {
            for (int i = 0; i < cardObjects.Count; i++)
            {
                Destroy(cardObjects[i].gameObject);
            }
        }
        cardObjects.Clear();
        Debug.Log("초기화");

        int maxCount =  curStage.stage.xCount * curStage.stage.yCount;


        // 문양별 랜덤 픽
        generatedNumberList = new List<List<int>>();
        for (int i = 0; i < cardTableBase.cardList.Count; i++)
        {
            // 여기 수정요망 위에 FOR문이 잘못돌고있음 무한루프 걸림

            // 페어가 존재하여야 하니 전체 카드수량중 절반만 랜덤픽 합니다.
            generatedNumbers = new List<int>();
            for (int j = 0; j <  i * ((int)(maxCount * 0.5 / cardTableBase.cardList.Count)); j++)
            {
                generatedNumbers.Add(GenerateUniqueRandom(0, cardTableBase.cardList.Count-1));

                //i문양의 j족보의 카드를 픽을 두번 시행
                cardObjects.Add(Instantiate(cardTableBase.cardList[i].cardPrefab[generatedNumbers[j]]));
                cardObjects.Add(Instantiate(cardTableBase.cardList[i].cardPrefab[generatedNumbers[j]]));
            }
            generatedNumberList.Add(generatedNumbers);

            
        }
    }
    



    public void PairMatchCard()
    {
        
    }

    public void FailedMatchCard()
    {

    }

    public void RestartGame()
    {

    }

    public void ClearGame()
    {

    }

    public void FailedGame()
    {

    }

    public void HintAction()
    {
        
    }


    List<List<int>> generatedNumberList = new List<List<int>>();
    List<int> generatedNumbers = new List<int>();
    private int GenerateUniqueRandom(int min, int max)
    {
        
        // min부터 max까지의 숫자 중에서 중복되지 않는 숫자를 생성
        int num = Random.Range(min, max);

        while (true)
        {
            if(generatedNumbers.Contains(num))
            {
                num = Random.Range(min, max);
            }
            else
            {

                break;
            }
        }

        // do
        // {
        //     num = Random.Range(min, max);
        // } while (generatedNumbers.Contains(num)); // 이미 생성된 숫자면 다시 생성

        // generatedNumbers.Add(num); // 생성된 숫자를 리스트에 추가
        return num;
    }

    #endregion

}