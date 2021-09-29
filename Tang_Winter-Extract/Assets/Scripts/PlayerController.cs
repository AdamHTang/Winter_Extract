/*
 *  Created by: Adam Tang
 *  Date Created: Sept 26, 2021
 *  
 *  Last Edited by: Adam Tang
 *  Last Updated: Sept 29, 2021
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
    public float fireDelay = 0.0f;
    public float reloadDelay = 1.0f;
    public bool CanFire = true;
    public Transform[] TurretTransforms;

    public int magSize = 20;            // Determines max ammo size for the player.
    private int bulletsLeft;            // Keeps count of number of bullets the player has at the moment.
    private bool isMoving = false;      // Keeps track of the player moving and not moving.

    public AudioSource playerSource = null;

    /* Awake - Call before game start*/
    private void Awake()
    {
        ThisBody = GetComponent<Rigidbody>();        // Sets the object's rigidbody to a variable called playerRB.
        bulletsLeft = magSize;
        playerSource = GetComponent<AudioSource>();
    }   // End Awake()


    private void FixedUpdate()
    {
        moveDirection.x= Input.GetAxisRaw(horzAxis);
        moveDirection.z= Input.GetAxisRaw(vertAxis);

        ThisBody.MovePosition(ThisBody.position + (moveDirection.normalized * speed));
        if (ThisBody.position != ThisBody.position + (moveDirection.normalized * speed)){
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }



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
    } // End EnableFire()

    private void Update()
    {
        if (isMoving && !playerSource.isPlaying)
        {

            playerSource.Play();
        }

        if (Input.GetButtonDown(FireAxis) && CanFire && bulletsLeft == 0 || Input.GetKeyDown(KeyCode.R))
        {
            CanFire = false;
            Invoke("EnableFire", reloadDelay);
            bulletsLeft = magSize;
        }
        else if (Input.GetButtonDown(FireAxis) && CanFire && bulletsLeft != 0)
        {
            foreach (Transform T in TurretTransforms)
            {
                AmmoManager.SpawnAmmo(T.position, T.rotation);
            }
            bulletsLeft--;
            CanFire = false;
            Invoke("EnableFire", fireDelay);
        }
    } // End Update()

    public int getAmmo()        // returns the number of bullets that the player currently has.
    {
        return bulletsLeft;
    } // End getAmmo()

    void OnDestroy()
    {
        GameManager.IsPlayerDead = true;
    }
}
