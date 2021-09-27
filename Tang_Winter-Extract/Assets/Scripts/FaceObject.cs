/*
 *  Created by: Adam Tang
 *  Date Created: Sept 20, 2021
 *  
 *  Last Edited by:
 *  Last Updated: Sept 20, 2021
 *  
 *  Description: Defines what object the game object will face towards.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceObject : MonoBehaviour
{
    // Variables //
    public Transform ObjToFace = null;
    public bool FacePlayer = false;

    private void Awake()
    {
        if (!FacePlayer)
        {
            return;
        }
        GameObject PlayerObj = GameObject.FindGameObjectWithTag("Player");

        if (PlayerObj != null)
        {
            ObjToFace = PlayerObj.transform;
        }
    } // End Awake()

    // Update is called once per frame
    void Update()
    {
        if (ObjToFace == null)
        {
            return;
        }

        Vector3 DirToObj = ObjToFace.position - transform.position;

        if (DirToObj != Vector3.zero)
        {
            transform.localRotation = Quaternion.LookRotation(DirToObj.normalized, Vector3.up);
        }


    } // End Update()
}
