using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {
    [SerializeField]
    Image currentHealth;
    [SerializeField]
    Image damageBar;
    [SerializeField]
    Image healingBar;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateFill(float percent)
    {
        StartCoroutine(AnimateDamageBar(currentHealth.fillAmount - percent));
        currentHealth.fillAmount = percent;
    }

    public void UpdateHealingFill(float percent)
    {
        healingBar.fillAmount = 0.0f;
        currentHealth.fillAmount = percent;
    }

    private IEnumerator AnimateDamageBar(float percent)
    {
        yield return new WaitForSeconds(1.0f);
        while(percent > 0.0f)
        {
            damageBar.fillAmount -= percent;
            percent = 0.0f;
        }
        yield return null;
    }

    public void Activate(int value)
    {
        float healFillAmount = Mathf.Clamp(value/100.0f + currentHealth.fillAmount, 0.0f, 1.0f);
        healingBar.fillAmount = healFillAmount;
    }

    public void Deactivate()
    {
        healingBar.fillAmount = 0.0f;
    }


}
