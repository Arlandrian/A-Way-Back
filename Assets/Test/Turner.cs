using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turner : MonoBehaviour {

    const float radius = 4;
    float steering = 0.4f;
    Vector3 targetPosition;
    Vector3 move = new Vector3();
    public float force;
    Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        transform.position = targetPosition + Vector3.right * radius;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {/*
        if (Input.GetKey(KeyCode.A)) {
            if(transform.position.y < radius)
            transform.position += Vector3.up*steering;
        }else if (Input.GetKey(KeyCode.D)) {
            if (transform.position.y > -radius)
                transform.position += Vector3.down * steering;
        }*/
        
        rb.AddForce(Input.GetAxis("Vertical")*Vector3.up*force);
    }



}
