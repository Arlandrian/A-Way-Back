﻿using UnityEngine;
using System.Collections;

public class RepeatingBackground : MonoBehaviour {

    private BoxCollider2D groundCollider;       //This stores a reference to the collider attached to the Ground.
    private float groundHorizontalLength;       //A float to store the x-axis length of the collider2D attached to the Ground GameObject.
    public Vector3 playerOffset = Vector3.left * 2.33f;
    //Awake is called before Start.
    private void Start() {
        groundCollider =GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
        //Debug.Log("SpriteLength"+GetComponent<SpriteRenderer>().bounds.size.x);
        //Debug.Log("groundHorizontalLength" + groundHorizontalLength);

    }

    //Update runs once per frame
    private void FixedUpdate() {
        //Check if the difference along the x axis between the main Camera and the position of the object this is attached to is greater than groundHorizontalLength.
        if (transform.position.x < -groundHorizontalLength) {
            //If true, this means this object is no longer visible and we can safely move it forward to be re-used.
            RepositionBackground(false);
        } else if (transform.position.x > groundHorizontalLength) {
            RepositionBackground(true);
        }
    }
    //Moves the object this script is attached to right in order to create our looping background effect.
    private void RepositionBackground(bool isLeft) {
        //This is how far to the right we will move our background object, in this case, twice its length. This will position it directly to the right of the currently visible background object.
        Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);
        if (!isLeft) {
            transform.position = (Vector2)transform.position + groundOffSet;

        } else {
            transform.position = (Vector2)transform.position - groundOffSet;
        }
        //Move this object from it's position offscreen, behind the player, to the new position off-camera in front of the player.
    }
}