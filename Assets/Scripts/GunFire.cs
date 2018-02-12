using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour {
    playerInput inputs;
    public GameObject firePoint;
    public GameObject bullet;
    private List<GameObject> fingertipList;
    public bool isActive ;
    public float maxY;
    public float minY;
    public float speed;
    private bool isToOverMaxY = true;
	public int shotTimes;
    public SoundManager soundManager;
    UImanager uiManager;
    void Awake()
    {
        uiManager =GameObject.Find("Canvas").GetComponent<UImanager>();
		shotTimes = 0;
		inputs = GetComponent<playerInput> ();
        fingertipList = new List<GameObject>();
        GameObject[] fingertips = GameObject.FindGameObjectsWithTag("fingertips");
        foreach (GameObject go in fingertips)
        {
            fingertipList.Add(go);
        }
    }


    void Update () {
        if (shotTimes == 2)
        {
            print("close");
            Invoke("closeObject", 0.5f);
        }
        if (isActive)
        {
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + speed);
            if (this.transform.position.y > maxY && isToOverMaxY)
            {
                speed = speed * -1;
                isToOverMaxY = false;
            }
            else if (this.transform.position.y < minY && isToOverMaxY == false)
            {
                speed = speed * -1;
                isToOverMaxY = true;
            }
        }
        
		if (Input.GetKeyDown(inputs.player1and3StateInput(changeFinger.state,4,"3")) && shotTimes < 2 || Input.GetKeyDown( inputs.player2and4StateInput(changeFinger.state, 4, "4"))&&shotTimes<2)
        {
			if (bullet.activeInHierarchy == false)
            {
                soundManager.InitSoundeffect(2);
                print("shot");
                bullet.SetActive(true);
                bullet.transform.position = firePoint.transform.position;
                shotTimes++;
            }
        }
        

        if (bullet.activeInHierarchy == true)
        {
            foreach (GameObject go in fingertipList)
            {
                print("inLoop");
                if (Vector2.Distance(go.transform.position, bullet.transform.position) < 2f)
                {
                    
                    if (changeFinger.state == 1)
                        uiManager.blueTeamScorePlus(5);
                    if (changeFinger.state == 0)
                        uiManager.redTeamScorePlus(5);
                    print("hit");
                    soundManager.InitSoundeffect(1);
                    bullet.SetActive(false);
                    go.transform.parent.transform.parent.transform.Rotate(new Vector3(0, 0, 90f));
                    Debug.Log("hit kuncle");
                    
                }
            }
        }
	}

    private void closeObject()
    {
        gameObject.SetActive(false);
    }
}
