using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float strength = 5.0f;
    public float health = 100.0f;
    public bool isStronger = false;
    public bool canBeDamaged;
    private float maxHealth;

	// Use this for initialization
	void Start () {
        maxHealth = health;
        canBeDamaged = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player.Instance.DamagePlayer(strength);
        }
    }

    public void DamageEnemy(float damage)
    {   
        if (!canBeDamaged) return;
        health = Mathf.Clamp(health - damage, 0, maxHealth);
        Debug.Log("Damaged " + gameObject.name + " for " + damage + ", left: " + health);
        if(health <= 0.0f)
        {
            Die();
        }
    }

    private void Die()
    {
        canBeDamaged = false;
        Player.Instance.AddSpecialPoints(10.0f);
        Player.Instance.AddLevelProgress(0.1f);
        Destroy(gameObject, 0.5f);
    }
}
