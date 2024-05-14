using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CardScriptableBase : ScriptableObject
{
    

    [SerializeField]
    public List<CardDataTable> cardList = new List<CardDataTable>();


    
    
}

/// <summary>
/// 직렬화된 카드데이터 테이블 구조
/// </summary>
[Serializable]
public class CardDataTable
{
    /// <summary>
    /// 카드이름 (suit 접두 하지 않아도 됩니다)
    /// </summary>
    [SerializeField]
    public string name;

    
    /// <summary>
    /// 카드문양
    /// </summary>
    [SerializeField]
    public e_Suit suit;

    /// <summary>
    /// 카드 3D 모델링오브젝트
    /// </summary>
    [SerializeField]
    public List<GameObject> cardPrefab;

}

[Serializable]
public class StageDataTable
{
    /// <summary>
    /// 격자배열 정보
    /// </summary>
    [SerializeField]
    public int xCount,yCount;



}

public enum e_Suit
{
    hearts,
    spades,
    diamonds,
    clubs
}