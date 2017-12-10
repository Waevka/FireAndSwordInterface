using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType { CONSUMABLE, HEALTH, SPEED, WEAPON };

public class Item : MonoBehaviour {
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
    ItemType itemType;
    //itemType
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Initialize(string _itemName, Sprite _itemImage, ItemType _type)
    {
        itemName = _itemName;
        itemImage = _itemImage;
        itemType = _type;
        itemImageField.sprite = itemImage;
        //TODO: set icon by type
        itemNameTextField.text = itemName;
    }
}
