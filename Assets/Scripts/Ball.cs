using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public float launchSpeed;
    public bool inPlay;
    public float testThrowSpeed;

    private AudioSource audioSource;
    private Rigidbody rigidBody;
    private Vector3 ballStartPos;
    
	// Use this for initialization
	void Start () {
        inPlay = false;
        ballStartPos = transform.position;
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
        
        audioSource = GetComponent<AudioSource>();

        //Launch(new Vector3(0, -50, launchSpeed));
	}

	public void Launch(Vector3 velocity) {
        if(!inPlay) {
            inPlay = true;
            rigidBody.useGravity = true;
            rigidBody.velocity = velocity;
            
        }
    }

    public void TestThrow() {
        Vector3 velocity = new Vector3(0, 0, testThrowSpeed);
        Launch(velocity);
    }

    public void Reset() {
        rigidBody.useGravity = false;
        inPlay = false;
        transform.position = ballStartPos;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;

    }
	// Update is called once per frame
	void Update () {
	    if(transform.position.y < 12.35) {
            audioSource.Play();
        }
        if ((transform.position.x > 60 || transform.position.x < -60) && transform.position.z < 1829) {
            Reset();
        }
    }//transform.position.y > 11.5 && 
    public void MoveStart(float xNudge) {
        if(!inPlay){
            float newPos = transform.position.x + xNudge;
            transform.position = new Vector3(Mathf.Clamp(newPos, -50, 50), transform.position.y, transform.position.z);
        }
        
        
    }

}
