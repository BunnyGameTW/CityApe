using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
	public LayerMask hit;
	//bool yes;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D a = Physics2D.Linecast (transform.position, transform.position + new Vector3 (1, 0, 0), hit);
		print (a.collider.transform.position);
		Debug.DrawLine (transform.position, transform.position + new Vector3 (1, 0, 0), Color.red);
        //print(yes);
        Debug.DrawLine(a.collider.transform.position ,a.collider.transform.position + new Vector3(1, 0, 0), Color.blue);

			
	}
}
