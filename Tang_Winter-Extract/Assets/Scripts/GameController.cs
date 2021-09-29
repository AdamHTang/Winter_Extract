/*
 *  Created by: Adam Tang
 *  Date Created: Sept 22, 2021
 *  
 *  Last Edited by:
 *  Last Updated: Sept 22, 2021
 *  
 *  Description: Game controller that control score and UI
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Variables //
    public static GameController ThisInstance = null;
    public static int Score;
    public string ScorePrefix = string.Empty;
    public Text ScoreText = null;
    public Text GameOverText = null;
    void Awake()
    {
        ThisInstance = this;
    } // End Awake()
    void Update()
    {
        if (ScoreText != null)
        {
            ScoreText.text = ScorePrefix + Score.ToString();
        }
    } // End Update()
    public static void GameOver()
    {
        if (ThisInstance.GameOverText != null)
        {
            ThisInstance.GameOverText.gameObject.
            SetActive(true);
        }
    } // End GameOver()

}
