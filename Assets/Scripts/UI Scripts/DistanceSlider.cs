using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DistanceSlider : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Func();
    }

    private void OnEnable() {
        Func(); 
    }

    private void Func() {
        Slider slider = GetComponent<Slider>();
        slider.maxValue = GameControl.instance.level2Distance;
        slider.minValue = 0;
        slider.direction = Slider.Direction.RightToLeft;
        int remainingDst = (int)(GameControl.instance.level2Distance - GameControl.instance.totalDistance);

        slider.value = remainingDst;
        if (remainingDst > 0) {
            GetComponentInChildren<Text>().text = "Remained Distance : " + remainingDst.ToString();
        } else {
            GetComponentInChildren<Text>().text = "Reached to the End!!!";
        }
    }

}
