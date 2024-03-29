﻿using System.Collections;
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
            animationPlayer.PlayAnimation("BasicAttack", 20.0f, 0.417f);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            animationPlayer.PlayAnimation("BasicSlash", 50.0f, 0.667f);
        }
        if (Input.GetButton("Fire3"))
        {
            animationPlayer.PlayAnimation("BasicBlock", 0.0f, 0.500f);
        }
        if (Input.GetButtonDown("Jump"))
        {
            animationPlayer.PlayAnimation("BasicStun", 10.0f, 0.750f);
        }
        if (Input.GetButtonDown("Submit") || (Input.GetAxisRaw("RT") != 0 && Input.GetAxisRaw("LT") != 0.0)
            && Player.Instance.IsSpecialAvaliable())
        {
            animationPlayer.PlayAnimation("SuperAttack", 300.0f, 1.417f);
            Player.Instance.UseSpecial();
        }


    }


}
