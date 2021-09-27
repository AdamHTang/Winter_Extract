/*
 *  Created by: Adam Tang
 *  Date Created: Sept 26, 2021
 *  
 *  Last Edited by:
 *  Last Updated: Sept 26, 2021
 *  
 *  Description: Player Controller that controls movement and shooting.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /* VARIABLES */
    public bool mouseLook = true;           // Are we looking at the mouse.
    public string horzAxis = "Horizontal";
    public string vertAxis = "Vertical";
    public float speed = .1f;             // Speed of the character.
    private Rigidbody ThisBody = null;
    Vector3 moveDirection;

    public string FireAxis = "Fire1";
    public float ReloadDelay = 0.0f;
    public bool CanFire = true;
    public Transform[] TurretTransforms;

    /* Awake - Call before game start*/
    private void Awake()
    {
        ThisBody = GetComponent<Rigidbody>();        // Sets the object's rigidbody to a variable called playerRB.
    }   // End Awake()


    private void FixedUpdate()
    {
        moveDirection.x= Input.GetAxisRaw(horzAxis);
        moveDirection.z= Input.GetAxisRaw(vertAxis);
    

        ThisBody.MovePosition(ThisBody.position + (moveDirection.normalized * speed));  

        if (mouseLook)
        {
            Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(
                                  new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));

            mousePosWorld = new Vector3(mousePosWorld.x, 0.0f, mousePosWorld.z);

            Vector3 lookDirection = mousePosWorld - transform.position;
            transform.localRotation = Quaternion.LookRotation(lookDirection.normalized, Vector3.up);

        }

    }
    void EnableFire()
    {
        CanFire = true;
    }

    private void Update()
    {
        if (Input.GetButtonDown(FireAxis) && CanFire)
        {
            foreach (Transform T in TurretTransforms)
            {
                AmmoManager.SpawnAmmo(T.position, T.rotation);
            }
            CanFire = false;
            Invoke("EnableFire", ReloadDelay);
        }
    }
}
