﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHand : MonoBehaviour
{
    PlayerController opponent;
    [SerializeField] Transform player;
    PlayerController playerScript;
    SphereCollider thisCollider;
    bool opponentTookDamage = false;

    // Start is called before the first frame update

    void Awake()
    {
        thisCollider = this.transform.GetComponent<SphereCollider>();
        playerScript = player.GetComponent<PlayerController>();
    }
    void Update()
    {
        if (transform.localPosition.x <= 0)
        {
            opponentTookDamage = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {

        opponent = other.transform.parent.GetComponent<PlayerController>();


        if (opponent != null)
        {
            if (!opponentTookDamage)
            {
                if (opponent.isParrying)
                {
                    opponent.Parry();
                    opponentTookDamage = true;
                    return;
                }
                if (playerScript.punchedLeft && playerScript.punchedRight)
                {
                    Debug.Log("Grab");
                    opponentTookDamage = true;
                    return;
                }
                Vector3 punchTowards = new Vector3(player.right.normalized.x, 0, player.right.normalized.z);
                float damage = transform.localScale.x * 3f;
                opponent.Knockback(damage, punchTowards);
                Debug.Log(damage);
                opponentTookDamage = true;
            }
            
        }
        

    }
}
