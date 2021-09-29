using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadAudioManager : MonoBehaviour
{
    // Variables //
    public AudioSource reloadSource = null;
    public PlayerController playerCon = null;
    private bool cooldown;

    // Start is called before the first frame update
    void Awake()
    {
        reloadSource = GetComponent<AudioSource>();
        PlayerController playerCon = GetComponentInParent<PlayerController>();
        cooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.R)) && cooldown == false || playerCon.getAmmo() == 0)
        {
            reloadSource.Play();
            Invoke("ResetCooldown", 3.0f);
            cooldown = true;
        }
    }

    void ResetCooldown()
    {
        cooldown = false;
    }
}
