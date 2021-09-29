/*
 *  Created by: Adam Tang
 *  Date Created: Sept 28, 2021
 *  
 *  Last Edited by:
 *  Last Updated: Sept 28, 2021
 *  
 *  Description: AudioManager for reloading weapons.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadAudioManager : MonoBehaviour
{
    // Variables //
    public AudioSource reloadSource = null;     // AudioSource
    public PlayerController playerCon = null;   // PlayerController
    private bool cooldown;                      // Cooldown to prevent player from spamming the reload action sound.

    // Start is called before the first frame update
    void Awake()
    {
        reloadSource = GetComponent<AudioSource>();                             // Obtains the current object's AudioSource component.
        PlayerController playerCon = GetComponentInParent<PlayerController>();  // Obtains parent's PlayerController component.
        cooldown = false;                                                       // Initialize the cooldown to be false.
    } // End Awake()

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.R)) && cooldown == false || playerCon.getAmmo() == 0)
        {
            reloadSource.Play();
            Invoke("ResetCooldown", 3.0f);
            cooldown = true;
        }
    } // End Update()

    void ResetCooldown()
    {
        cooldown = false;
    } // End ResetCooldown()
}
