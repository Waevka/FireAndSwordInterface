using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPointsAdder : MonoBehaviour {
    [SerializeField]
    private float value = 5.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up);
	}

    private void OnTriggerEnter(Collider other)
    {
        Player.Instance.AddSpecialPoints(value);
        Destroy(gameObject);
    }
}
