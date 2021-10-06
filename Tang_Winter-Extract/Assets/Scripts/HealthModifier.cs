/*
 *  Created by: Adam Tang
 *  Date Created: Oct 5, 2021
 *  
 *  Last Edited by:
 *  Last Updated: Oct 5, 2021
 *  
 *  Description: Modify player health on trigger.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModifier : MonoBehaviour
{
    // Variables //
    public float HealthAddition = 25.0f;

    private void OnTriggerStay(Collider other)
    {
        Health H = other.gameObject.GetComponent<Health>();

        if (H == null) { return; }

        if (H.HealthPoints + HealthAddition > 100f)
        {
            H.HealthPoints = 100f;
        }
        else
        {
            H.HealthPoints += HealthAddition;
        }
        Destroy(gameObject);
    }
}
