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
        if (Input.GetButtonDown("Submit"))
        {
            cic.ConsumeItem(true);
        }
        else if (Input.GetButtonDown("Cancel"))
        {
            cic.ConsumeItem(false);
        }
    }
}
