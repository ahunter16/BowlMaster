using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    private List<int> bowls;
    private Ball ball;
    private PinSetter pinSetter;

	// Use this for initialization
	void Start () {
        bowls = new List<int>();
        ball = FindObjectOfType<Ball>();
        pinSetter = FindObjectOfType<PinSetter>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Bowl(int pinFall) {
        bowls.Add(pinFall);
        ActionMaster.Action nextAction = ActionMaster.NextAction(bowls);
        pinSetter.PerformAction(nextAction);
        ball.Reset();
    }

    


}
