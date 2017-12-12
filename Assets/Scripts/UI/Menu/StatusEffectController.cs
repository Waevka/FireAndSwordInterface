using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusEffectController : MonoBehaviour {
    [SerializeField]
    List<StatusEffect> statusEffects;
    [SerializeField]
    List<GameObject> statusEffectPanels;
    [SerializeField]
    GameObject statusEffectPrefab;
    [SerializeField]
    Sprite statusEffectImage;
	// Use this for initialization
	void Start () {
        RetrieveEffectsFromPlayer();
    }

    private void OnEnable()
    {
        RetrieveEffectsFromPlayer();
    }

    private void RetrieveEffectsFromPlayer()
    {
        statusEffectPanels = new List<GameObject>();
        statusEffects = Player.Instance.GetStatusEffects();
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        foreach (StatusEffect se in statusEffects)
        {
            GameObject g = Instantiate(statusEffectPrefab);
            g.transform.SetParent(transform, false);
            statusEffectPanels.Add(g);
            UpdateItems();
        }
    }

    // Update is called once per frame
    void Update () {
		if(Player.Instance.GetStatusEffects().Count != statusEffectPanels.Count)
        {
            RetrieveEffectsFromPlayer();
        }
	}

    void UpdateItems()
    {
        for(int i = 0; i < statusEffectPanels.Count; i++)
        {
            statusEffectPanels[i].GetComponent<StatusEffectItem>().Initialize(
                statusEffects[i], statusEffects[i].GetEffectType(), statusEffectImage);
        }
    }

    public void Deactivate()
    {   
        foreach(GameObject panel in statusEffectPanels)
        {
            panel.GetComponent<Image>().enabled = false;
        }
    }

    public void Activate(ItemType _type)
    {
        foreach (GameObject panel in statusEffectPanels)
        {
            if (panel.GetComponent<StatusEffectItem>().GetEffectType() == StatusEffectType.BLEED 
                && _type == ItemType.BLEEDING)
            {
                panel.GetComponent<Image>().enabled = true;
            }
        }
        
    }
}
