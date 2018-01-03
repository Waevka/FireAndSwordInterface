using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialBarController : MonoBehaviour {
    [SerializeField]
    Image specialBarFill;
    [SerializeField]
    Image specialIcon1;
    [SerializeField]
    Image specialIcon2;

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
        specialIcon1.enabled = false;
        specialIcon2.enabled = false;
    }

    private void SpecialAvaliable()
    {

        specialIcon1.enabled = true;
        specialIcon2.enabled = true;
    }
}
