using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUpDown : MonoBehaviour {

    Vector3 vector3XY = new Vector3(1, 1, 0);
    public float startSize=4f;
    public float beatSpeed = 4f;
    public float beatAmount = 0.3f;
	// Update is called once per frame
	void Update () {

        transform.localScale=(startSize + Mathf.Abs(Mathf.Sin(Time.time* beatSpeed)))* vector3XY * beatAmount;
	}
}
