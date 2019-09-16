using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour {
    public GameObject starRef;
    //Transform player;
    public int totalCount;
    GameObject[] stars;
	// Use this for initialization
	void Start () {
        //DontDestroyOnLoad(this.gameObject);
        stars = new GameObject[totalCount];
        for (int i = 0; i < totalCount; i++) {
            Vector3 pos = Vector3.up * Random.Range(-2f, 5f) + Vector3.right* Random.Range(10f,25f);
            stars[i] = Instantiate(starRef, pos, Quaternion.identity);
            stars[i].transform.SetParent(this.transform);
        }
        GameControl.instance.OnDie += NewPosition;
	}

    private void NewPosition() {
        for (int i = 0; i < totalCount; i++) {
            Vector3 pos = Vector3.up * Random.Range(-2f, 5f) + Vector3.right * Random.Range(10f, 25f);
            stars[i].transform.position = pos;
        }
    }


}
