using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    float x, y;
    Vector2 _cpPosition;


    public void OnTriggerEnter2D(Collider2D checkPoint)
    {
        if (checkPoint.gameObject.CompareTag("CheckPoint"))
        {
            x = checkPoint.transform.position.x;
            y = checkPoint.transform.position.y;
            _cpPosition = new Vector2(x, y - 3f);

        }

    }



    private void OnCollisionEnter2D(Collision2D killingFloor)
    {
        
        if (killingFloor.gameObject.CompareTag("KillingFloor"))
        {
            gameObject.transform.position = _cpPosition;

        }


    }
}
