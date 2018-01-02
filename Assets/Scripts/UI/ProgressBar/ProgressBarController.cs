using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour {
    [SerializeField]
    Image ourProgressBar;
    [SerializeField]
    Image progressIcon;
    [SerializeField]
    GameObject panel;
    [SerializeField]
    Vector2 anchoredMin;
    [SerializeField]
    Vector2 anchoredMax;
	// Use this for initialization
	void Start () {
        anchoredMin = panel.GetComponent<RectTransform>().anchorMin;
        anchoredMin = new Vector2(anchoredMin.x, 0);
        anchoredMax = panel.GetComponent<RectTransform>().anchorMax;
        anchoredMax = new Vector2(anchoredMax.x, 0);
    }
	
	// Update is called once per frame
	void Update () {
        ourProgressBar.fillAmount = Player.Instance.GetLevelProgress();
        progressIcon.GetComponent<RectTransform>().anchoredPosition = new Vector2(1000 * Player.Instance.GetLevelProgress(), 0);
	}
}
