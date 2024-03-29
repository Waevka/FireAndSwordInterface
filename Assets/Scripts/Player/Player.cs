﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    private SpecialBarController specialBarController;
    [SerializeField]
    private HealthBarController healthBarController;
    [SerializeField]
    AnimationPlayer animationPlayer;

    [SerializeField]
    private float healthPoints;
    [SerializeField]
    private float maxHealthPoints;

    [SerializeField]
    private float specialPoints;
    [SerializeField]
    private bool specialAvaliable;

    [SerializeField]
    private float maxSpecialPoints;

    [SerializeField]
    private int playerSpeed;
    [SerializeField]
    List<StatusEffect> statusEffects;
    [SerializeField]
    GameObject SEPrefab;
    private float levelProgress;
    [SerializeField]
    private float currentDamage;
    [SerializeField]
    GameObject questFinishedText;

    public static Player Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<Player>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        specialPoints = 0.0f;
        currentDamage = 0.0f;
        healthPoints = maxHealthPoints = 100.0f;
        specialAvaliable = false;
        playerSpeed = 100;
        levelProgress = 0.75f;
    }

    private static Player instance;
	// Use this for initialization
	void Start ()
    {
        specialBarController.SpecialAvaliable(specialAvaliable);
        statusEffects = new List<StatusEffect>();
        statusEffects.Add(Instantiate(SEPrefab).GetComponent<StatusEffect>());
        statusEffects.Add(Instantiate(SEPrefab).GetComponent<StatusEffect>());
        statusEffects[0].InitializeEffect(60, StatusEffectType.BLEED, "Remove with [Bandage]");
        statusEffects[0].gameObject.transform.SetParent(transform, false);
        statusEffects[1].InitializeEffect(120, StatusEffectType.ARMOR, "Received via [Potion]");
        statusEffects[1].gameObject.transform.SetParent(transform, false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddSpecialPoints(float amount)
    {
        specialPoints = Mathf.Clamp(specialPoints + amount, 0.0f, maxSpecialPoints);
        specialBarController.UpdateFill(specialPoints, maxSpecialPoints);
        if(specialPoints == maxSpecialPoints)
        {
            specialAvaliable = true;
            specialBarController.SpecialAvaliable(specialAvaliable);
        }
    }
    public void DamagePlayer(float strength)
    {
        healthPoints = Mathf.Clamp(healthPoints - strength, 0.0f, maxHealthPoints);
        healthBarController.UpdateFill(healthPoints/maxHealthPoints);
        if(healthPoints == 0.0f)
        {
            Die();
        }
    }

    public void AddSpeed(int speedValue)
    {
        playerSpeed += speedValue;
    }

    public int GetSpeed()
    {
        return playerSpeed;
    }

    public void RestoreHealth(float amount)
    {
        healthPoints = Mathf.Clamp(healthPoints + (amount*100), 0.0f, maxHealthPoints);
        healthBarController.UpdateHealingFill(healthPoints / maxHealthPoints);
    }

    private void Die()
    {
        Debug.Log("You are dead :(");
    }

    public List<StatusEffect> GetStatusEffects()
    {
        return statusEffects;
    }

    public void RemoveStatusEffect(StatusEffect se)
    {
        statusEffects.Remove(se);
    }
    public void RemoveStatusEffect(StatusEffectType set)
    {
        foreach(StatusEffect se in statusEffects)
        {
            if (se.GetEffectType() == set){
                se.SetTimeLeft(0.0f);
            }
        }
    }

    public void UseSpecial()
    {
        specialAvaliable = false;
        specialPoints = 0.0f;
        specialBarController.SpecialAvaliable(specialAvaliable);
        specialBarController.UpdateFill(specialPoints, maxSpecialPoints);
    }

    public bool IsSpecialAvaliable()
    {
        return specialAvaliable;
    }

    public float GetLevelProgress()
    {
        return levelProgress;
    }

    public void AddLevelProgress(float percent)
    {
        levelProgress = Mathf.Clamp(levelProgress + percent, 0.0f, 1.0f);
        if (levelProgress >= 0.95f)
        {
            StartBossFight();
        }
    }

    private void StartBossFight()
    {
        //TODO
        Debug.Log("Level finished");
        StartCoroutine(ShowQuestCompleted());
    }

    private IEnumerator ShowQuestCompleted()
    {
        float currentTime = Time.time;
        if (questFinishedText != null) questFinishedText.SetActive(true);
        while(currentTime + 3.0f > Time.time)
        {
            yield return null;
        }
        if (questFinishedText != null) questFinishedText.SetActive(false);
        FindObjectOfType<BlackBarsController>().ShowBars();
    }

    public float GetCurrentDamage()
    {
        return currentDamage;
    }

    public void SetCurrentDamage(float d)
    {
        currentDamage = d;
    }
}
