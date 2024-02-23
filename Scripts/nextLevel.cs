using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    private bool canComplete;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (canComplete)
            {
                collision.gameObject.GetComponent<PlayerController>().OnLock();
                //DontDestroyOnLoad(collision.gameObject);
                Invoke("LoadNextMap", 2f);
                collision.gameObject.GetComponent<PlayerController>().Unlock();
            }
        }
    }
    private void LoadNextMap()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

    }
    private void Update()
    {
        GameObject[] keys =GameObject.FindGameObjectsWithTag("Key");
        if(keys.Length > 0 )
        {
            canComplete = false;
        }
        else
        {
            canComplete=true;
        }
    }
}
