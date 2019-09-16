using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour {

    public Slider volumeSlider;
    public AudioSource audioSource;

	// Update is called once per frame
	void Update () {

        audioSource.volume = volumeSlider.value;


	}
}
