/*
 * Created By: Adam Tang
 * Created On : Oct 5, 2021
 * Last Edited By:
 * Last Updated: Oct 5, 2021
 * 
 * Description: Ends the application.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    // Variables //
    private float timer;

    // Start is called before the first frame update
    void Awake()
    {
        timer = 10.0f;
    }

    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Application.Quit();
        }
    }

}
