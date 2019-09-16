using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    public float point = 100f;
    public float speedMultiplier = 1f;
    private Rigidbody2D rb2d;

    Transform player;
    float cameraOffsetX;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();
        cameraOffsetX = -Camera.main.orthographicSize * 1.7777777777f;
        
    }

    private void Update() {
        if (!GameControl.instance.IsDead()) {
            SetScrollSpeed();
        } else {
            StopScroll();
        }


        if (transform.position.x < cameraOffsetX) {

            Vector3 pos = player.position + Vector3.right * 4*GameControl.instance.globalScrollSpeed + Vector3.up * Random.Range(-4f, 4f) + Vector3.right * Random.Range(7f, 15f);
            while (pos.y < -4) {
                pos.y = player.position.y + Random.Range(-4f, 4f);
            }
            transform.position = pos;

        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            GameControl.instance.point += point;
            GameControl.instance.globalScrollSpeed += 1f;
            Time.timeScale = 1;
            StartCoroutine(ZoomOut());
           
        }
    }
    
    private IEnumerator ZoomIn() {
        while(Camera.main.orthographicSize > 1.7) {
            yield return new WaitForSeconds(0.01f);
            Camera.main.orthographicSize -= 0.01f;
        }
        Camera.main.orthographicSize = 1.7f;

    }

    private IEnumerator ZoomOut() {
        while (Camera.main.orthographicSize < 2) {
            yield return new WaitForSeconds(0.01f);
            Camera.main.orthographicSize += 0.01f;
        }
        Camera.main.orthographicSize = 2f;
    }

    void SetScrollSpeed() {
        rb2d.velocity = Vector3.left * GameControl.instance.globalScrollSpeed * speedMultiplier;
    }
    void StopScroll() {
        rb2d.velocity = Vector3.zero;
    }

}
