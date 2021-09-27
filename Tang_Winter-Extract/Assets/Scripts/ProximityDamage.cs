/*
 *  Created by: Adam Tang
 *  Date Created: Sept 20, 2021
 *  
 *  Last Edited by:
 *  Last Updated: Sept 20, 2021
 *  
 *  Description: Deal damage to any colliding object with health component.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyDamage : MonoBehaviour
{
    // Variables //
    public float DamageRate = 10f;  // Damage per second.

    private void OnTriggerStay(Collider other)
    {
        Health H = other.gameObject.GetComponent<Health>();

        if (H == null) { return; }
        H.HealthPoints -= DamageRate * Time.deltaTime;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
