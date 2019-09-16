using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {
    private Rigidbody2D rb2d;
    private BackgroundMovement bgManager;
    private float scrollSpeed;
    public float scrollRatio;

    public int row;
    // Use this for initialization
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        scrollSpeed = GameControl.instance.globalScrollSpeed;
        bgManager = GameObject.FindGameObjectWithTag("BGManager").GetComponent<BackgroundMovement>();
        rb2d.velocity = new Vector2(-scrollSpeed*scrollRatio, 0);
    }

    void Update() {
        if (GameControl.instance.gameOver) {
            rb2d.velocity = Vector2.zero;
        } else {
            scrollSpeed = GameControl.instance.globalScrollSpeed;
            scrollRatio = bgManager.backgroundLayers[row].scrollSpeedRatio;
            rb2d.velocity = new Vector2(-scrollSpeed * scrollRatio, 0);
        }

    }

}
