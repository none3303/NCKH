using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class TestCam : MonoBehaviour
{
    CinemachineVirtualCamera cam;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        cam = GetComponent<CinemachineVirtualCamera>();
        
    }

    private void Update()
    {
        if(cam != null)
        {
            if (cam.LookAt == null || cam.Follow== null)
            {
                cam.Follow = GameObject.FindGameObjectWithTag("Player").transform;
                cam.LookAt = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }
    }



}
