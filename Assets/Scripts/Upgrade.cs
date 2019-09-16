using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade {

    private string name;
    private float startingCost;
    private int maxLevel;
    private float costUpMultiplier = 1.2f;

    public float currentCost;
    public int currentLevel;

    public Upgrade(string name, float startingCost, int maxLevel, float costUpMultiplier)
    {
        this.name = name;
        this.startingCost = startingCost;
        this.maxLevel = maxLevel;
        this.costUpMultiplier = costUpMultiplier;

        this.currentLevel = 1;
        this.currentCost = startingCost;
    }

    public void nextLevel()
    {
        //gerekirse level max controlü yap
        //currentLevel = currentLevel++; Burda neden hata var?bunun çalışması lazım
        currentLevel++;
        currentCost = currentCost * costUpMultiplier;

    }

    public string getName()
    {
        return name;
    }

    public int getMaxLevel() {
        return this.maxLevel;
    }



}
