using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class acornCounter : MonoBehaviour
{
    int acornCount;
    [SerializeField] TextMeshProUGUI text;
    private void Start()
    {
        acornCount = GameObject.FindGameObjectsWithTag("Key").Length;
    }
    void Update()
    {
        int currentAcorn = GameObject.FindGameObjectsWithTag("Key").Length;
        text.text =(acornCount-  currentAcorn) + " / " + acornCount;
    }
}
