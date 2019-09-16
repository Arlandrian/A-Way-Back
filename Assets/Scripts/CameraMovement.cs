using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {


    Transform playerPosition;
    public Vector3 cameraDistance = new Vector3(0, 0, -10);
    public float cameraBaseLimit;
    // Use this for initialization
    void Start() {
        //DontDestroyOnLoad(this.gameObject);
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        BackgroundMovement bgManager = GameObject.FindGameObjectWithTag("BGManager").GetComponent<BackgroundMovement>();
        cameraBaseLimit = -bgManager.backgroundLayers[0].GetHeight() / 2f + Camera.main.orthographicSize;
        //Debug.Log(bgManager.backgroundLayers[0].GetHeight() + " Height");
        transform.position = playerPosition.position + cameraDistance;
        CameraAtStart();
        GameControl.instance.OnDie += CameraAtStart;
    }

    // Update is called once per frame
    void LateUpdate() {
        
        if (playerPosition.position.y > cameraBaseLimit) {
            transform.position = playerPosition.position + cameraDistance;
        }
        
    }

    private void CameraAtStart() {
        Vector3 pos = playerPosition.position + cameraDistance;
        pos.y = -3.45f;
        transform.position = pos;
    }

}