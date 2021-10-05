/*
 *  Created by: Adam Tang
 *  Date Created: Sept 20, 2021
 *  
 *  Last Edited by:
 *  Last Updated: Sept 29, 2021
 *  
 *  Description: Spawns gameObjects
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float MaxRadius = 1f;
    public float lowerInterval = 5f;
    public float upperInterval = 10f;
    public float fixedInterval = 1.0f;
    public bool randomInterval = false;
    public GameObject ObjToSpawn = null;
    private Transform Origin = null;
    public bool spawnOnPlayer = false;

    void Awake()
    {
        if (spawnOnPlayer) {
            Origin = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
        {
            Origin = transform;
        }

    } // End Awake()

    [System.Obsolete]
    void Start()
    {
        if (randomInterval)
        {
            fixedInterval = Random.RandomRange(lowerInterval, upperInterval);
        }
        InvokeRepeating("Spawn", 0f, fixedInterval);
    } // End Start()

    void Spawn()
    {
        if (Origin == null)
        {
            return;
        }
        Vector3 SpawnPos = Origin.position + Random.
        onUnitSphere * MaxRadius;
        SpawnPos = new Vector3(SpawnPos.x, 0f, SpawnPos.z);
        Instantiate(ObjToSpawn, SpawnPos, Quaternion.
        identity);
    }   // End Spawn()
}
