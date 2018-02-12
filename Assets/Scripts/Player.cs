using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Player : MonoBehaviour {

    public KeyCode interact, up, down, left, right;
    public float speed;
    public float boxSpeedX, boxSpeedY;
    public bool canDragOther;
    Vector3 lastPos;
   public  LayerMask test;
    public Vector3 faceTo;
    Sprite _sprite;
    Animator _animator;
    playerInput inputs;
    public SoundManager soundManager;
    // Use this for initialization
    void Start () {
        inputs = GetComponent<playerInput>();
        canDragOther = true;
       // _sprite = GetComponentInChildren<Sprite>();
        _animator = GetComponent<Animator>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.name == "Player (1)")
        {
            up = inputs.player1and3StateInput(changeFinger.state, 0, "3");
            down = inputs.player1and3StateInput(changeFinger.state, 1, "3");
            left = inputs.player1and3StateInput(changeFinger.state, 2, "3");
            right = inputs.player1and3StateInput(changeFinger.state, 3, "3");
            interact = inputs.player1and3StateInput(changeFinger.state, 4, "3");
        }
        if (gameObject.name == "Player (2)")
        {
            up = inputs.player2and4StateInput(changeFinger.state, 0, "4");
            down = inputs.player2and4StateInput(changeFinger.state, 1, "4");
            left = inputs.player2and4StateInput(changeFinger.state, 2, "4");
            right = inputs.player2and4StateInput(changeFinger.state, 3, "4");
            interact = inputs.player2and4StateInput(changeFinger.state, 4, "4");
        }
        move();
       raycastBox();
    }
    void raycastBox()
    {
        RaycastHit2D o = Physics2D.Linecast(transform.position, transform.position + faceTo, test);
        if (o)
        {
            Debug.DrawLine(transform.position, o.collider.transform.position, Color.red, 1.0f, true);
            if (Input.GetKey(interact))
            {
            
                o.collider.gameObject.GetComponent<Box>().followPlayer(boxSpeedX, boxSpeedY);
               o.collider.GetComponent<Box>().checkName(o.collider.gameObject.name);
                Debug.Log(o.collider.gameObject.name);
                canDragOther = false;           
            }
         
        }
        if (Input.GetKeyUp(interact)) {
            canDragOther = true;
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("box").Length; i++)
            {
                FindObjectsOfType<Box>()[i].GetComponent<Box>().setStatic();
              
            }
        }
    }
    void move()
    {
        
        if (Input.GetKey(up))
        {
            soundManager.InitSoundeffect(5);
            lastPos = transform.position;
            this.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            boxSpeedY = speed;
            boxSpeedX = 0;
            if(canDragOther) faceTo = Vector3.up;
            transform.GetChild(0).rotation = Quaternion.Euler(0f, 0f, 180.0f);
        }
        else if (Input.GetKey(down))
        {
            lastPos = transform.position;
            soundManager.InitSoundeffect(5);
            this.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
            boxSpeedY = -speed;
            boxSpeedX = 0;
            if (canDragOther) faceTo = -Vector3.up;
            transform.GetChild(0).rotation = Quaternion.Euler(0f, 0f, 0.0f);

        }
        else if (Input.GetKey(left))
        {
            lastPos = transform.position;
            soundManager.InitSoundeffect(5);
            this.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            boxSpeedX = -speed;
            boxSpeedY = 0;
            if (canDragOther) faceTo = -Vector3.right;
            transform.GetChild(0).rotation = Quaternion.Euler(0f, 0f, 270.0f);

        }
        else if (Input.GetKey(right))
        {
            lastPos = transform.position;
            soundManager.InitSoundeffect(5);
            this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            boxSpeedX = speed;
            boxSpeedY = 0;
            if (canDragOther) faceTo = Vector3.right;
            transform.GetChild(0).rotation = Quaternion.Euler(0f, 0f, 90.0f);

        }
        else boxSpeedX = boxSpeedY = 0;
    }
    public void LastPos() {
        transform.position = lastPos;
    }
   
}
