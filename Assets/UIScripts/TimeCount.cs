using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour {

    public void ChangeTimeSprite(int time)
    {
        int second1 = time % 10;
        int second10 = time / 10;

        Image[] timeSprite = this.GetComponentsInChildren<Image>();
        numberTextList[] textSprite = this.GetComponentsInChildren<numberTextList>();

        timeSprite[0].sprite = textSprite[0].numberList[second1];
        timeSprite[1].sprite = textSprite[1].numberList[second10];
    }
}
