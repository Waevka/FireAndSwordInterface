using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlackBarTrigger : MonoBehaviour {
    public EventTrigger.TriggerEvent showBarsFunction;
    public EventTrigger.TriggerEvent hideBarsFunction;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trying to show bars");
        showBarsFunction.Invoke(new BaseEventData(EventSystem.current));
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trying to hide bars");
        hideBarsFunction.Invoke(new BaseEventData(EventSystem.current));
    }
}
