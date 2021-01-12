﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTransformHandler : MonoBehaviour
{
    public GameObject playerToAnimate;
    public GameObject facingRight;
    public GameObject facingForward;
    public GameObject facingUp;
    public GameObject facingDownRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = playerToAnimate.transform.position;
        if (playerToAnimate.transform.right.x < 0)
        {
            this.transform.localScale = new Vector3(-0.35f, 0.35f, 0.35f);
        }
        if (playerToAnimate.transform.right.x > 0)
        {
            this.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
        }
        if (playerToAnimate.transform.right.x > .75f || playerToAnimate.transform.right.x < -.75f)
        {
            facingRight.SetActive(true);
            facingUp.SetActive(false);
            facingForward.SetActive(false);
            facingDownRight.SetActive(false);
            return;
        }
        if (playerToAnimate.transform.right.y > .5f)
        {

            facingDownRight.SetActive(false);
            facingRight.SetActive(false);
            facingForward.SetActive(false);
            facingUp.SetActive(true);
            return;
        }
        if (playerToAnimate.transform.right.x < .35f && playerToAnimate.transform.right.x > -.35f)
        {
            facingDownRight.SetActive(false);
            facingRight.SetActive(false);
            facingForward.SetActive(true);
            facingUp.SetActive(false);
            return;
        }
        if (playerToAnimate.transform.right.x > .35f || playerToAnimate.transform.right.x < -.35f)
        {
            facingDownRight.SetActive(true);
            facingUp.SetActive(false);
            facingForward.SetActive(false);
            facingRight.SetActive(false);
            return;
        }


    }
    public void SetPlayer(GameObject playerGO)
    {
        playerToAnimate = playerGO;
    }
}
