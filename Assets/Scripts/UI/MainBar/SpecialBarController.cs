using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialBarController : MonoBehaviour {
    [SerializeField]
    RectTransform specialBarFill;
    [SerializeField]
    Image specialIcon;
    [SerializeField]
    Vector3 specialBarRotation;
    [SerializeField]
    float minimumRotation; //describes lowest level of power
    [SerializeField]
    float maximumRotation; //max level of power;
    [SerializeField]
    float totalFillRotation;

	// Use this for initialization
	void Start () {
        totalFillRotation = 145.0f;
        minimumRotation = specialBarFill.eulerAngles.z;
        maximumRotation = minimumRotation - totalFillRotation;
        specialBarRotation = specialBarFill.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        specialBarFill.transform.eulerAngles = specialBarRotation;
    }

    public void UpdateFill(float points, float maxpoints)
    {
        float fillPercentage = points / maxpoints;
        specialBarRotation.z = minimumRotation - (totalFillRotation * fillPercentage);
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
        specialIcon.color = Color.grey;
    }

    private void SpecialAvaliable()
    {

        specialIcon.color = Color.white;
    }
}
