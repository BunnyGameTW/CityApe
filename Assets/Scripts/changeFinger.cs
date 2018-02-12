using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeFinger : MonoBehaviour {
    [SerializeField] GameObject[] fingers=null;
	playerInput inputs;
    public int movingFingerIndex;
	public static int state=0;
	public GameObject pointer1;
	public GameObject pointer2;
	private GameObject nowPointer;
    public GameObject gun;
    GameObject controlFinger;
	gameManager1 GM;
    public SoundManager soundManager;
	// Use this for initialization
	void Start () {
		inputs = GetComponent<playerInput> ();
		GM = GetComponent<gameManager1> ();
		pointer1 = Instantiate (pointer1, transform.position, transform.rotation);
		pointer2 = Instantiate (pointer2, transform.position, transform.rotation);
		pointer1.SetActive (false);
		pointer2.SetActive (false);
        movingFingerIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
        print(state);
        if (UImanager.roundCount != 2)
        {
            if (GM.aimFunction == false)
            {
                controlFinger = ControlFinger();
                movingFinger(controlFinger);
                pointerChange(controlFinger);
            }

        }
        if(Input.GetKeyDown(KeyCode.F3))
        {
            gun.SetActive(true);
        }
    }


    GameObject ControlFinger()
    {
		if (Input.GetKeyDown(inputs.player2and4StateInput(state,2,"2")))
        {
            if (movingFingerIndex > 0)
            { 
                movingFingerIndex--;
                soundManager.InitSoundeffect(6);
            }
            return fingers[movingFingerIndex];
        }
		if (Input.GetKeyDown(inputs.player2and4StateInput(state,3,"2")))
        {
            if (movingFingerIndex < fingers.Length - 1)
            {
                movingFingerIndex++;
                soundManager.InitSoundeffect(6);
            }
            return fingers[movingFingerIndex];
        }
        return fingers[movingFingerIndex];
    }

    void movingFinger(GameObject nowFinger)//主要指頭動作部分
    {
        var firstKnuckles = nowFinger.GetComponentsInChildren<first>();
		if (Input.GetKey(inputs.player1and3StateInput(state,0,"1")))
            firstKnuckles[2].GetComponent<addForceToThirdKnuckles>().thirdKnucklesRotateLeft();
		if (Input.GetKey(inputs.player1and3StateInput(state,1,"1")))
            firstKnuckles[2].GetComponent<addForceToThirdKnuckles>().thirdKnucklesRotateRight();
		if (Input.GetKey(inputs.player1and3StateInput(state,2,"1")))
            firstKnuckles[1].GetComponent<addForceToThirdKnuckles>().thirdKnucklesRotateLeft();
		if (Input.GetKey(inputs.player1and3StateInput(state,3,"1")))
            firstKnuckles[1].GetComponent<addForceToThirdKnuckles>().thirdKnucklesRotateRight();
		if (Input.GetKey(inputs.player2and4StateInput(state,0,"2")))
            firstKnuckles[0].GetComponent<addForceToThirdKnuckles>().thirdKnucklesRotateLeft();
		if (Input.GetKey(inputs.player2and4StateInput(state,1,"2")))
            firstKnuckles[0].GetComponent<addForceToThirdKnuckles>().thirdKnucklesRotateRight();
    }
	void pointerChange(GameObject nowFinger){
		
		if (state == 0) {
			pointer1.SetActive (true);
			pointer2.SetActive (false);
			nowPointer = pointer1;
		}
		if (state == 1) {
			pointer1.SetActive (false);
			pointer2.SetActive (true);
			nowPointer = pointer2;
		}
		var a=nowFinger.GetComponentsInChildren<first>();
		nowPointer.transform.position = a [1].gameObject.transform.position+new Vector3(0,0.5f,0);
	}
}
