using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Card : MonoBehaviour, ISendState
{
    

    [HideInInspector]
    public GameLogic m_gameLogic = null;


    public void Initialize(GameLogic gameLogic, CardDataTable dataTable, int  pNum)
    {
        m_gameLogic = gameLogic;
        boxcollider = GetComponent<BoxCollider>();
        cardName = dataTable.name;
        suit = dataTable.suit;
        num = pNum;
    }



    private void Awake()
    {
        
    }
    private void Start()
    {
        Init();
    }

    private void Update()
    {
        
    }

    

    private void Init()
    {
        boxcollider.isTrigger = true;
        state = Card_State.Close;

    }

    public BoxCollider boxcollider;


    public string cardName;
    public Card_State state;
    public e_Suit suit;
    public int num;

    


    public void SendState(Card_State sendState)
    {
        state = sendState;
        switch (state)
        {
            case Card_State.Open:
                Open();
                break;

            case Card_State.Close:
                Close();
                break;

            case Card_State.Pair:
                Pair();
                break;

            default:
                break;
        }
    }


    private void Open()
    {
        boxcollider.isTrigger = false;
        transform.DOLocalRotate(new Vector3(0, 0, 0), m_gameLogic.flipDuration);
    }
    private void Close()
    {
        transform.DOLocalRotate(new Vector3(0, 0, -180), m_gameLogic.flipDuration)
            .OnComplete(()=> 
            {
                boxcollider.isTrigger = true; 
            });

    }
    private void Pair()
    {
        boxcollider.isTrigger = false;
    }


}


public class CardFactory
{
    public static Card Create(GameObject parent, GameLogic gameLogic, CardDataTable dataTable, int num)
    {
        Card component = parent.gameObject.AddComponent<Card>();
        component.Initialize(gameLogic, dataTable, num);
        return component;
    }
}