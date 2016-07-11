using UnityEngine;
using System.Collections;

public class RoomCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player" && transform.GetChild(0).position.y > col.transform.position.y && transform.GetChild(0).position.y - col.transform.position.y > 0.51f)
			col.gameObject.transform.position += new Vector3 (0, transform.GetChild(0).position.y - col.transform.position.y, 0);
	}
}
