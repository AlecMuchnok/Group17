using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private const float playerSpeed = 5.0f;

	//Checked when player tries to jump
	private bool jumping;

	//Angle player is facing
	private float rotationAngle;

	void Awake() {
		Physics.gravity = new Vector3 (0, -1f, 0);
	}
	
	// Use this for initialization
	void Start () {
		jumping = false;
	}

	// Update is called once per frame
	void Update () {
		//Set rotation to be straight up
		transform.eulerAngles = new Vector3(0, rotationAngle , 0);

		//Player Movement
		transform.Translate (Vector3.right * Input.GetAxis ("Horizontal")*playerSpeed*Time.deltaTime);
		transform.Translate (Vector3.forward * Input.GetAxis ("Vertical")*playerSpeed*Time.deltaTime);

		//Rotation
		//Left
		if (Input.GetKeyDown (KeyCode.Q))
			rotationAngle -= 90;

		//Right
		if (Input.GetKeyDown (KeyCode.E))
			rotationAngle += 90;

		//Jump
		if (Input.GetKeyDown (KeyCode.Space) && !jumping) {
			GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 100f, 0));
			jumping = true;
		}
	}

	void OnCollisionEnter(Collision col) {
		//Player can jump if it touched floor since last jumping
		if (col.gameObject.name == "Floor")
			jumping = false;
	}
}
