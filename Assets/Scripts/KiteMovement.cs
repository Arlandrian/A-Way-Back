using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KiteMovement : MonoBehaviour
{
    GameControl GC;
    public float yForce = 1000f;
    public float yMovement, xMovement;
    public static float fuelDecreasingAmount = 0.1f;
    ParticleSystem pickupParticle;
    Rigidbody2D rigidBody;

    private float rot;

    [HideInInspector]
    public Text altitudeUI, speedUI, dstUI, pointUI;
    public Slider fuelSlider;

    public static float steering=0.8f;
    float cameraYOffset;
    // Use this for initialization
    void Start() {
        GC = GameControl.instance;
        rigidBody = GetComponent<Rigidbody2D>();
        pickupParticle = GetComponentInChildren<ParticleSystem>();
        cameraYOffset = Camera.main.orthographicSize;
        GC.OnDie += ResetPosition;
    }

    private void Update()
    {
        yMovement = Input.GetAxis("Horizontal");
        //xMovement = Input.GetAxis("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space) && !GC.IsDead()){
            if(!GC.isGameStarted)
                StartCoroutine(takeOff());
            
        }
        if (Input.GetKey(KeyCode.Alpha1)) {
            rigidBody.AddForce(Vector2.up * yForce);

        }
    }
    float nitroSpeedAmount = 0.08f;
    float airDragYEffect = 3f, airDragXEffect = 0.5f;

    public bool stalling = false;
    public bool stalled = false;
    public GameObject stallingWarning;
    public ParticleSystem nitroParticle;
    void FixedUpdate()
    {
        if (!GC.IsDead() && GC.isGameStarted)
        {
            
            if (GC.currentFuel > 0 && !stalled)
            {
                
                if (rigidBody.velocity.y < -4f && GC.globalScrollSpeed < 6f) {
                    stalling = true;
                    stallingWarning.SetActive(true);
                    if (GC.globalScrollSpeed < 3f && rigidBody.velocity.y < -5f ) {
                        stalled = true;
                    }
                    
                } else {
                    stalling = false;
                    stallingWarning.SetActive(false);
                }

                float zz = transform.eulerAngles.z;
                if (zz > 60 && zz < 300) {
                    if (zz - 60 < 120)
                        transform.eulerAngles = Vector3.forward * (59.8f);
                    else
                        transform.eulerAngles = Vector3.forward * (300.2f);
                } else {
                    transform.Rotate(-Vector3.forward * yMovement * steering);
                }
                float z;
                if (transform.eulerAngles.z > 300) {
                    z = (transform.eulerAngles.z - 360);
                } else {
                    z = transform.eulerAngles.z;
                }

                Vector2 targetVel = Vector2.up * Map(z, -60, 60, -6, 6);//10 a böl
                rigidBody.velocity = targetVel* airDragYEffect;

                GC.acceleration=-targetVel.y / 6f * airDragXEffect;

                //rigidBody.AddForce(new Vector2(0, yMovement * yForce * Time.fixedDeltaTime));
                if (yMovement != 0)
                {
                    GC.currentFuel -= fuelDecreasingAmount * Mathf.Abs(yMovement);
                }
                if (Input.GetKey(KeyCode.LeftShift)) {
                    nitroParticle.Play();
                    GC.globalScrollSpeed += nitroSpeedAmount;
                    GC.currentFuel -= fuelDecreasingAmount * 3f;
                } 
            }else if (stalled) {
                stallingWarning.SetActive(false);
                Debug.Log("Stalled!");
            }
            if(!Input.GetKey(KeyCode.LeftShift) && nitroParticle.isPlaying) {
                nitroParticle.Stop();
            }
            UIUpdate();
        } 

    }
    private void UIUpdate() {
        this.altitudeUI.text = "Altitude : " + (transform.position.y + 4.45).ToString("0.00");
        speedUI.text = "Speed : " + GC.globalScrollSpeed.ToString("0.00");
        dstUI.text = "Distance : " + GC.distance.ToString("0.00");
        pointUI.text = "Point : " + GC.point;
        fuelSlider.value = GC.currentFuel;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (!GC.IsDead() && GC.isGameStarted) {
            GC.Die();
            stalled = false;
            stallingWarning.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Collectible")) {
            pickupParticle.Play();
        }
    }

    private IEnumerator takeOff() {
        //  float temp = GameControl.instance.startSpeed;
        GC.globalScrollSpeed = -2f;
        rigidBody.AddForce( Vector3.up * 200);
        GC.gameOver = false;

        yield return new WaitForSeconds(0.7f);
        rigidBody.velocity = Vector2.zero;
        //this.transform.Translate(new Vector3(0f, transform.position.y, transform.position.z));
        GC.globalScrollSpeed = -3f;
        rigidBody.AddForce( Vector3.up * 220);
        yield return new WaitForSeconds(0.7f);
        GC.globalScrollSpeed = GC.startSpeed;

        GC.TakingOff(); //isGameStarted = true;

    }

    public void ResetPosition() {
        rigidBody.velocity = Vector2.zero;
        rigidBody.angularVelocity = 0;
        this.transform.position = new Vector3(0f, -4.359492f, 0f);
        this.transform.eulerAngles = new Vector3(0,0,0) ;
        
    }
    
    public static float Map(float OldValue, float OldMin, float OldMax, float NewMin, float NewMax) {

        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

        return (NewValue);

    }

    #region Getter&Setters
    public float getSteering() {
        return steering;
    }
    public void setSteering(float newValue) {
        steering = newValue;
    }
    public float getFuelDecreasingAmount() {
        return fuelDecreasingAmount;
    }
    public void setFuelDecreasingAmount(float newValue) {
        fuelDecreasingAmount = newValue;
    }
    public float getYForce() {
        return yForce;
    }
    public void setYForce(float newValue) {
        yForce = newValue;
    }
    #endregion

}