using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiteRotation : MonoBehaviour {
    Rigidbody2D rb;
    GameControl gc;
    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        gc = GameControl.instance;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            
            float newZ = Map(gc.globalScrollSpeed, -30f, 30f, -60f, 30f);
            Debug.Log(newZ);
            transform.Rotate(Vector3.forward * newZ * Time.deltaTime);
        }
    }

    public static float Map(float OldValue, float OldMin, float OldMax, float NewMin, float NewMax) {

        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

        return (NewValue);
    }

}

