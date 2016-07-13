using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

    public float standingThreshold;

    private Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        IsStanding();
	}

    public bool IsStanding() {
        return Vector3.Angle(Vector3.up, transform.forward) < standingThreshold;
    }

    public void Raise(float dist) {
        transform.rotation = Quaternion.Euler(new Vector3(270, 0, 0));
        transform.Translate(new Vector3(0, dist, 0), Space.World);
        rigidBody.useGravity = false;
    }

    public void Lower(float dist) {
        transform.rotation = Quaternion.Euler(new Vector3(270, 0, 0));
        transform.Translate(new Vector3(0, -dist, 0), Space.World);
        rigidBody.useGravity = true;
    }

}
