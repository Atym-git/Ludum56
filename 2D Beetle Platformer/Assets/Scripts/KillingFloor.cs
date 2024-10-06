using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class KillingFloor : MonoBehaviour
{
    PlayerMovement obj;


    private void Start()
    {
        obj = FindObjectOfType<PlayerMovement>();
    }


    private void OnCollisionEnter2D(Collision2D killingFloor)
    {

        if (killingFloor.gameObject.CompareTag("KillingFloor"))
        {
            gameObject.transform.position = new Vector2 (obj.x, obj.y);


        }

       
    }




}
