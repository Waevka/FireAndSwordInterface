using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialBarController : MonoBehaviour {
    [SerializeField]
    Image specialBarFill;
    [SerializeField]
    Image specialIcon;

	// Use this for initialization
	void Start () {
        specialBarFill.fillAmount = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void UpdateFill(float points, float maxpoints)
    {
        float fillPercentage = points / maxpoints;
        specialBarFill.fillAmount = fillPercentage;
    }

     public void SpecialAvaliable(bool isAvaliable)
    {
        if (isAvaliable)
        {
            SpecialAvaliable();
        } else
        {
            SpecialUnavaliable();
        }
    }

    private void SpecialUnavaliable()
    {
        specialIcon.enabled = false;
    }

    private void SpecialAvaliable()
    {

        specialIcon.enabled = true;
    }
}
