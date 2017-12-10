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

    //list<gameitem> hfhfhd;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Vertical") && items.Count > 0)
        {
            itemIndex = Mathf.Clamp(itemIndex + (int)Input.GetAxisRaw("Vertical"), 0, items.Count - 1);
            UpdateActiveItem();
        }
    }

    private void UpdateActiveItem()
    {
        itemSelector.transform.SetParent(items[itemIndex].transform, false);
    }

    private void OnEnable()
    {
        items = new List<GameObject>();
        itemIndex = 0;
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        
        for(int i = 0; i < 5; i++)
        {
            GameObject g = Instantiate(itemPrefab);
            g.transform.SetParent(transform, false);
            items.Add(g);
        }

        if(items.Count > 0)
        {
            itemSelector = Instantiate(itemSelectorPrefab);
            itemSelector.transform.SetParent(items[itemIndex].transform, false);
        }

        TestFill();
    }

    private void TestFill()
    {
        items[0].GetComponent<Item>().Initialize("Healing", imageList[0], ItemType.CONSUMABLE);
    }
}
