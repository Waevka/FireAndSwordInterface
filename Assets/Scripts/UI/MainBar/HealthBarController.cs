using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {
    [SerializeField]
    Image currentHealth;
    [SerializeField]
    Image damageBar;
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


}
