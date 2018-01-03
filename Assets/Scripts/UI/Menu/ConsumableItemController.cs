using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsumableItemController : MonoBehaviour {
    [SerializeField]
    GameObject itemPrefab;
    private List<GameObject> items;
    int itemIndex;
    [SerializeField]
    GameObject itemSelectorPrefab;
    private GameObject itemSelector;
    [SerializeField]
    List<Sprite> imageList;
    [SerializeField]
    SpeedTextController speedText;
    [SerializeField]
    HealthBarController healthBar;
    [SerializeField]
    StatusEffectController statusEffectBar;
    [SerializeField]
    GameObject confirmationWindow;

    //list<gameitem> hfhfhd;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Vertical") && items.Count > 0 && confirmationWindow.activeInHierarchy != true)
        {
            itemIndex = Mathf.Clamp(itemIndex + (int)Input.GetAxisRaw("Vertical"), 0, items.Count - 1);
            UpdateActiveItem();
        }

        if (Input.GetButtonDown("Submit") && confirmationWindow.activeInHierarchy != true)
        {
            confirmationWindow.SetActive(true);
        }
    }

    private void UpdateActiveItem()
    {
        if (items.Count == 0)
        {
            healthBar.Deactivate();
            speedText.Deactivate();
        }
        else
        {
            if (itemSelector == null)
            {
                itemSelector = Instantiate(itemSelectorPrefab);
            }
            itemSelector.transform.SetParent(items[itemIndex].transform, false);

            Item finalItem = items[itemIndex].GetComponent<Item>();
            if (finalItem != null)
            {
                switch (finalItem.GetItemType())
                {
                    case ItemType.SPEED:
                        speedText.Activate(finalItem.GetItemValue());
                        healthBar.Deactivate();
                        statusEffectBar.Deactivate();
                        break;
                    case ItemType.HEALTH:
                        speedText.Deactivate();
                        healthBar.Activate(finalItem.GetItemValue());
                        statusEffectBar.Deactivate();
                        break;
                    case ItemType.BLEEDING:
                        healthBar.Deactivate();
                        speedText.Deactivate();
                        statusEffectBar.Activate(finalItem.GetItemType());
                        break;
                }
            }
        }

    }

    private void OnEnable()
    {
        items = new List<GameObject>();
        confirmationWindow.SetActive(false);
        itemIndex = 0;
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        
        for(int i = 0; i < 4; i++)
        {
            GameObject g = Instantiate(itemPrefab);
            g.transform.SetParent(transform, false);
            items.Add(g);
        }

        if(items.Count > 0)
        {
            itemSelector = Instantiate(itemSelectorPrefab);
        }

        TestFill();
        UpdateActiveItem();
    }

    private void TestFill()
    {
        items[0].GetComponent<Item>().Initialize("Speed", imageList[0], ItemType.SPEED, 25);
        items[1].GetComponent<Item>().Initialize("Healing", imageList[1], ItemType.HEALTH, 25);
        items[2].GetComponent<Item>().Initialize("Healing", imageList[2], ItemType.HEALTH, 75);
        items[3].GetComponent<Item>().Initialize("Bleeding", imageList[3], ItemType.BLEEDING, 1);
    }

    public void ConsumeItem(bool success)
    {
        confirmationWindow.SetActive(false);
        if (success)
        {   
            //include case where we delete last item in the list
            int adjustedFinalIndex = (itemIndex == items.Count - 1) ? itemIndex - 1 : itemIndex;
            GameObject i = items[itemIndex];
            Item it = i.GetComponent<Item>();
            switch (it.GetItemType())
            {
                case ItemType.SPEED:
                    Player.Instance.AddSpeed(it.GetItemValue());
                    break;
                case ItemType.HEALTH:
                    Player.Instance.RestoreHealth(it.GetItemValue() / 100.0f);
                    break;
                case ItemType.BLEEDING:
                    Player.Instance.RemoveStatusEffect(StatusEffectType.BLEED);
                    break;
            }
            items.RemoveAt(itemIndex);
            itemSelector.transform.SetParent(null, false);
            Destroy(i);
            itemIndex = adjustedFinalIndex;
            UpdateActiveItem();
        }
    }
}
