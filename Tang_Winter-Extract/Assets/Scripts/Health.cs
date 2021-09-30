/*
 *  Created by: Adam Tang
 *  Date Created: Sept 20, 2021
 *  
 *  Last Edited by:
 *  Last Updated: Sept 28, 2021
 *  
 *  Description: Game object health
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Variables //
    [SerializeField] private float _HealthPoints = 100f;
    public bool DestroyOnDeath = true;
    public GameObject DeathPrefab = null;
    Animator anim;

    public float HealthPoints
    {
        get { return _HealthPoints; } // End get()
        set
        {
            _HealthPoints = value;
            if (HealthPoints <= 0)
            {
                SendMessage("Die", SendMessageOptions.DontRequireReceiver);
                
                if (DeathPrefab != null)
                {
                    Instantiate(DeathPrefab, transform.position,Quaternion.Euler(90,transform.rotation.y,0));
                }

                if (DestroyOnDeath)
                {
                    Destroy(gameObject);
                }
            }

        } // End set()
    } // End HealthPoints()

    // Update is called once per frame
    void Update()
    {
        //Debug Health Test
        /* if (Input.GetKeyDown(KeyCode.Space))
        {
            HealthPoints = 0;
        } // End Debug
        */ 
    } // End Update()

    public float getHealthPoints()
    {
        return _HealthPoints;
    }
}
