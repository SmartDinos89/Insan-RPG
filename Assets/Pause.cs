using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool paused = false;
    [SerializeField]private GameObject pauseMenu;
    private void Update() {
        if(Input.GetButtonDown("Cancel"))
        {
            if(!paused)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
            else{
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
            paused = !paused;
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        paused = false;
        Time.timeScale = 1f;
    }
}
