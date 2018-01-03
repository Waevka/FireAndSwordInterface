using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTextController : MonoBehaviour {
    [SerializeField]
    Text speedText;
    Color defaultTextColor;
	// Use this for initialization
	void Start () {
        defaultTextColor = new Color(182.0f/255.0f, 149.0f/255.0f, 9.0f/255.0f);
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
        speedText.color = defaultTextColor;
    }
}
