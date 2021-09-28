/*
 *  Created by: Adam Tang
 *  Date Created: Sept 22, 2021
 *  
 *  Last Edited by:
 *  Last Updated: Sept 22, 2021
 *  
 *  Description: Controls ammo damage
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    // Variables //
    public float Damage = 100f;
    public float LifeTime = 2f;
    public AudioSource bulletSource = null;

    void Awake()
    {
        bulletSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        bulletSource.Play();
        CancelInvoke();
        Invoke("Die", LifeTime);

    } // End onEnable()

    private void OnTriggerEnter(Collider other)
    {
        Health H = other.gameObject.GetComponent<Health>();
        H.HealthPoints -= Damage;
        Die();
    } // End OnTriggerEnter();

    void Die()
    {
        gameObject.SetActive(false);
    }

}
