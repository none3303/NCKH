using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if(collision.gameObject.tag == "Player")
            {
                collision.GetComponent<PlayerController>().OnLock();
                collision.GetComponent<PlayerController>().Dead();

                Invoke("Respawn", 1f);
                
            }
        }
    }
    private void Respawn()
    {
        LevelController lvlC = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
        GameObject player = Instantiate(lvlC.playerPrefab, GameObject.FindGameObjectWithTag("Checkpoint").transform.position, Quaternion.identity);
        player.GetComponent<PlayerController>().Unlock();
    }
}
