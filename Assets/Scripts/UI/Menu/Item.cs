using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType { CONSUMABLE, HEALTH, SPEED, WEAPON, BLEEDING };

public class Item : MonoBehaviour {
    [SerializeField]
    Sprite[] itemEffectIcons;
    [SerializeField]
    Sprite itemImage;
    [SerializeField]
    string itemName;
    [SerializeField]
    Text itemNameTextField;
    [SerializeField]
    Image itemImageField;
    [SerializeField]
    Image itemIconField;
    [SerializeField]
    Text itemEffectDescriptionField;
    [SerializeField]
    ItemType itemType;
    [SerializeField]
    int itemValue;
    //itemType
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Initialize(string _itemName, Sprite _itemImage, ItemType _type, int _itemValue)
    {
        itemName = _itemName;
        itemImage = _itemImage;
        itemType = _type;
        itemImageField.sprite = itemImage;
        itemValue = _itemValue;
        //TODO: set icon by type
        itemNameTextField.text = itemName;
        switch (itemType)
        {
            case ItemType.HEALTH:
                itemIconField.sprite = itemEffectIcons[0];
                itemEffectDescriptionField.text = itemValue + "%";
                break;
            case ItemType.SPEED:
                itemIconField.sprite = itemEffectIcons[1];
                itemEffectDescriptionField.text = itemValue + "%";
                break;
            default:
                itemIconField.sprite = itemEffectIcons[2];
                itemEffectDescriptionField.text = itemValue + "pcs";
                break;

        }
    }
    
    public ItemType GetItemType()
    {
        return this.itemType;
    }

    public int GetItemValue()
    {
        return itemValue;
    }
}
