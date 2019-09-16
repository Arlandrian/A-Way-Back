using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedUp : MonoBehaviour {

    private TextMeshProUGUI textMeshProUGUI;

    private Upgrade speedUpUpgrade;

    private float speedMultiplier = 1.2f;

    //private GameControl gameControlScript;

    public void Awake() {
        
        //gameControlScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>();
        speedUpUpgrade = new Upgrade("SpeedUp", 2000f, 5, 1.2f);
        GameControl.upgrades[4] = speedUpUpgrade;

        textMeshProUGUI = this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        updateText();
        //Initialize();
    }

    /*
    public void Initialize()// public void Start ?????????
    {
        speedUpUpgrade = new Upgrade("SpeedUp", 2000f, 5, 1.2f);
        textMeshPro = GetComponent<TextMeshPro>();
        textMeshPro.SetText(speedUpUpgrade.name);
    }
    */

    public void Upgrade()
    {
        if(GameControl.instance.totalPoint >= speedUpUpgrade.currentCost) {
            if (speedUpUpgrade.currentLevel < speedUpUpgrade.getMaxLevel()) {
                GameControl.instance.setStartSpeed(speedMultiplier * GameControl.instance.startSpeed);
                GameControl.instance.totalPoint = GameControl.instance.totalPoint - speedUpUpgrade.currentCost;
                GameControl.instance.TotalPointChanged();
                speedUpUpgrade.nextLevel();
                updateText();
                Debug.Log(speedUpUpgrade.currentLevel);
            } else {
                Debug.Log("Sinira ulasildi");
            }
            
        } else {
            Debug.Log("Yeterli puan yok");

        }
    }

    public void JustUpgrade() {
        GameControl.instance.setStartSpeed(speedMultiplier * GameControl.instance.startSpeed);
        speedUpUpgrade.nextLevel();
        
    }




    private void updateText() {
        textMeshProUGUI.SetText(speedUpUpgrade.getName() + "\nLevel:" + speedUpUpgrade.currentLevel + "\n" + speedUpUpgrade.currentCost.ToString("0.") + "$");

    }




}
