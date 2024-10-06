using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{



    public Vector2 cpPosition;
    [SerializeField] int _cpIndex;




    private void OnTriggerEnter2D(Collider2D player)
    {

        if (player.gameObject.CompareTag("Player"))
        {

            var obj = FindObjectOfType<PlayerMovement>();




            if (_cpIndex > obj.prevCpIndex)
            {
                obj.x = player.transform.position.x;
                obj.y = player.transform.position.y;

                cpPosition = new Vector2(obj.x, obj.y);
                obj.prevCpIndex = _cpIndex;

            }
        }
        
    }
}
