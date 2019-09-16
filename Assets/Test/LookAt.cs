using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAt : MonoBehaviour {
    public GameObject target;
    public GameObject face;

    Rigidbody2D rigidBody;

    public Text stallingWarning;

    //float steering = 2f;
    float gravityRot = 0.5f;
    public bool stalling = false;
    float stallingAngle = 30f;
    public bool stalled = false;
    float stalledAngle = 60f;

    float gravConst;
    // Use this for initialization
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        gravConst = rigidBody.gravityScale * 9.8f;

    }
    public float yMovement;
    float yForce = 5f;
    float ySpeedLimit = 15f;
    float steering = 1f;
    // Update is called once per frame
    void Update() {
        yMovement = Input.GetAxis("Horizontal");
        
    }

    private void FixedUpdate() {/*
        if (yMovement != 0 && rb.velocity.y < ySpeedLimit) {

            rb.AddForce((gravConst - yMovement * yForce) * Vector2.up);
        }*/
        
        if(rigidBody.velocity.y < -2) {
            stalling = true;
            if(rigidBody.velocity.y < -6) {
                stalled = true;
            }
        } else {
            stalling = false;
        }
        
        float zz = transform.eulerAngles.z;
        if (zz > 60 && zz < 300) {
            if (zz - 60 < 120)
                transform.eulerAngles = Vector3.forward * (59.8f);
            else
                transform.eulerAngles = Vector3.forward * (300.2f);
        } else {
            transform.Rotate(-Vector3.forward * yMovement * steering);
        }
        float z;
        if (transform.eulerAngles.z > 300) {
            z = (transform.eulerAngles.z - 360);
        } else {
            z = transform.eulerAngles.z;
        }

        Vector2 targetVel = Vector2.up * Map(z, -60, 60, -6, 6);//10 a böl
        rigidBody.velocity = targetVel;
        
        

    }



    void LookAtTarget() {
        Vector3 dir = target.transform.position - face.transform.position;
        dir.Normalize();
        float targetRotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + transform.rotation.z;
        transform.eulerAngles = Vector3.forward * targetRotation;
    }
    public static float Map(float OldValue, float OldMin, float OldMax, float NewMin, float NewMax) {

        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

        return (NewValue);

    }


    
}
 