using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _movementSpeed;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] float _jumpForceX = 1f;
    [SerializeField] float _jumpForceY = 1f;
    [SerializeField] float _fallGravityScale;
    [SerializeField] float _gravityScale;
    float _currentJumpForceX = 1f;
    float _currentJumpForceY = 1f;


    bool _lookingleft = true;
    int _j = 1;

    bool _isJumping;
    float _jumpStartTime;
    private float _jumpTime;
    bool _onGround;






    void Update()
    {

        float movement = Input.GetAxis("Horizontal");
        if (movement > 0)
        {
            _spriteRenderer.flipX = true;
            _lookingleft = true; 
         }
        else if (movement < 0)
        {
            _spriteRenderer.flipX = false;
            _lookingleft = false;
        }

        transform.position += new Vector3(movement, 0, 0) * _movementSpeed * Time.deltaTime;

        

        if (Input.GetButtonUp("Jump") && Mathf.Abs(_rb.velocity.y) < 0.05f) 
        {

            if (_lookingleft)
            {
                _j = 1; 
            }
            else
            {
                _j = -1;
                
            }

            _rb.AddForce(new Vector3(_j * _currentJumpForceX, _currentJumpForceY), ForceMode2D.Impulse);

            _onGround = false;
            
        }
            if (Input.GetButton("Jump") )
        {

            if (_onGround)
            {
                    _isJumping = true;

                _currentJumpForceX += 0.01f;
                _currentJumpForceY += 0.01f;

                if (_currentJumpForceX > _jumpForceX * 3)
                {
                    _currentJumpForceX = _jumpForceX * 3;
                }

                if (_currentJumpForceY > _jumpForceY * 3)
                {
                    _currentJumpForceY = _jumpForceY * 3;
                }
            }

            


        }



    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            
            _onGround = true;
            _isJumping = false;

                _currentJumpForceX = _jumpForceX;
                _currentJumpForceY = _jumpForceY;
            
        }

    }

}
