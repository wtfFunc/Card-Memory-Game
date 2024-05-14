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

        // ī�带 ��ġ���� �迭 ��ġ�� �ʿ��� ��� �������� ī�带 ��ĥ������
        curStage = stageDataTables[0];

        CreateDeck(cards);
        ResetOnStageCard();
    }


    private void Update()
    {
        fsmLogic.Update();
    }



    // Game State FSM Initalize �ż���
    private void InitFSM()
    {
        // FSM ��⿡ ������ ����
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

    public List<GameObject> cardObjects = new List<GameObject>(); // �׸��忡 ������ ������Ʈ��
    public float gridWidth = 5;  // �׸��� ���� ����
    public float gridHeight = 5; // �׸��� ���� ����
    public float objectSpacing = 10f; // ������Ʈ �� ����

    public void ResetOnStageCard()
    {
        float x = (gridWidth / curStage.stage.xCount);  
        float z = (gridHeight / curStage.stage.yCount); 

        Debug.Log(gridWidth / 2);
        Debug.Log(0.5f * x * (curStage.stage.xCount-1));

        // �߾� ��ġ
        Vector3 pivot = new Vector3(0.5f * x * (curStage.stage.xCount - 1), 0f, 0.5f * z * (curStage.stage.yCount - 1));

        // �׸����� �� ��� ���� �ݺ��Ͽ� ������Ʈ�� ��ġ
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
        // ī�嵦 �ʱ�ȭ
        if(cardObjects.Count > 0)
        {
            for (int i = 0; i < cardObjects.Count; i++)
            {
                Destroy(cardObjects[i].gameObject);
            }
        }
        cardObjects.Clear();
        Debug.Log("�ʱ�ȭ");

        int maxCount =  curStage.stage.xCount * curStage.stage.yCount;


        // ���纰 ���� ��
        generatedNumberList = new List<List<int>>();
        for (int i = 0; i < cardTableBase.cardList.Count; i++)
        {
            // ���� ������� ���� FOR���� �߸��������� ���ѷ��� �ɸ�

            // �� �����Ͽ��� �ϴ� ��ü ī������� ���ݸ� ������ �մϴ�.
            generatedNumbers = new List<int>();
            for (int j = 0; j <  i * ((int)(maxCount * 0.5 / cardTableBase.cardList.Count)); j++)
            {
                generatedNumbers.Add(GenerateUniqueRandom(0, cardTableBase.cardList.Count-1));

                //i������ j������ ī�带 ���� �ι� ����
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
        
        // min���� max������ ���� �߿��� �ߺ����� �ʴ� ���ڸ� ����
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
        // } while (generatedNumbers.Contains(num)); // �̹� ������ ���ڸ� �ٽ� ����

        // generatedNumbers.Add(num); // ������ ���ڸ� ����Ʈ�� �߰�
        return num;
    }

    #endregion

}