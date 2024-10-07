using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{

    [SerializeField] Image _image;
    PlayerMovement playerScript;
    float _imageFillSpeed;
    private void Start()
    {
        playerScript = FindObjectOfType<PlayerMovement>();
        _imageFillSpeed = playerScript.jumpChargeSpeed / playerScript.jumpForceX;
    }

    void Update()
    {
        if (playerScript.isJumping)
        { 
            for (float i = playerScript.jumpForceX; i < playerScript.currentJumpForceX; i += playerScript.jumpChargeSpeed)
        {

            _image.fillAmount += _imageFillSpeed * Time.deltaTime;
                
        }

        }
        if (!playerScript.isJumping || !playerScript.onGround)
        {
            _image.fillAmount = 0;
        }
    }
}
