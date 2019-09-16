using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FuelUsage : MonoBehaviour {

    private TextMeshProUGUI textMeshProUGUI;

    private Upgrade fuelUsageUpgrade;

    private float fuelUsageMultiplier = 0.8f;

    public KiteMovement kiteMovementScript;


    public void Awake()
    {

        //gameControlScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>();
        fuelUsageUpgrade = new Upgrade("FuelUsage", 1000f, 6, 1.4f);
        GameControl.upgrades[1] = fuelUsageUpgrade;

        textMeshProUGUI = this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        kiteMovementScript = GameObject.FindGameObjectWithTag("Player").GetComponent<KiteMovement>();
        updateText();
        //Initialize();
    }


    public void Upgrade()
    {
        if (GameControl.instance.totalPoint >= fuelUsageUpgrade.currentCost)
        {
            if (fuelUsageUpgrade.currentLevel < fuelUsageUpgrade.getMaxLevel())
            {
                kiteMovementScript.setFuelDecreasingAmount(kiteMovementScript.getFuelDecreasingAmount() * fuelUsageMultiplier);
                GameControl.instance.totalPoint = GameControl.instance.totalPoint - fuelUsageUpgrade.currentCost;
                GameControl.instance.TotalPointChanged();
                fuelUsageUpgrade.nextLevel();
                updateText();
                Debug.Log("asdasd"+fuelUsageUpgrade.currentLevel);
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
        textMeshProUGUI.SetText(fuelUsageUpgrade.getName() + "\nLevel:" + fuelUsageUpgrade.currentLevel + "\n" + fuelUsageUpgrade.currentCost.ToString("0.") + "$");

    }



}
