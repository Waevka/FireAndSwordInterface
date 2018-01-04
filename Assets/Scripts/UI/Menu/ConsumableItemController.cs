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
    bool axisPressed;
    bool trigPressed;
    int currentFilter;
    [SerializeField]
    String[] filterNames;
    [SerializeField]
    Text filterName;

    //list<gameitem> hfhfhd;
    // Use this for initialization
    void Start () {
        currentFilter = 0;
        axisPressed = false;
        trigPressed = false;
	}
	
	// Update is called once per frame
	void Update ()
    {   
        if (((Input.GetButtonDown("Vertical")) || ((int)Input.GetAxisRaw("Vertical") != 0 && !axisPressed)) && items.Count > 0 && confirmationWindow.activeInHierarchy != true)
        {
            axisPressed = true;
            itemIndex = Mathf.Clamp(itemIndex + (int)Input.GetAxisRaw("Vertical"), 0, items.Count - 1);
            UpdateActiveItem();
        }

        if ((Input.GetButtonDown("Submit") || Input.GetButtonDown("Fire1")) && confirmationWindow.activeInHierarchy != true)
        {
            confirmationWindow.SetActive(true);
        }

        if((Input.GetAxisRaw("RT") != 0 || Input.GetAxisRaw("LT") != 0) && !trigPressed)
        {
            trigPressed = true;
            int direction = 0;
            if (Input.GetAxisRaw("RT") != 0)
            {
                direction = 1;
            } else if (Input.GetAxisRaw("LT") != 0)
            {
                direction = -1;
            }
            currentFilter += direction;
            if (currentFilter >= filterNames.Length) currentFilter = 0;
            if (currentFilter < 0) currentFilter = filterNames.Length - 1;
            //currentFilter = Mathf.Clamp(currentFilter + direction, 0, filterNames.Length - 1);
            filterName.text = filterNames[currentFilter];
            RandomizeItems();
        }

        if((int)Input.GetAxisRaw("Vertical") == 0)
        {
            axisPressed = false;
        }

        if(Input.GetAxisRaw("RT") == 0 && Input.GetAxisRaw("LT") == 0)
        {
            trigPressed = false;
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
        items[0].GetComponent<Item>().Initialize("Haste", imageList[0], ItemType.SPEED, 25);
        items[1].GetComponent<Item>().Initialize("Potion S", imageList[1], ItemType.HEALTH, 25);
        items[2].GetComponent<Item>().Initialize("Potion X", imageList[2], ItemType.HEALTH, 75);
        items[3].GetComponent<Item>().Initialize("Bandage", imageList[3], ItemType.BLEEDING, 1);
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

    private void RandomizeItems()
    {
        System.Random r = new System.Random();
        for(int it = 0; it < 4; it++)
        {
            int dx = r.Next(0, items.Count - 1);
            GameObject first = items[dx];
            items.Remove(first);
            items.Add(first);
            first.GetComponent<RectTransform>().SetAsLastSibling();
        }
        UpdateActiveItem();
    }
}
