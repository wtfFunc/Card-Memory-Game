using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class StageScriptableBase : ScriptableObject
{
    [SerializeReference]
    public StageDataTable stage = new StageDataTable();

    /// <summary>
    /// 스테이지 제한시간
    /// </summary>
    [SerializeReference]
    public float stageTimeLimit;


    /// <summary>
    /// 1회 수행시 점수
    /// </summary>
    [SerializeReference]
    public int stagePairScore;


    /// <summary>
    /// 콤보 유지시간
    /// </summary>
    [SerializeReference]
    public float stageComboTime;


    /// <summary>
    /// 실패시 대미지
    /// </summary>
    [SerializeReference]
    public float stageFaildDamage;


    /// <summary>
    /// 스테이지 클리어 스코어
    /// </summary>
    [SerializeReference]
    public int stageClaerScore;


    /// <summary>
    /// 스테이지 클리어 스코어
    /// </summary>
    [SerializeReference][TextAreaAttribute(10, 10)]
    public string stageDescription;
}
