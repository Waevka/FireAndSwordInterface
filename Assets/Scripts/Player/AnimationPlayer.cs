using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour {
    [SerializeField]
    AttackCollider attackCollider;
    [SerializeField]
    float startTime;
    float timeCheck;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(timeCheck > 0)
        {
            if (Time.time - startTime >= timeCheck)
            {
                Player.Instance.SetCurrentDamage(0.0f);
                attackCollider.DisableWeaponCollider();
                timeCheck = 0.0f;
                startTime = 0.0f;
            }

        }
    }

    public void PlayAnimation(string name, float damage, float time)
    {
        Player.Instance.SetCurrentDamage(damage);
        attackCollider.EnableWeaponCollider();
        timeCheck = time;
        startTime = Time.time;
        GetComponent<Animator>().Play(name);
    }
    
}
