using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour {

    private Ball ball;
    private float startTime, endTime;
    private Vector3 dragStart, dragEnd;
    private float maxSpeed = 700;



	// Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DragStart() {
        //capture time and position of drag start
        dragStart = Input.mousePosition;
        startTime = Time.time;
    }

    public void DragEnd() {
        endTime = Time.time;
        dragEnd = Input.mousePosition;

        float dragDuration = endTime - startTime;
        // TODO implement maxSpeed constraint/clamp
        float launchSpeedX = (dragEnd.x - dragStart.x)/dragDuration;
        float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

        Vector3 launchVelocity = new Vector3(launchSpeedX * 0.05f, 0, launchSpeedZ * 0.7f);
        ball.Launch((launchVelocity));
        
    }

}
