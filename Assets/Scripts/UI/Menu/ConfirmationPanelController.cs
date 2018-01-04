using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationPanelController : MonoBehaviour {
    [SerializeField]
    ConsumableItemController cic;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Submit") || Input.GetButtonDown("Fire1"))
        {
            cic.ConsumeItem(true);
        }
        else if (Input.GetButtonDown("Cancel") || Input.GetButtonDown("Fire2"))
        {
            cic.ConsumeItem(false);
        }
    }
}
