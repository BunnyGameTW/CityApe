using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoxPos : MonoBehaviour {
    public GameObject checkObj;
    UImanager uiManager;
    public int index;
    public int priortyNum;
    bool once,upcheck, birdcheck, downcheck;
    public static int num1,num2,num3;
    public int group;
    GameObject gun;
	// Use this for initialization
	void Start () {
        downcheck = birdcheck = upcheck = once = true;
        num1 = num2 = num3 = 0;
        gun = Camera.main.GetComponent<changeFinger>().gun;
        uiManager = GameObject.Find("Canvas").GetComponent<UImanager>();
    }
	
	// Update is called once per frame
	void Update () {
        check();

    }
    void check() {
        if (Vector2.Distance(checkObj.transform.GetChild(this.index).position, transform.position) <= 0.1f)
        {
          
            if (once)
            {
                once = false;
                if(group == 1)num1 += priortyNum;
                if (group == 2) num2 += priortyNum;
                if (group == 3) num3 += priortyNum;
                //Debug.Log(num1 + "num1");
                //Debug.Log(num2 + "num2");
                //Debug.Log(num3 + "num3");

            }

        }
        else
        {
            if (!once){
                once = true;
                if (group == 1) num1 -= priortyNum;
                if (group == 2) num2 -= priortyNum;
                if (group == 3) num3 -= priortyNum;
                Debug.Log(num1 + "num1");
                Debug.Log(num2 + "num2");
                Debug.Log(num3 + "num3");
            }

        }
        if(num1 == 10 && upcheck)
        {
            upcheck = false;
            gun.SetActive(true);
            Debug.Log("Up finish");
            num1 = 0;
        }
        else if (num2 == 135 && birdcheck)
        {
            birdcheck = false;
            gun.SetActive(true);
            Debug.Log("bird finish");
            num2 = 0;

        }
        else if (num3 == 550 && downcheck ||(Input.GetKeyDown(KeyCode.F2)))
        {
            downcheck = false;
            Debug.Log("down finish");
            uiManager.resetEverything();
            num3 = 0;

        }
    }
}
