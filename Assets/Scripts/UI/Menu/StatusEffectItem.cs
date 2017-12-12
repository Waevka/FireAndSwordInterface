using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StatusEffectType { BLEED, ARMOR, DEFLECT };

public class StatusEffectItem : MonoBehaviour {
    [SerializeField]
    Image effectImage;
    [SerializeField]
    StatusEffectType type;
    [SerializeField]
    Text timeLeft;
    [SerializeField]
    StatusEffect o;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft.text = Convert.ToInt32(o.GetTimeLeft()).ToString();
    }

    public void Initialize(StatusEffect _o, StatusEffectType _type, Sprite image)
    {
        o = _o;
        type = _type;
        effectImage.sprite = image;
        switch (type)
        {
            case StatusEffectType.BLEED:
                timeLeft.color = Color.red;
                break;
            case StatusEffectType.ARMOR:
            case StatusEffectType.DEFLECT:
                timeLeft.color = Color.green;
                break;
        }
    }

    public StatusEffectType GetEffectType()
    {
        return type;
    }
}
