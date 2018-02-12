using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {
    bool inReset= false;
    Rigidbody2D rig;
    Player player;
    public GameObject pos;
   public  bool canMove;
    Vector3 lastPos;
   public  Vector3 faceTo;
    // Use this for initialization
    void Start () {
        rig = GetComponent<Rigidbody2D>();   
        canMove = true;
        lastPos = transform.position;
        rig.bodyType = RigidbodyType2D.Static;
    }
	
	// Update is called once per frame
	void Update () {
        if (UImanager.roundCount == 1&&inReset==false)
        {//第二回合重置
            transform.position = pos.transform.position;
            inReset = true;
        }

    }
    public void checkName(string name)
    {
        if(name == this.gameObject.name)
        {
            //can Be Drag
            rig.bodyType = RigidbodyType2D.Dynamic;
        }
        else rig.bodyType = RigidbodyType2D.Static;
        Debug.Log("888");

    }
  public void setStatic()
    {

        rig.bodyType = RigidbodyType2D.Static;
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.tag == "box")
    //    {
    //        transform.position = lastPos;
    //        canMove = false;
           
    //    }
    //    //if (collision.tag == "Player")
    //    //{
    //    //    player = collision.GetComponent<Player>();
    //    //    player.canMove = false;
    //    //    Debug.Log(collision.gameObject.name);
    //    //    player.LastPos();
    //    //}

    //}
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "box")
    //    {
    //        transform.position = lastPos;
    //        canMove = false;
          
    //    }
        
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "box")
    //    {
    //        canMove = true;
    //    }
    //    //if (collision.tag == "Player")
    //    //{
            
    //    //    player.canMove = true;
           
    //    //}
    //}
    public void followPlayer(float speedX, float speedY)
    {
     //   lastPos = transform.position;
        Debug.Log(speedX +","+ speedY);
       
      transform.position += new Vector3(speedX * Time.deltaTime,speedY * Time.deltaTime, 0);
    }
}
