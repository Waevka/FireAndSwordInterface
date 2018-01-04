using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
    [SerializeField]
    int currentActiveTab;
    [SerializeField]
    GameObject[] tabLabels;
    [SerializeField]
    GameObject[] tabs;
    [SerializeField]
    Sprite selectedTabBg;
    [SerializeField]
    Sprite notSelectedTabBg;
    private void Awake()
    {
        currentActiveTab = 0;
        if (isActiveAndEnabled)
        {
            gameObject.SetActive(false);
        }
    }
    // Use this for initialization
    void Start () {
    }

    private void OnEnable()
    {
        currentActiveTab = 0;
        UpdateActiveTabs();
        //reset menu state
    }

    // Update is called once per frame
    void Update () {
        if(Input.GetButtonDown("Horizontal"))
        {
            currentActiveTab = Mathf.Clamp(currentActiveTab + (int)Input.GetAxisRaw("Horizontal"), 0, tabLabels.Length-1);
            UpdateActiveTabs();
        }
        else if (Input.GetButtonDown("MenuLeft"))
        {
            currentActiveTab = Mathf.Clamp(currentActiveTab - 1, 0, tabLabels.Length - 1);
            UpdateActiveTabs();
        } else if (Input.GetButtonDown("MenuRight"))
        {
            currentActiveTab = Mathf.Clamp(currentActiveTab + 1, 0, tabLabels.Length - 1);
            UpdateActiveTabs();
        }
	}

    void UpdateActiveTabs()
    {
        for(int i = 0; i < tabLabels.Length; i++)
        {
            if(i == currentActiveTab)
            {
                tabLabels[i].GetComponent<Image>().sprite = selectedTabBg;
                tabs[i].SetActive(true);
            }
            else
            {
                tabLabels[i].GetComponent<Image>().sprite = notSelectedTabBg;
                tabs[i].SetActive(false);
            }
        }
    }
}
