using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class handPoseModChange : MonoBehaviour {
    public GameObject[] poseMod;
    public Sprite[] poseTips;
    public GameObject PoseTip;
    public static int r;
    float changePoseTime = 33;
	// Use this for initialization
	void Start () {
        r = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (UImanager.isGameStart&&!UImanager.isGameEnd)
        {
            changePoseTime -= Time.deltaTime;
            PoseTip.GetComponent<Image>().sprite = poseTips[r];
        }
        if (changePoseTime <= 0&&r<2)
        {
            r++;
            changePoseTime = 33;
        }
        if (changePoseTime <= 0 && r == 2)
        {
            r--;
            changePoseTime = 33;
        }

	}

    public GameObject getPose()
    {
        return poseMod[r];
    }
}
