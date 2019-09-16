using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour {
    AudioSource SMIn, SMOut;
    private void Start() {
        SMIn = GetComponent<AudioSource>();
        SMOut = transform.GetChild(0).GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Time.timeScale = 0.5f;
            SMIn.Play();
            SMOut.Stop();
            StartCoroutine(ZoomIn());
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Time.timeScale = 1f;
            SMIn.Stop();
            SMOut.Play();
            StartCoroutine(ZoomOut());
        }
    }

    private IEnumerator ZoomIn() {
        while (Camera.main.orthographicSize > 1.7) {
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

}
