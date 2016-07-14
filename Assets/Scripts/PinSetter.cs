using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PinSetter : MonoBehaviour {
    
    
    
    public float distanceToRaise = 40f;
    public GameObject pinSet;



    private ActionMaster actionMaster; //needs to be here as we only want one instance
    private PinCounter pinCounter;

    private Animator animator;


    // Use this for initialization
    void Start () {
        pinCounter = FindObjectOfType<PinCounter>();
        animator = GetComponent<Animator>();
        actionMaster = new ActionMaster();

	}
	
	// Update is called once per frame
	void Update () {

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

    public void PerformAction(ActionMaster.Action action) {

        if(action == ActionMaster.Action.Reset || action == ActionMaster.Action.EndTurn) {
            pinCounter.Reset();
            animator.SetTrigger("resetTrigger");
        }
        else if(action == ActionMaster.Action.Tidy) {
            animator.SetTrigger("tidyTrigger");
        }
    }
   
    void OnTriggerExit(Collider collider) {
        GameObject thingLeft = collider.gameObject;

        if(thingLeft.GetComponent<Pin>()) {
            
            Destroy(thingLeft);
        }

    }


}
