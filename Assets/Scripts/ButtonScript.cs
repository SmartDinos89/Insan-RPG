using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public Animator animatior;
    public void ChangeScene(string name)
    {
        Time.timeScale = 1f;
        StartCoroutine(NextLevel(name));
    }

    public void StopPlay()
    {
        Time.timeScale = 1f;
        StartCoroutine(StopPlaying());
    }

    public IEnumerator NextLevel(string name)
    {
        animatior.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(name);
    }

    public IEnumerator StopPlaying()
    {
        animatior.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }
}
