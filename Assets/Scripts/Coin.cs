using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Coin : MonoBehaviour
{

    public Vector3 rotationAngles = new Vector3(0, 360, 0); // Rotation around the Y-axis by 360 degrees
    public float duration = 2f; // Time to complete one rotation
    public GameObject pickupEffect;
   
    void Start()
    {
        // Rotate the object infinitely
        transform.DORotate(rotationAngles, duration, RotateMode.FastBeyond360)
                 .SetLoops(-1, LoopType.Restart) // -1 loops means infinite looping
                 .SetEase(Ease.Linear); // Optional: Smooth the rotation
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        // Zarracha effekti
        if (pickupEffect != null)
        {
            Instantiate(pickupEffect, transform.position, Quaternion.identity);
        }

        if (col.gameObject.name == "Player")
        {
            col.gameObject.GetComponent<Controller>().IncreaseCoin();
            // ovoz
            gameObject.SetActive(false);
            // effect
           
        }
        



    }



}
