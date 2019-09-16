using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KiteShaking : MonoBehaviour {

    float speedX = 2.0f; //how fast it shakes
    float amountX = 0.4f; //how much it shakes

    float speedY = 1f; //how fast it shakes
    float amountY = 0.4f; //how much it shakes

    float speedZ = 3.0f; //how fast it shakes
    float amountZ = 0.1f; //how much it shakes

    float noise;
    Rigidbody2D rb;
    private void Start() {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate () {

        if(!GameControl.instance.gameOver )
            transform.Rotate(new Vector3(/*Mathf.Sin(Time.time * speedX) * amountX*/0, 0/*Mathf.Sin(Time.time * speedY) * amountY*/,Mathf.Sin(Time.time *speedZ) * amountZ));
    }
}
