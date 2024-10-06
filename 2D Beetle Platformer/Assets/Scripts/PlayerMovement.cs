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
    [SerializeField] float _jumpForceX;
    [SerializeField] float _jumpForceY;
    [SerializeField] float _fallGravityScale;
    [SerializeField] float _gravityScale;
    [SerializeField] float _jumpChargeSpeed;
    float _currentJumpForceX = 1f;
    float _currentJumpForceY = 1f;
    [SerializeField] Animator _animator;


    int _jumpingSide = 1;

    bool _isJumping;
    float _jumpStartTime;
    private float _jumpTime;
    bool _onGround;




    void Update()
    {

        if (_onGround && !Input.GetButton("Jump"))
        {
            float movement = Input.GetAxis("Horizontal");
            if (movement > 0)
            {
                _spriteRenderer.flipX = true;
               
                _animator.SetBool("Idle", false);
                _animator.SetBool("Walking", true);
            }
            else if (movement < 0)
            {
                _spriteRenderer.flipX = false;
               
                _animator.SetBool("Idle", false);
                _animator.SetBool("Walking", true);
            }
            else
            {
                _animator.SetBool("Idle", true);
                _animator.SetBool("Walking", false);
            }

            transform.position += new Vector3(movement, 0, 0) * _movementSpeed * Time.deltaTime;
        }
        

        if (Input.GetButtonUp("Jump") && Mathf.Abs(_rb.velocity.y) < 0.05f)
        {
            _animator.SetBool("JumpingRelease", true);
            _animator.SetBool("MidAir", true);
            _animator.SetBool("Idle", false);
            _animator.SetBool("Jumping", false);

            _onGround = false;

            _rb.AddForce(new Vector3(_jumpingSide * _currentJumpForceX, _currentJumpForceY), ForceMode2D.Impulse);
            
            
            
        }
            if (Input.GetButton("Jump") )
        {

            if (_onGround)
            {
                _animator.SetBool("Walking", false);
                _animator.SetBool("Jumping", true);

                if (_spriteRenderer.flipX)
                {
                    _jumpingSide = 1;
                }
                else if (!_spriteRenderer.flipX)
                {
                    _jumpingSide = -1;

                }

                _isJumping = true;

                _currentJumpForceX += _jumpChargeSpeed;
                _currentJumpForceY += _jumpChargeSpeed;

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
