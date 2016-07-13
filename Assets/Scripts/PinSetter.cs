using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PinSetter : MonoBehaviour {
    
    public Text standingDisplay;
    public float settleTime = 3f;
    public float distanceToRaise = 40f;
    public GameObject pinSet;

    private bool ballOutOfPlay = false;
    private int lastSettledCount = 10;
    private int lastStandingCount = -1;
    private float lastChangeTime;

    private ActionMaster actionMaster; //needs to be here as we only want one instance

    private Animator animator;
    private Ball ball;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        actionMaster = new ActionMaster();
        CountStanding();
        ball = FindObjectOfType<Ball>();
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

    public void SetBallOutOfPlay() {
        ballOutOfPlay = true;
    }

    public void RaisePins() {
        
        foreach(Pin pin in FindObjectsOfType<Pin>()) {
            if(pin.IsStanding()) {
                pin.Raise(distanceToRaise);
                
            }
        }
        
    }

    public void LowerPins() {
        
        foreach(Pin pin in FindObjectsOfType<Pin>()) {
            if(pin.IsStanding()) {
                pin.Lower(distanceToRaise);

            }
        }
        
    }

    public void RenewPins() {
        
        GameObject newPins = Instantiate(pinSet, new Vector3(0, 60, 1829), Quaternion.identity) as GameObject;

    }

    void UpdateStandingCountAndSettle() {
        int currentStanding = CountStanding();

        if(currentStanding != lastStandingCount) {
            lastStandingCount = currentStanding;
            lastChangeTime = Time.time;
            return;
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
        print(pinFall);

        ActionMaster.Action action = actionMaster.Bowl(pinFall);
        print(action);
        if (action == ActionMaster.Action.Reset || action == ActionMaster.Action.EndTurn) {
            Reset();
            animator.SetTrigger("resetTrigger");
        }
        else if(action == ActionMaster.Action.Tidy) {
            animator.SetTrigger("tidyTrigger"); 
        }


        ball.Reset();
        lastStandingCount = -1;
        ballOutOfPlay = false;
        standingDisplay.color = Color.green;
        
    }

    public void Reset() {
        lastSettledCount = 10;
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

    void OnTriggerExit(Collider collider) {
        GameObject thingLeft = collider.gameObject;

        if(thingLeft.GetComponent<Pin>()) {
            
            Destroy(thingLeft);
        }

    }

}
