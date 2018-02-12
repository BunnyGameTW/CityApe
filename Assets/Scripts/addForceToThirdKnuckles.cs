using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addForceToThirdKnuckles : MonoBehaviour {//施力於指尖關節

	// Use this for initialization

    public void thirdKnucklesRotateLeft()
    {
        transform.Rotate(new Vector3(0, 0, 2f));
    }

    public void thirdKnucklesRotateRight()
    {
        transform.Rotate(new Vector3(0, 0, -2f));
    }
    /*public void horizontalLine()
    {
        Vector2 distance= zeroPoint.transform.position - transform.position;
        var newVector= Vector3.Cross(distance, Vector3.forward);
        newVector.Normalize();
        var p1 = transform.position - newVector*2f;//順時針
        var p2 = transform.position + newVector*2f;//逆時針
        down = p2;
        up = p1;
        Debug.DrawLine(p1, transform.position, Color.red);
    }*/
}
