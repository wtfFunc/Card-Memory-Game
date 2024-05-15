using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class StageScriptableBase : ScriptableObject
{
    [SerializeReference]
    public StageDataTable stage = new StageDataTable();

    /// <summary>
    /// �������� ���ѽð�
    /// </summary>
    [SerializeReference]
    public float stageTimeLimit;


    /// <summary>
    /// 1ȸ ����� ����
    /// </summary>
    [SerializeReference]
    public int stagePairScore;


    /// <summary>
    /// �޺� �����ð�
    /// </summary>
    [SerializeReference]
    public float stageComboTime;


    /// <summary>
    /// ���н� �����
    /// </summary>
    [SerializeReference]
    public float stageFaildDamage;


    /// <summary>
    /// �������� Ŭ���� ���ھ�
    /// </summary>
    [SerializeReference]
    public int stageClaerScore;


    /// <summary>
    /// �������� Ŭ���� ���ھ�
    /// </summary>
    [SerializeReference][TextAreaAttribute(10, 10)]
    public string stageDescription;
}
