/*
 *  Created by: Adam Tang
 *  Date Created: Oct 5, 2021
 *  
 *  Last Edited by:
 *  Last Updated: Oct 5, 2021
 *  
 *  Description: Controls ammo damage
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAudioController : MonoBehaviour
{
    private int bullets;
    private GameObject Player = null;
    public AudioSource bulletSource;
    private bool canFire;

    void Awake()
    {
        Player = GameObject.Find("Player");
        bullets = Player.GetComponent<PlayerController>().getAmmo();
        bulletSource = GetComponent<AudioSource>();
        canFire = Player.GetComponent<PlayerController>().CanFire;
    }

    void Update()
    {
        bullets = Player.GetComponent<PlayerController>().getAmmo();
        canFire = Player.GetComponent<PlayerController>().CanFire;

        if (Input.GetKeyDown(KeyCode.Mouse0) && bullets!=0 && canFire)
        {
            bulletSource.Play();
        }
    }

}
