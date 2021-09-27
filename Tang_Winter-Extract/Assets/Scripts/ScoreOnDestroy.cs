/*
 *  Created by: Adam Tang
 *  Date Created: Sept 22, 2021
 *  
 *  Last Edited by:
 *  Last Updated: Sept 22, 2021
 *  
 *  Description: Gives score on destroy of gameObject.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDestroy : MonoBehaviour
{
    public int ScoreValue = 50;
    void OnDestroy()
    {
        GameController.Score += ScoreValue;
    }
}
