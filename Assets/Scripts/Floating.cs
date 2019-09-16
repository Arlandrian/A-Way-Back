using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour {
    Rigidbody2D rb;
    GameControl GC;
    // Use this for initialization
    void Start () {
        GC = GameControl.instance;
        rb = GetComponent<Rigidbody2D>();
	}
    float floatingAmount;
	// Update is called once per frame
	void Update () {
		if(GC.globalScrollSpeed < 5f) {
            floatingAmount = 0.2f;
        } else if( GC.globalScrollSpeed < 15f) {
            floatingAmount = 0.5f;
        } else {
            floatingAmount = 1f;
        }
        rb.position = Vector2.Lerp(rb.position, rb.position + (Vector2.up * floatingAmount * Mathf.Sin(Time.time*4f)), Time.deltaTime);
    }
}
