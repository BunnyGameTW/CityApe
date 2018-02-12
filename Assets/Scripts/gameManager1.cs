using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager1 : MonoBehaviour {
	[Header("手勢類別")]
	public GameObject checkPose;
	public GameObject aimPoint;
    public GameObject leftGun;
	GameObject[] players ;
	public bool handPosFunction;
	public bool aimFunction=false;
	playerInput inputs;
    UImanager uiManager;
    public SoundManager soundManager;

	void Awake()
	{
		inputs = GetComponent<playerInput> ();
		
		players = GameObject.FindGameObjectsWithTag("Player");
		// playerList = new List<GameObject>();
		//foreach (GameObject go in players)
		//{
		//  playerList.Add(go);
		// }
	}


	void Start () {
        uiManager =GameObject.Find("Canvas").GetComponent<UImanager>();
        leftGun.SetActive(false);
		aimPoint= Instantiate (aimPoint, Vector3.zero, transform.rotation);
		aimPoint.SetActive (false);
	}


	void Update () {

        //定位點功能
        if(UImanager.isGameStart)
            checkPoint();


		//外對內妨礙功能

        if (aimFunction)
        {
            leftGun.SetActive(true);
			aimPoint.SetActive (true);
			if(Input.GetKey(inputs.player1and3StateInput(changeFinger.state,0,"1")))
				aimPoint.transform.Translate(Vector2.up*5*Time.deltaTime);
			if(Input.GetKey(inputs.player1and3StateInput(changeFinger.state,1,"1")))
				aimPoint.transform.Translate(Vector2.down*5*Time.deltaTime);
			if(Input.GetKey(inputs.player1and3StateInput(changeFinger.state,2,"1")))
				aimPoint.transform.Translate(Vector2.left*5*Time.deltaTime);
			if(Input.GetKey(inputs.player1and3StateInput(changeFinger.state,3,"1")))
				aimPoint.transform.Translate(Vector2.right*5*Time.deltaTime);

			if (Input.GetKeyDown(inputs.player2and4StateInput(changeFinger.state,4,"2")))
            {
                soundManager.InitSoundeffect(3);
                aimFunction = !aimFunction;
                aimPoint.SetActive(false);
                leftGun.SetActive(false);
                if (handPoseModChange.r == 0)
                    handPoseModChange.r++;
                if (handPoseModChange.r == 2)
                    handPoseModChange.r--;
                if (handPoseModChange.r > 0 && handPoseModChange.r < 2)
                    handPoseModChange.r++;
				
                for (int i=0;i<players.Length;i++)//在內的玩家兩位
                {
					if (Vector2.Distance(players[i].transform.position, aimPoint.transform.position) <= 1.0f)
                    {
                        soundManager.InitSoundeffect(4);
                        if (changeFinger.state == 0)
                            uiManager.blueTeamScorePlus(5);
                        if (changeFinger.state == 1)
                            uiManager.redTeamScorePlus(5);
                        Debug.Log("74283954893270");//對內效果
                    }
                }
                
            }
        }
        
	}
    void handPoseSwitch()
    {
        checkPose.GetComponent<HandPoseCheck>().Init();
        checkPose = GetComponent<handPoseModChange>().getPose();
        checkPose.GetComponent<HandPoseCheck>().InitHandKuncleNodelist();
    }
    void checkPoint()
    {
        handPoseSwitch();
        if (checkPose.GetComponent<HandPoseCheck>().CheckPose()||Input.GetKeyDown(KeyCode.F1))
        {

            print(checkPose.name);
            Debug.Log("All ok");
            aimFunction = true;
        }
    }
}
