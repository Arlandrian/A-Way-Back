using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BetterSteering : MonoBehaviour {

    private TextMeshProUGUI textMeshProUGUI;

    private Upgrade betterSteeringUpgrade;

    private float steeringIncrease = 0.1f;

    public KiteMovement kiteMovementScript;


    public void Awake()
    {

        //gameControlScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>();
        betterSteeringUpgrade = new Upgrade("BetterSteering", 1600f, 4, 1.6f);
        GameControl.upgrades[0] = betterSteeringUpgrade;
        textMeshProUGUI = this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        kiteMovementScript = GameObject.FindGameObjectWithTag("Player").GetComponent<KiteMovement>();
        updateText();
        //Initialize();
    }


    public void Upgrade()
    {
        if (GameControl.instance.totalPoint >= betterSteeringUpgrade.currentCost)
        {
            if (betterSteeringUpgrade.currentLevel < betterSteeringUpgrade.getMaxLevel())
            {
                kiteMovementScript.setSteering(kiteMovementScript.getSteering() + steeringIncrease);
                GameControl.instance.totalPoint = GameControl.instance.totalPoint - betterSteeringUpgrade.currentCost;
                GameControl.instance.TotalPointChanged();
                betterSteeringUpgrade.nextLevel();
                updateText();
                Debug.Log("asdasd" + betterSteeringUpgrade.currentLevel);
            }
            else
            {
                Debug.Log("Sinira ulasildi");
            }

        }
        else
        {
            Debug.Log("Yeterli puan yok");

        }

    }

    private void updateText()
    {
        textMeshProUGUI.SetText(betterSteeringUpgrade.getName() + "\nLevel:" + betterSteeringUpgrade.currentLevel + "\n" + betterSteeringUpgrade.currentCost.ToString("0.") + "$");

    }



}
