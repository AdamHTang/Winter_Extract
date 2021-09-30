/*
 *  Created by: Adam Tang
 *  Date Created: Sept 29, 2021
 *  
 *  Last Edited by:
 *  Last Updated: Sept 29, 2021
 *  
 *  Description: Camera Controller script to move camera to player.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Variables //
    public Transform target;
    public GameObject Player = null;


    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 25, target.transform.position.z);
        }
    }
}
