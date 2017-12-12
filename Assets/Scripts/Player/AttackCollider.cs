using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour {
    Collider weaponCollider;
    // Use this for initialization
    private void Awake()
    {
        weaponCollider = GetComponent<BoxCollider>();
    }
    void Start () {
        weaponCollider.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {   
        if(other.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().DamageEnemy(
                Player.Instance.GetCurrentDamage());
        }
    }

    public void EnableWeaponCollider()
    {
        weaponCollider.enabled = true;
    }

    public void DisableWeaponCollider()
    { 
        weaponCollider.enabled = false;
    }
}
