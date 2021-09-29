/*
 *  Created by: Adam Tang
 *  Date Created: Sept 22, 2021
 *  
 *  Last Edited by:
 *  Last Updated: Sept 28, 2021
 *  
 *  Description: AmmoManager manages the pool of ammo.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public static AmmoManager AmmoManagerSingleton = null;
    public GameObject AmmoPrefab = null;
    public int PoolSize = 100;
    public Queue<Transform> AmmoQueue = new Queue<Transform>();
    private GameObject[] AmmoArray;

    void Awake()
    {
        if (AmmoManagerSingleton != null)
        {
            Destroy(GetComponent<AmmoManager>());
            return;
        }
        AmmoManagerSingleton = this;
        AmmoArray = new GameObject[PoolSize];
        for (int i = 0; i < PoolSize; ++i)
        {
            AmmoArray[i] = Instantiate(AmmoPrefab, Vector3.zero,
            Quaternion.identity, transform) as GameObject;
            Transform ObjTransform = AmmoArray[i].transform;
            AmmoQueue.Enqueue(ObjTransform);
            AmmoArray[i].SetActive(false);
        }
    } // End Awake()
    public static Transform SpawnAmmo(Vector3 Position,
    Quaternion Rotation)
    {
        Transform SpawnedAmmo =
        AmmoManagerSingleton.AmmoQueue.Dequeue();
        SpawnedAmmo.gameObject.SetActive(true);
        SpawnedAmmo.position = Position;
        SpawnedAmmo.localRotation = Rotation;
        AmmoManagerSingleton.AmmoQueue.Enqueue(SpawnedAmmo);
        return SpawnedAmmo;
    } // End SpawnAmmo()

}