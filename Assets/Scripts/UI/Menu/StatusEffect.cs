using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect : MonoBehaviour {
    [SerializeField]
    float timeLeft;
    [SerializeField]
    StatusEffectType type;
    float lastUpdateTime;
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
	}

    public float GetTimeLeft()
    {
        return timeLeft;
    }

    public void InitializeEffect(float time, StatusEffectType _type)
    {
        timeLeft = time;
        type = _type;
    }

    public StatusEffectType GetEffectType()
    {
        return type;
    }
}
