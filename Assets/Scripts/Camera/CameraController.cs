using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	//Mouse
	private const float sensitivity = 15f;
	private const float maxAngle = 45f; //Both up and down
	private Quaternion originalRotation;
	private float rotation;

	// Use this for initialization
	void Start () {
		originalRotation = transform.localRotation;
		rotation = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		//Get angle
		rotation += Input.GetAxis("Mouse Y") * sensitivity;
		rotation = Mathf.Clamp (rotation, -maxAngle, maxAngle);

		//Rotate Camera
		transform.localRotation = Quaternion.AngleAxis(-rotation, Vector3.right);

		//Move camera
		//transform.localPosition = new Vector3(1, -2 * Mathf.Sin(rotation), -2 * Mathf.Cos(rotation));
	}
}
