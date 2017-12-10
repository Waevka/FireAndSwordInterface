using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItemController : MonoBehaviour {
    [SerializeField]
    GameObject itemPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        
        for(int i = 0; i < 5; i++)
        {
            GameObject g = Instantiate(itemPrefab);
            g.transform.SetParent(transform, false);
        }

    }
}
