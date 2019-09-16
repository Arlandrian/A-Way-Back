using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightWeight : MonoBehaviour {

    private TextMeshProUGUI textMeshProUGUI;

    private Upgrade lightWeightUpgrade;

    private float forceMultiplier = 1.05f;

    public KiteMovement kiteMovementScript;


    public void Awake()
    {

        //gameControlScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>();
        lightWeightUpgrade = new Upgrade("LightWeight", 2200f, 6, 1.8f);
        GameControl.upgrades[3] = lightWeightUpgrade;

        textMeshProUGUI = this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        kiteMovementScript = GameObject.FindGameObjectWithTag("Player").GetComponent<KiteMovement>();
        updateText();
        //Initialize();
    }


    public void Upgrade()
    {
        if (GameControl.instance.totalPoint >= lightWeightUpgrade.currentCost)
        {
            if (lightWeightUpgrade.currentLevel < lightWeightUpgrade.getMaxLevel())
            {
                kiteMovementScript.setYForce(kiteMovementScript.getYForce() * forceMultiplier);
                GameControl.instance.totalPoint = GameControl.instance.totalPoint - lightWeightUpgrade.currentCost;
                GameControl.instance.TotalPointChanged();
                lightWeightUpgrade.nextLevel();
                updateText();
                Debug.Log("asdasd" + lightWeightUpgrade.currentLevel);
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
        textMeshProUGUI.SetText(lightWeightUpgrade.getName() + "\nLevel:" + lightWeightUpgrade.currentLevel + "\n" + lightWeightUpgrade.currentCost.ToString("0.") + "$");

    }


}
