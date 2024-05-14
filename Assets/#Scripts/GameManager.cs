using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ���ӸŴ��� �̱��� ����
    public static GameManager instance = null;

    public GameLogic gameLogic;

    


    private void Awake()
    {
        // �Ŵ��� �ν��Ͻ�ȭ
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameLogic);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
