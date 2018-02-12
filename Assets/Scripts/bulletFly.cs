using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletFly : MonoBehaviour {

    public float speed;

	void Update () {
        transform.position = new Vector2(transform.position.x - speed, transform.position.y);
        if (transform.position.x < -10.0f)
        {
            gameObject.SetActive(false);
        }
	}
}
