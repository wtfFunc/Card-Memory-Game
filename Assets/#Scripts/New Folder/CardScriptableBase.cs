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
/// ����ȭ�� ī�嵥���� ���̺� ����
/// </summary>
[Serializable]
public class CardDataTable
{
    /// <summary>
    /// ī���̸� (suit ���� ���� �ʾƵ� �˴ϴ�)
    /// </summary>
    [SerializeField]
    public string name;

    
    /// <summary>
    /// ī�幮��
    /// </summary>
    [SerializeField]
    public e_Suit suit;

    /// <summary>
    /// ī�� 3D �𵨸�������Ʈ
    /// </summary>
    [SerializeField]
    public List<GameObject> cardPrefab;

}

[Serializable]
public class StageDataTable
{
    /// <summary>
    /// ���ڹ迭 ����
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