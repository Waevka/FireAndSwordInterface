using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour {
    [SerializeField]
    AttackCollider attackCollider;
    float timeCheck;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(timeCheck > 0)
        {
            timeCheck -= Time.time;
            if (timeCheck <= 0.0f)
            {
                Player.Instance.SetCurrentDamage(0.0f);
                attackCollider.DisableWeaponCollider();
            }

        }
    }

    public void PlayAnimation(string name, float damage, float time)
    {   
        Player.Instance.SetCurrentDamage(damage);
        attackCollider.EnableWeaponCollider();
        timeCheck = time;
        GetComponent<Animator>().Play(name);
    }
    
}
