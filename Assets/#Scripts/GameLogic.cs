using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using System;

using DG.Tweening;

public class GameLogic : MonoBehaviour
{
    [Header("Scriptable Object")]
    public List<StageScriptableBase> stageDataTables;
    public CardScriptableBase cards;

    [ReadOnly]
    private FsmClass<FSM_GAME_STATE> fsmLogic = new FsmClass<FSM_GAME_STATE>();


    public GameObject cardPivotObject;


    public ScoreTable playerScore = new ScoreTable();

    public ScoreTable tmp_playerScore = new ScoreTable();

    public float limitTime;
    public float curTime;

    

    private StageScriptableBase curStage;
    public StageScriptableBase CurStage { get {return curStage; }}

    public int pairCount = 0;

    public float flipDuration = 0.2f;

    private void Awake()
    {
        InitFSM();
        
    }


    private void Update()
    {
        //FSM UPDATE
        fsmLogic.Update();
    }

    public void Init()
    {
        // 설정된 레벨에 맞는 스테이지를 불러옵니다
        curStage = stageDataTables[(int)GameManager.instance.e_Level];
        // 이전에 선택된 카드 인덱스 삭제
        selectCard.Clear();
        // 짝을 맞췄던 카드 개수 초기화
        pairCount = 0;
        // 타이머 초기화
        SetTimer();
        // 임시 플레이어점수표 초기화
        tmp_playerScore = new ScoreTable();
        // 스테이지 txt 동기화
        GameManager.instance.uiLogic.stageTxt.text = string.Format("{0:0} Stage", 1+(int)GameManager.instance.e_Level);
        GameManager.instance.uiLogic.pointTxt.text = string.Format("{0:00}", 0);
    }

    // Game State FSM Initalize 매서드
    private void InitFSM()
    {
        // FSM 모듈에 의존성 주입
        fsmLogic.AddFsm(new FsmGameReady(this));
        fsmLogic.AddFsm(new FsmGameOption(this));
        fsmLogic.AddFsm(new FsmGameStart(this));
        fsmLogic.AddFsm(new FsmGameResult(GameManager.instance.uiLogic, this));
    }

    public void SetState(FSM_GAME_STATE state)
    {
        fsmLogic.SetState(state);
    }

    
    // 전체카드를 한번 보여주는 코루틴입니다.
    private IEnumerator FlipCard()
    {
        WaitForSeconds FlipRate = new WaitForSeconds(0.1f);

        for (int i = 0; i < cardObjects.Count; i++)
        {
            SoundSFX.Instance.PlaySound("flip");
            // 플립 애니메이션 시퀀스
            cardObjects[i].transform.DORotate(new Vector3(0, 0, 540), flipDuration * 5f, RotateMode.FastBeyond360)
                    .SetEase(Ease.OutQuad);

           yield return FlipRate;
        }
        for (int i = 0; i < cardObjects.Count; i++)
        {
            cardObjects[i].GetComponent<Card>().boxcollider.isTrigger = true;
        }
    }
    #region SetGameLogic
    public void SetStage(StageScriptableBase table)
    {
        curStage = table;


        return ;
    }




    private System.Random rng = new System.Random();
    // 인덱스 셔플 반환매서드
    public void Shuffle(List<GameObject> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            GameObject value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
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
    public float objectSpacing = 0.1f; // 오브젝트 간 간격

    public void ResetOnStageCard()
    {
        float x = (gridWidth / curStage.stage.xCount);  
        float z = (gridHeight / curStage.stage.yCount); 

        Debug.Log(gridWidth / 2);
        Debug.Log(0.5f * x * (curStage.stage.xCount-1));

        // 중앙 배치
        Vector3 pivot = new Vector3(0.5f * x * (curStage.stage.xCount - 1), 0f, 0.5f * z * (curStage.stage.yCount - 1));

        // 카드 인덱스 셔플
        Shuffle(cardObjects);

        // 그리드의 각 행과 열을 반복하여 오브젝트를 배치
        for (int i = 0; i < curStage.stage.xCount; i++)
        {
            // X 행 배치
            int yCount = i * curStage.stage.yCount;

            for (int j = 0; j < curStage.stage.yCount; j++)
            {
                // Y 행 배치
                cardObjects[yCount + j].transform.localPosition 
                    = new Vector3(x * i - pivot.x, 0f, z * j - pivot.z);

                cardObjects[yCount + j].transform.localScale = new Vector3((x*z) * 0.1f+0.015f, x * z * 0.1f + 0.015f, x * z * 0.1f + 0.015f);
                cardObjects[yCount + j].transform.Rotate(new Vector3(0, 0, 180f));
            }
        }
        
    }

    public void StartFlipCard()
    {
        StartCoroutine(FlipCard());
    }

    public void ClearDeck()
    {
        // 카드덱 초기화
        if (cardObjects.Count > 0)
        {
            for (int i = 0; i < cardObjects.Count; i++)
            {
                Destroy(cardObjects[i].gameObject);
            }
        }
        cardObjects.Clear();
    }

    public void CreateDeck(CardScriptableBase cardTableBase)
    {
        int maxCount =  curStage.stage.xCount * curStage.stage.yCount;

        // 문양별 랜덤 픽
        generatedNumberList = new List<List<int>>();

        int div = (int)(maxCount * 0.5 / cardTableBase.cardList.Count);
        
        int[] arr = new int[4]{ div, div, div, div };

        


        for (int i = 0; i < cardTableBase.cardList.Count; i++)
        {
            if ((int)(maxCount * 0.5 / cardTableBase.cardList.Count) == 0 && i < 2)
            {
                arr[i] = arr[i] + 1;
            }
            // div 가 수트 개수보다 낮을경우 발생하는 이슈를 예외처리 분기
            else
            {
                if(div != 0)
                {
                    // 나머지 수를 생성함으로써 index range 이슈를 해결하기위한 솔루션
                    if (div * cardTableBase.cardList.Count != maxCount)
                    {
                        int res = (int)(maxCount * 0.5f) % cardTableBase.cardList.Count;


                        for (int k = 0; k < res; k++)
                        {
                            if(i == k)
                            {
                                arr[k] = arr[k] + 1;
                            }
                        }
                    }
                }
            }

            // 페어가 존재하여야 하니 전체 카드수량중 절반만 랜덤픽 합니다.
            generatedNumbers = new List<int>();

            

            for (int j = 0; j < arr[i]; j++)
            {

                generatedNumbers.Add(GenerateUniqueRandom(0, cardTableBase.cardList[0].cardPrefab.Count-1));
                //i문양의 j족보의 카드를 픽을 두번 시행
                GameObject firstCardObj =  Instantiate(cardTableBase.cardList[i].cardPrefab[generatedNumbers[j]]).gameObject;


                CardFactory.Create(firstCardObj, this, cardTableBase.cardList[i], generatedNumbers[j]);

                firstCardObj.transform.SetParent(cardPivotObject.transform);
                cardObjects.Add(firstCardObj);

                GameObject secondCardObj = Instantiate(cardTableBase.cardList[i].cardPrefab[generatedNumbers[j]]).gameObject;


                CardFactory.Create(secondCardObj, this, cardTableBase.cardList[i], generatedNumbers[j]);

                secondCardObj.transform.SetParent(cardPivotObject.transform);
                cardObjects.Add(secondCardObj);

                // cardObjects.Add(Instantiate(cardTableBase.cardList[i].cardPrefab[generatedNumbers[j]]));
            }
            generatedNumberList.Add(generatedNumbers);
        }
    }




    public List<Card> selectCard = new List<Card>();
    public void PairMatchCard(Card select)
    {
        switch (selectCard.Count)
        {
            case 0:
                selectCard.Add(select);
                select.SendState(Card_State.Open);

                break;

            case 1:
                // 카드 수트와 숫자를 비교하여 같다면 페어 처리
                if(selectCard[0].suit == select.suit && selectCard[0].num == select.num)
                {
                    // 페어처리
                    // selectCard[0].SendState(Card_State.Pair);
                    select.SendState(Card_State.Open);
                    StartCoroutine(SuccessMatchCard(selectCard[0], select));

                    tmp_playerScore.pairScore += stageDataTables[(int)GameManager.instance.e_Level].stagePairScore;

                    GameManager.instance.uiLogic.pointTxt.text =string.Format("{0:00}", tmp_playerScore.pairScore);

                    SoundSFX.Instance.PlaySound("pair");

                    pairCount++;
                    if(pairCount * 2 == cardObjects.Count)
                    {
                        ClearGame();
                    }
                }
                else
                {
                    // 두번째 카드를 오픈
                    select.SendState(Card_State.Open);


                    // 매치 실패 대미지 코드
                    StartCoroutine(FailedMatchCard(selectCard[0], select));

                }

                selectCard.Clear();
                break;
        }


    }
    IEnumerator SuccessMatchCard(Card first, Card second)
    {
        while (true)
        {
            yield return new WaitForSeconds(flipDuration);
            break;
        }
        first.SendState(Card_State.Pair);
        second.SendState(Card_State.Pair);
    }
    IEnumerator FailedMatchCard(Card first, Card second)
    {
        while (true)
        {
            yield return new WaitForSeconds(flipDuration);
            break;
        }
        first.SendState(Card_State.Close);
        second.SendState(Card_State.Close);
    }



    public void ClearGame()
    {
        // 임시 Score 갱신
        tmp_playerScore.clearScore += stageDataTables[(int)GameManager.instance.e_Level].stageClaerScore;
        tmp_playerScore.timeScore += (int)curTime;



        playerScore.clearScore += tmp_playerScore.clearScore;
        playerScore.pairScore += tmp_playerScore.pairScore;
        playerScore.timeScore += tmp_playerScore.timeScore;


        tmp_playerScore.totalScore = tmp_playerScore.clearScore + tmp_playerScore.pairScore + tmp_playerScore.timeScore;
        playerScore.totalScore += tmp_playerScore.totalScore;




        if (GameManager.instance.e_Level < e_Level.third)
        {
            // nextLevel
            NextGame();
        }
        else
        {
            // result 출력
            SetState(FSM_GAME_STATE.RESULT);
        }
    }

    public void NextGame()
    {


        GameManager.instance.e_Level++; 
        SetState(FSM_GAME_STATE.READY);
    }



    public void InitScore()
    {
        playerScore = new ScoreTable();
    }



    
    public void SetTimer()
    {
        limitTime = stageDataTables[(int)GameManager.instance.e_Level].stageTimeLimit;
        curTime = limitTime;
    }
    public void LoopTimer()
    {
        if(curTime <= 0f)
        {
            NextGame();
        }
        else
        {
            curTime -= Time.deltaTime;
        }

        GameManager.instance.uiLogic.SetTimeText(curTime);
    }

    public void CloseCard(ISendState state)
    {
        state.SendState(Card_State.Close);
    }

    public void OpenCard(ISendState state)
    {
        state.SendState(Card_State.Open);
    }

    public void PairCard(ISendState state)
    {
        state.SendState(Card_State.Pair);
    }

    public void TouchToCard()
    {
        if (Input.touchCount > 0 )
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.isTrigger == true)
                    {
                        // 터치된 오브젝트에 대한 처리를 여기에 작성

                        // 카드일 경우 호출
                        Card interactable = hit.collider.GetComponent<Card>();
                        if (interactable != null)
                        {
                            PairMatchCard(interactable);
                        }
                    }
                }
            }
        }
#if UNITY_EDITOR
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (true)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    // 터치된 오브젝트에 대한 처리를 여기에 작성
                    if(hit.collider.isTrigger == true)
                    {
                        // 카드일 경우 호출
                        Card interactable = hit.collider.GetComponent<Card>();
                        if (interactable != null)
                        {
                            PairMatchCard(interactable);
                        }

                    }
                }
            }
        }
#endif
    }

    List<List<int>> generatedNumberList = new List<List<int>>();
    List<int> generatedNumbers = new List<int>();
    private int GenerateUniqueRandom(int min, int max)
    {
        
        // min부터 max까지의 숫자 중에서 중복되지 않는 숫자를 생성
        int num = UnityEngine.Random.Range(min, max);

        while (true)
        {
            if(generatedNumbers.Contains(num))
            {
                num = UnityEngine.Random.Range(min, max);
            }
            else
            {

                break;
            }
        }
        return num;
    }

    #endregion

}

public enum Card_State
{
    Open,
    Close,
    Pair
}

[Serializable]
public class ScoreTable
{
    [SerializeField]
    public int pairScore = 0;
    [SerializeField]
    public int clearScore = 0;
    [SerializeField]
    public int timeScore = 0;
    [SerializeField]
    public int totalScore = 0;
}
