using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		
	}

    private void OnEnable()
    {
        statusEffectPanels = new List<GameObject>();
        statusEffects = Player.Instance.GetStatusEffects();
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        foreach(StatusEffect se in statusEffects)
        {
            GameObject g = Instantiate(statusEffectPrefab);
            g.transform.SetParent(transform, false);
            statusEffectPanels.Add(g);
            UpdateItems();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    void UpdateItems()
    {
        for(int i = 0; i < statusEffectPanels.Count; i++)
        {
            statusEffectPanels[i].GetComponent<StatusEffectItem>().Initialize(
                statusEffects[i], statusEffects[i].GetEffectType(), statusEffectImage);
        }
    }
}
