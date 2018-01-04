using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect : MonoBehaviour {
    [SerializeField]
    float timeLeft;
    [SerializeField]
    StatusEffectType type;
    float lastUpdateTime;
    float lastEffectTickTime;
    public string description = "";
	// Use this for initialization
	void Start () {
        lastUpdateTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - lastUpdateTime > 1.0f && timeLeft > 0.0f)
        {
            lastUpdateTime = Time.time;
            timeLeft -= 1;
        }
        if(Time.time - lastEffectTickTime > 3.0f && timeLeft > 0.0 && type == StatusEffectType.BLEED)
        {
            lastEffectTickTime = Time.time;
            Player.Instance.DamagePlayer(5);
        }
        if (timeLeft <= 0)
        {
            EndEffect();
        }
	}

    public float GetTimeLeft()
    {
        return timeLeft;
    }

    public void SetTimeLeft(float f)
    {
        timeLeft = f;
    }

    public void InitializeEffect(float time, StatusEffectType _type, string descr)
    {
        timeLeft = time;
        type = _type;
        description = descr;
    }

    public void EndEffect()
    {
        Player.Instance.RemoveStatusEffect(this);
        Destroy(gameObject, 1.0f);
    }

    public StatusEffectType GetEffectType()
    {
        return type;
    }
}
