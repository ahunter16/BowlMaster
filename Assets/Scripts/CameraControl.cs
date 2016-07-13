using UnityEngine;
using System.Collections;

public class CameraControl: MonoBehaviour {

    public Ball ball;
    public int cameraDistance;
	// Use this for initialization
	void Start () {
        //ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        if(ball.transform.position.z < 1829) {
            Vector3 newPos = transform.position;
            newPos.z = ball.transform.position.z - cameraDistance;
            transform.position = newPos;
        }
	}
}
