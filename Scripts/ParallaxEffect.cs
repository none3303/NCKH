using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField]private Transform camTrans;
    private Vector3 latecamPos;
    private float textureUnitSizeX;

    [SerializeField] private Vector2 parallaxEffectMultiplier;
    private void Start()
    {
        //camTrans = Camera.main.transform;
        latecamPos = camTrans.localPosition;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture  = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }
    private void FixedUpdate()
    {
        Vector3 deltaMovement = camTrans.position - latecamPos;
        transform.position -= new Vector3(deltaMovement.x* parallaxEffectMultiplier.x,deltaMovement.y*parallaxEffectMultiplier.y,0);
        latecamPos = camTrans.position;

        if (Mathf.Abs(camTrans.position.x - transform.position.x ) >= textureUnitSizeX*5)
        {
            float offsetX = (camTrans.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(camTrans.position.x+ offsetX, transform.position.y);
        }
    }
}
