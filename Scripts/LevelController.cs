using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject playerPrefab;
    private void Awake()
    {
        Instantiate(playerPrefab, GameObject.FindGameObjectWithTag("Checkpoint").transform.position,Quaternion.identity);
    }
    void Update()
    {
        
    }
}
