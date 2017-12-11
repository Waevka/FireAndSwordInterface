using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTextController : MonoBehaviour {
    [SerializeField]
    Text speedText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Activate(int amount)
    {   
        speedText.text = (Player.Instance.GetSpeed() + amount) + "%";
        speedText.color = Color.green;

    }

    public void Deactivate()
    {
        speedText.text = Player.Instance.GetSpeed() + "%";
        speedText.color = Color.black;
    }
}
