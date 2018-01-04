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
    [SerializeField]
    Text valueText;
    [SerializeField]
    Text descrText;
    [SerializeField]
    Text nameText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft.text = Convert.ToInt32(o.GetTimeLeft()).ToString();
    }

    public void Initialize(StatusEffect _o, StatusEffectType _type, Sprite image, String descr)
    {
        o = _o;
        type = _type;
        effectImage.sprite = image;
        switch (type)
        {
            case StatusEffectType.BLEED:
                timeLeft.color = Color.red;
                if(valueText != null) valueText.color = Color.red;
                break;
            case StatusEffectType.ARMOR:
            case StatusEffectType.DEFLECT:
                timeLeft.color = Color.green;
                if(valueText != null) valueText.color = Color.green;
                break;
        }
        if (descrText != null) descrText.text = descr;
        if (nameText != null) nameText.text = type.ToString();
    }

    public StatusEffectType GetEffectType()
    {
        return type;
    }
}
