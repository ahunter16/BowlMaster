using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PinCounter : MonoBehaviour {
    public Text standingDisplay;
    public float settleTime = 3f;

    private GameManager gameManager;
    private bool ballOutOfPlay = false;
    private int lastSettledCount = 10;
    private int lastStandingCount = -1;
    private float lastChangeTime;
    

    
	// Use this for initialization
	void Start () {
        
        CountStanding();
        gameManager = FindObjectOfType<GameManager>();
        
        
	}
	
	// Update is called once per frame
	void Update () {
        standingDisplay.text = CountStanding().ToString();
        print("ball out of play: " + ballOutOfPlay);
        if(ballOutOfPlay) {
            UpdateStandingCountAndSettle();
            standingDisplay.color = Color.red;
        }
    }
    public void Reset() {
        lastSettledCount = 10;
    }

    void OnTriggerExit(Collider ball) {
        if(ball.gameObject.GetComponent<Ball>()) {
            ballOutOfPlay = true;

        }
    }

    void UpdateStandingCountAndSettle() {
        int currentStanding = CountStanding();

        if(currentStanding != lastStandingCount) {
            lastStandingCount = currentStanding;
            lastChangeTime = Time.time;
        }
        else if((Time.time - lastChangeTime) >= settleTime) {
            PinsHaveSettled();

        }
        return;

    }

    void PinsHaveSettled() {

        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;
        gameManager.Bowl(pinFall);
        lastStandingCount = -1;
        ballOutOfPlay = false;
        standingDisplay.color = Color.green;

    }

    int CountStanding() {
        int standing = 0;

        foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            if(pin.IsStanding()) {
                standing++;
            }
        }
        return standing;
    }

    public void SetBallOutOfPlay() {
        ballOutOfPlay = true;
    }



}
