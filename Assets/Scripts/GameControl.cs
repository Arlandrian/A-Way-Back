using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameControl : MonoBehaviour {
    public static GameControl instance;

    public event System.Action OnDie;
    public event System.Action OnTakeOff;
    public static Upgrade[] upgrades = new Upgrade[5];

       
    
    public bool gameOver = false;
    public float startSpeed;
    public float globalScrollSpeed;

    public float maxFuel;
    public float currentFuel;
    public bool isGameStarted=false;

    public float point;
    public float totalPoint;

    public float distance;
    public float totalDistance;

    public float startAirDrag;
    public float airDrag;

    
    public float acceleration=0;

    public GameObject InGameUI;
    public GameObject UpgradeMenuUI;

    void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        //DontDestroyOnLoad(this.gameObject);
    }
    private void Start() {
        
        InGameUI.SetActive(true);
        UpgradeMenuUI.SetActive(false);

        LoadProgress();
        TotalPointChanged();

        globalScrollSpeed = 0;
        currentFuel = maxFuel;
        distance = 0;
        airDrag = startAirDrag;
        totalDistance = 0;
    }
    private void OnApplicationQuit() {

        SaveProgress();
    }

    void Update() {

        //If the game is over and the player has pressed some input...
        if (gameOver && Input.GetKeyDown(KeyCode.R)) {
            //...reload the current scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            gameOver = false;
        }
        if (!gameOver) {

            distance += globalScrollSpeed * Time.deltaTime;
        }
    }

    private void FixedUpdate() {
        if (!gameOver && isGameStarted) {
            if (globalScrollSpeed >= 0) {
                globalScrollSpeed += (acceleration - airDrag);
            } else {
                globalScrollSpeed = 0;
            }
        } else {
            globalScrollSpeed = 0;
        }
        
    }
    public float level2Distance = 5000f;
    public void Die() {
        StartCoroutine(DieCoroutine());
    }

    private IEnumerator DieCoroutine() {
        gameOver = true;
        globalScrollSpeed = 0f;

        totalPoint += point;
        totalDistance += distance;
        yield return new WaitForSeconds(2.5f);
        distance = 0;
        if (isGameStarted) {
            InGameUI.SetActive(false);
            UpgradeMenuUI.SetActive(true);
        }
        isGameStarted = false;

        point = 0;
        OnDie();
    }
    public bool IsDead() {
        return gameOver;
    }
    public void TakingOff() {
        //InGameUI.SetActive(true);
        globalScrollSpeed = startSpeed;
        currentFuel = maxFuel;
        isGameStarted = true;
        gameOver = false;
        OnTakeOff();
    }

    #region Getter&Setter
    public void setScrollSpeed(float globalScrollSpeed)
    {
        this.globalScrollSpeed = globalScrollSpeed;
    }

    public void setStartSpeed(float startSpeed)
    {
        this.startSpeed = startSpeed;
    }

    public void setAirDrag(float startAirDrag)
    {
        this.startAirDrag = startAirDrag;
    }
    #endregion

    public void TotalPointChanged() {
        if (UpgradeMenuUI.activeInHierarchy) {
            UpgradeMenu menu = UpgradeMenuUI.GetComponent<UpgradeMenu>();
            if (menu != null) {
                menu.UpdateTotalPointText();
            }
        }
        
    }

    public void SaveProgress() {
        string text = totalPoint.ToString()+" "+totalDistance.ToString();
        HandleTextFile.WriteString(text);
    }

    void LoadProgress() {
        string text = HandleTextFile.ReadString();
        string[] word = text.Split(' ');
        totalPoint = float.Parse(word[0]);
        totalDistance = float.Parse(word[1]);
        
    }

    void UpdateProgress() {
        //startSpeed = upgrades[4].
    }
}