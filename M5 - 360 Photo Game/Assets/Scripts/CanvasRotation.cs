using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class CanvasRotation : MonoBehaviour {

	// Use this for initialization
	Rigidbody m_Rigidbody;
	float m_Speed = 10.0f;
	void Start () {
		//grab components
		m_Rigidbody = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			//Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
			m_Rigidbody.velocity = transform.forward * m_Speed;
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			//Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
			m_Rigidbody.velocity = -transform.forward * m_Speed;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			//Rotate the sprite about the Y axis in the positive direction
			transform.Rotate (new Vector3 (0, 1, 0) * Time.deltaTime * m_Speed, Space.World);
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			//Rotate the sprite about the Y axis in the negative direction
			transform.Rotate (new Vector3 (0, -1, 0) * Time.deltaTime * m_Speed, Space.World);
		} else {
			m_Rigidbody.velocity = Vector3.zero;
		}
	}
}