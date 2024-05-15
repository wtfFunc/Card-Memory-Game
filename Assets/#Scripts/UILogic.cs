using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UILogic : MonoBehaviour
{
    public Text timeTxt;
    public Text stageTxt;
    public Text pointTxt;




    [Header("Result Board")]
    public Text pairBonusTxt;
    public Text clearBonusTxt;
    public Text timeBonusTxt;
    public Text totalBonusTxt;
    public Text bestScoreTxt;

    public void SetScoreText(int point)
    {

    }

    public void SetStageText(int stageNum)
    {

    }

    public void SetTimeText(float cur)
    {
        timeTxt.text = string.Format("{0:00} sec", cur);
    }

    private void SetBestScoreText()
    {
        if (PlayerPrefs.GetInt("MaxScore") < GameManager.instance.gameLogic.playerScore.totalScore)
        {
            PlayerPrefs.SetInt("MaxScore", GameManager.instance.gameLogic.playerScore.totalScore);
        }
    }

    public void ResultSequence()
    {
        SetBestScoreText();
        GameManager.instance.resultButton.gameObject.SetActive(false);

        pairBonusTxt.text = string.Format("");
        clearBonusTxt.text = string.Format("");
        timeBonusTxt.text = string.Format("");
        totalBonusTxt.text = string.Format("");
        bestScoreTxt.text = string.Format("");

        pairBonusTxt.DOText(string.Format("Pair Bonus: {0:00}", GameManager.instance.gameLogic.playerScore.pairScore), 2f).OnComplete(() =>
            {
                clearBonusTxt.DOText(string.Format("Clear Bonus: {0:00}", GameManager.instance.gameLogic.playerScore.clearScore), 2f).OnComplete(()=>
                {
                    timeBonusTxt.DOText(string.Format("Time Bonus: {0:00}", GameManager.instance.gameLogic.playerScore.timeScore), 2f).OnComplete(()=>
                    {
                        totalBonusTxt.DOText(string.Format("total Score: {0:00}", GameManager.instance.gameLogic.playerScore.totalScore), 2f).OnComplete(()=>
                        {
                            bestScoreTxt.DOText(string.Format("Best Score: {0:00}", PlayerPrefs.GetInt("MaxScore")), 2f).OnComplete(()=>
                            {
                                GameManager.instance.resultButton.gameObject.SetActive(true);
                            });
                        });
                    });
                });
            });

    }
}
