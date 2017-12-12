using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    GameObject menuPanels;
    [SerializeField]
    bool isControllerActive;
    [SerializeField]
    AnimationPlayer animationPlayer;
	// Use this for initialization
	void Start () {
        isControllerActive = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (isControllerActive)
        {
            transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * 2.0f);
            transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * 0.3f);
        }
        if (Input.GetButtonDown("Menu"))
        {
            isControllerActive = menuPanels.activeSelf;
            menuPanels.SetActive(!menuPanels.activeSelf);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            animationPlayer.PlayAnimation("BasicAttack");
        }
        if (Input.GetButtonDown("Fire2"))
        {
            animationPlayer.PlayAnimation("BasicSlash");
        }
        if (Input.GetButton("Fire3"))
        {
            animationPlayer.PlayAnimation("BasicBlock");
        }
        if (Input.GetButtonDown("Jump"))
        {
            animationPlayer.PlayAnimation("BasicStun");
        }
        if (Input.GetButtonDown("Submit")
            && Player.Instance.IsSpecialAvaliable())
        {
            animationPlayer.PlayAnimation("SuperAttack");
            Player.Instance.UseSpecial();
        }


    }


}
