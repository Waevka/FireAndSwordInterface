using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    private SpecialBarController specialBarController;

    [SerializeField]
    private float specialPoints;
    [SerializeField]
    private bool specialAvaliable;
    [SerializeField]
    private float maxSpecialPoints;

    public static Player Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<Player>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        specialPoints = 0.0f;
        specialAvaliable = false;
    }

    private static Player instance;
	// Use this for initialization
	void Start ()
    {
        specialBarController.SpecialAvaliable(specialAvaliable);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddSpecialPoints(float amount)
    {
        specialPoints = Mathf.Clamp(specialPoints + amount, 0.0f, maxSpecialPoints);
        specialBarController.UpdateFill(specialPoints, maxSpecialPoints);
        if(specialPoints == maxSpecialPoints)
        {
            specialAvaliable = true;
            specialBarController.SpecialAvaliable(specialAvaliable);
        }
    }
}
