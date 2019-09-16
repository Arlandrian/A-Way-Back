using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeMenu : MonoBehaviour {
    TextMeshProUGUI totalPointText;
    // Use this for initialization
    void Start () {
        totalPointText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        totalPointText.text = "Point : " + GameControl.instance.totalPoint;
        
	}

    private void OnEnable() {
        UpdateTotalPointText();
    }

    public void UpdateTotalPointText() {
        if (isActiveAndEnabled && totalPointText != null) 
            totalPointText.text = "Point : " + GameControl.instance.totalPoint;
    }

    public void OnExitClick() {
        GameControl.instance.InGameUI.SetActive(true);
        GameControl.instance.UpgradeMenuUI.SetActive(false);
        GameControl.instance.gameOver = false;
        if (GameControl.instance.totalDistance > GameControl.instance.level2Distance) {
            BackgroundMovement bgMovement = GameObject.FindGameObjectWithTag("BGManager").GetComponent<BackgroundMovement>();
            bgMovement.ChangeLayerImage(0);
            GameControl.instance.totalDistance = 0f;
        }
    }


    public void OnSaveClick() {

    }
}
