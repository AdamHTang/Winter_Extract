/*
 * Created By: Adam Tang
 * Created On : Sept 29, 2021
 * Last Edited By:
 * Last Updated: Oct 4, 2021
 * 
 * Description: Game manager to control global game behaviors.
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variables //
    #region GameManager Singleton
    static GameManager gm;
    public static GameManager GM
    {
        get { return gm; }
    }

    void CheckGameManagerIsInScene()
    {
        if(gm == null)
        {
            gm = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
    #endregion

    public static int Score;
    public float timeRemaining = 120.0f;
    public string ScorePrefix = string.Empty;
    public TMP_Text ScoreText = null;
    public TMP_Text GameOverText = null;
    public TMP_Text HealthText = null;
    public TMP_Text AmmoText = null;
    public TMP_Text WinText = null;
    public TMP_Text TimerText = null;
    public GameObject Player = null;
    public static bool IsPlayerDead = false;
    

    private static int minutes;
    private static float seconds;

    void Awake()
    {
        CheckGameManagerIsInScene();
        minutes = (int)(timeRemaining / 60);
        seconds = (timeRemaining % 60);
        
    } // End Awake()

    // Update is called once per frame
    void Update()
    {
        if (ScoreText != null)
        {
            ScoreText.text = ScorePrefix + Score.ToString();
        }

        if (HealthText != null && GameObject.Find("Player") != null)
        {
            HealthText.text = "+" + Player.GetComponent<Health>().getHealthPoints().ToString("F0");
        }
        else
        {
            HealthText.text = "+" + "0";
        }


        if (AmmoText != null && GameObject.Find("Player") != null)
        {
            AmmoText.text = "|" + Player.GetComponent<PlayerController>().getAmmo().ToString();
        }

        if (timeRemaining <= 0)
        {
            YouWin();
        }


    } // End Update()

    void FixedUpdate()
    {
        if (timeRemaining > 0 && Player.GetComponent<Health>().getHealthPoints() > 0.0f)
        {
            timeRemaining -= Time.fixedDeltaTime;
            minutes = (int)(timeRemaining / 60);
            seconds = (timeRemaining % 60);
            TimerText.text = minutes + ":" + seconds.ToString("00");
        }
    }

    public static void GameOver()
    {
        if (gm.GameOverText != null)
        {
            gm.GameOverText.gameObject.SetActive(true);

        }
    } // End GameOver()

    public static void YouWin()
    {
        if (gm.WinText != null)
        {
            gm.WinText.gameObject.SetActive(true);
            gm.Invoke("newLevel", 5.0f);
        }
    }

    [System.Obsolete]
    void newLevel()
    {
        SceneManager.LoadScene("Level_2");
    }
}
