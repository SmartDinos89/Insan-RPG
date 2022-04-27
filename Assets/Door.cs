using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] bool SceneChange;
    
    [SerializeField] string sceneName;

    [SerializeField] Transform warpPos;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(!SceneChange){
                collision.transform.position = warpPos.position;
            } else if (SceneChange)
            {
                ChangeScene(sceneName);
            }
        }
     
    }

    void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    

}
