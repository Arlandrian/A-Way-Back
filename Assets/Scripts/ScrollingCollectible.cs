using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingCollectible : MonoBehaviour {
    Transform player;
    float cameraOffsetX;
    Rigidbody2D rb2d;
    float speedMultiplier = 0.7f;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();
        cameraOffsetX = -Camera.main.orthographicSize * 1.7777777777f;//16/9 screen width
        GameControl.instance.OnTakeOff += SetScrollSpeed;
        GameControl.instance.OnDie += StopScroll;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (transform.position.x < cameraOffsetX) {

            Vector3 pos = player.position + Vector3.right * 2 + Vector3.up * Random.Range(-2f, 2f) + Vector3.right * Random.Range(3f, 10f);
            while(pos.y < -4) {
                pos.y = player.position.y + Random.Range(-2f, 2f);
            }
            transform.position = pos;

        }

        if (!GameControl.instance.IsDead()) {
            SetScrollSpeed();
        } else {
            StopScroll();
        }
        
    }

    void SetScrollSpeed() {
        rb2d.velocity = Vector3.left * GameControl.instance.globalScrollSpeed*speedMultiplier;
    } 
    void StopScroll() {
        rb2d.velocity = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            GameControl.instance.point += 50;
            Vector3 pos = player.position + Vector3.up * Random.Range(-2f, 2f) + Vector3.right * Random.Range(3f, 10f);
            transform.position = pos;

        }
    }

}
