using UnityEngine;
using System.Collections;

public class GutterBall : MonoBehaviour {

    private PinSetter pinSetter;
	// Use this for initialization
	void Start () {
        pinSetter = FindObjectOfType<PinSetter>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit(Collider ball) {
        if(ball.gameObject.GetComponent<Ball>()) {
            pinSetter.SetBallOutOfPlay();
            
        }
    }
}
