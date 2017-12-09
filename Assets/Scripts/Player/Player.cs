using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    private SpecialBarController specialBarController;
    [SerializeField]
    private HealthBarController healthBarController;

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
        healthPoints = maxHealthPoints = 100.0f;
        specialAvaliable = false;
    }

    private static Player instance;
	// Use this for initialization
	void Start ()
    {
        specialBarController.SpecialAvaliable(specialAvaliable);
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

    private void Die()
    {
        Debug.Log("You are dead :(");
    }
}
