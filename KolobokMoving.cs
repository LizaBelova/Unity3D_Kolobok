using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KolobokMoving : MonoBehaviour {
	public Text bill;
	int count = 0;
	private Rigidbody body;
	// Use this for initialization
	void Start () {
		//Rigidbody body = GetComponent<Rigidbody> ();
		body = GetComponent<Rigidbody>();
	}
	// Update is called once per frame
	void FixedUpdate(){
		#if (UNITY_EDITOR || UNITY_STANDALONE)
		float hor = Input.GetAxis("Horizontal");
		float ver = Input.GetAxis ("Vertical");
		Vector3 VC = new Vector3 (hor, 0, ver);
		body.AddForce (VC * 3);
		#elif (UNITY_ANDROID || UNITY_IOS)
		float hor = -Input.acceleration.y;
		float ver = Input.acceleration.x;
		Vector3 VC = new Vector3 (hor, 0, ver);
		if (VC.sqrMagnitude > 1)
		VC.Normalize();

		body.AddForce (VC * 3);
		#endif
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("escape"))
			Application.Quit ();
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.CompareTag ("Candy")) {
			Destroy (col.gameObject);
			count += 1;
			bill.text = count.ToString ();
		}
	}
}
