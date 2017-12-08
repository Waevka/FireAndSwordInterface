using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBarsController : MonoBehaviour {
    [SerializeField]
    RectTransform topBar;
    [SerializeField]
    RectTransform bottomBar;

    //describes the current action, not the state
    // "are bars moving up or down right now?"
    public bool barsAreMovingUp = false;
    public bool barsShowing = false;
    public bool barsAreMovingDown = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowBars()
    {
        StartCoroutine(MovingDown());
    }

    public void HideBars()
    {
        StartCoroutine(MovingUp());
    }

    private IEnumerator MovingUp()
    {
        while (barsAreMovingDown)
        {
            Debug.Log("Waiting for down");
            yield return new WaitForSeconds(0.5f);
        }

        Debug.Log("Hiding black cutscene bars");
        barsAreMovingUp = true;
        while (topBar.anchoredPosition.y < topBar.rect.height)
        {
            topBar.anchoredPosition = new Vector2(topBar.anchoredPosition.x, topBar.anchoredPosition.y + 0.5f);
            bottomBar.anchoredPosition = new Vector2(bottomBar.anchoredPosition.x, bottomBar.anchoredPosition.y - 0.5f);
            yield return new WaitForSeconds(0.01f);

        }
        barsAreMovingUp = false;
        barsShowing = false;
        yield return null;
    }

    private IEnumerator MovingDown()
    {
        while (barsAreMovingUp)
        {
            Debug.Log("Waiting for up");
            yield return new WaitForSeconds(0.5f);
        }

        barsAreMovingDown = true;
        while (topBar.anchoredPosition.y > 0) //topBar.rect.height
        {
            topBar.anchoredPosition = new Vector2(topBar.anchoredPosition.x, topBar.anchoredPosition.y -0.5f);
            bottomBar.anchoredPosition = new Vector2(bottomBar.anchoredPosition.x, bottomBar.anchoredPosition.y + 0.5f);
            yield return new WaitForSeconds(0.01f);

        }
        Debug.Log("Showing black cutscene bars");
        //do the thing
        barsAreMovingDown = false;
        barsShowing = true;
        yield return null;
    }
}
