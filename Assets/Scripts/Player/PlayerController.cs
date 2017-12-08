using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * 2.0f);
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * 0.3f);      
	}
}
