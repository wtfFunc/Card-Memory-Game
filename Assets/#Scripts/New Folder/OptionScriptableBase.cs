using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class OptionScriptableBase : ScriptableObject
{
    [Header("SoundSettings")]
    [SerializeField][Range(0.0f,1.0f)]
    public float masterVolum;

    [SerializeField][Range(0.0f, 1.0f)]
    public float bgVolum;

    [SerializeField][Range(0.0f, 1.0f)]
    public float effectVolum;


}
