using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour {


    public void ChangeScoreSprite(int score)
    {
        int second1 = score % 10;
        int second10 = score / 10;

        Image[] scoreSprite = this.GetComponentsInChildren<Image>();
        numberTextList[] textSprite = this.GetComponentsInChildren<numberTextList>();
    
        scoreSprite[0].sprite = textSprite[0].numberList[second1];
        scoreSprite[1].sprite = textSprite[1].numberList[second10];
    }
}
