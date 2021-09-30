/*
 *  Created by: Adam Tang
 *  Date Created: Sept 20, 2021
 *  
 *  Last Edited by:
 *  Last Updated: Sept 29, 2021
 *  
 *  Description: Continuously move gameObject.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Variable //
    public float MaxSpeed = 10f;
    public bool randomSpeed = false;    // Allow for variable speed between a certain range.

    void Awake()
    {
        if (randomSpeed)
        {
            MaxSpeed = Random.Range(2.5f, MaxSpeed);
        }
    } // End Awake()

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * MaxSpeed * Time.deltaTime;
    }
}
