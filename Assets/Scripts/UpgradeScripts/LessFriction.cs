using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LessFriction : MonoBehaviour {


    private TextMeshProUGUI textMeshProUGUI;

    private Upgrade lessFrictionUpgrade;

    private float airDragMultiplier = 0.9f;

    //private GameControl gameControlScript;

    public void Awake()
    {

        //gameControlScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>();
        lessFrictionUpgrade = new Upgrade("Aerodynamics", 1200, 4, 1.2f);
        GameControl.upgrades[2] = lessFrictionUpgrade;

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
        if (GameControl.instance.totalPoint >= lessFrictionUpgrade.currentCost)
        {
            if (lessFrictionUpgrade.currentLevel < lessFrictionUpgrade.getMaxLevel())
            {
                GameControl.instance.setAirDrag(airDragMultiplier * GameControl.instance.startAirDrag);


                GameControl.instance.totalPoint = GameControl.instance.totalPoint - lessFrictionUpgrade.currentCost;
                GameControl.instance.TotalPointChanged();
                lessFrictionUpgrade.nextLevel();
                updateText();
                Debug.Log(lessFrictionUpgrade.currentLevel);
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
        textMeshProUGUI.SetText(lessFrictionUpgrade.getName() + "\nLevel:" + lessFrictionUpgrade.currentLevel + "\n" + lessFrictionUpgrade.currentCost.ToString("0.") + "$");

    }

}
