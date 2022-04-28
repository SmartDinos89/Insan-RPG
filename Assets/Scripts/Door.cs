using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] bool SceneChange;
    
    [SerializeField] string sceneName;

    [SerializeField] Transform warpPos;
    GameObject player;
    PlayerController pc;
    public Animator animator;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(warpPos != null){
                StartCoroutine(Warp(warpPos));
            } else if (SceneChange)
            {
                StartCoroutine(NextLevel(sceneName));
            }
        }
     
    }

    public IEnumerator NextLevel(string name)
    {
        pc.canMove = false;
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(name);
    }

    public IEnumerator Warp(Transform warpPos)
    {
        pc.canMove = false;
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        player.transform.position = warpPos.position;
        animator.Play("FadeIn");
        yield return new WaitForSeconds(.9f);
        pc.canMove = true;


    }
}
