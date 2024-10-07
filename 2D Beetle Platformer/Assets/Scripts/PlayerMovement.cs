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
    [SerializeField] public float jumpForceX;
    [SerializeField] public float jumpForceY;
    [SerializeField] float _fallGravityScale;
    [SerializeField] float _gravityScale;
    [SerializeField] public float jumpChargeSpeed;
    [SerializeField] public float currentJumpForceX = 1f;
    [SerializeField] public float currentJumpForceY = 1f;
    [SerializeField] Animator _animator;
    [SerializeField] public int prevCpIndex = 0;
    [SerializeField] public float x, y;
    [SerializeField] AudioSource _audioSourceWalk;
    [SerializeField] AudioSource _audioSourceJump;

    int _jumpingSide = 1;

    public bool isJumping;
    float _jumpStartTime;
    private float _jumpTime;
    public bool onGround;



    void Update()
    {

        if (onGround && !Input.GetButton("Jump"))
        {
            float movement = Input.GetAxis("Horizontal");
            if (movement > 0)
            {
 
                if (!_audioSourceWalk.isPlaying)
                {
                _audioSourceWalk.Play();

                }

                _spriteRenderer.flipX = true;
               
                _animator.SetBool("Idle", false);
                _animator.SetBool("Walking", true);

            }
            else if (movement < 0)
            {
                _spriteRenderer.flipX = false;
               
                _animator.SetBool("Idle", false);
                _animator.SetBool("Walking", true);

                if (!_audioSourceWalk.isPlaying)
                {    
                _audioSourceWalk.Play();
                    
                }

            }
            else
            {
                if (_audioSourceWalk.isPlaying)
                {
                    _audioSourceWalk.Stop();

                }

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

            onGround = false;
   
            _audioSourceJump.Play();
            _rb.AddForce(new Vector3(_jumpingSide * currentJumpForceX, currentJumpForceY), ForceMode2D.Impulse);


        }
            if (Input.GetButton("Jump") )
        {

            if (onGround)
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

                isJumping = true;

                currentJumpForceX += jumpChargeSpeed;
                currentJumpForceY += jumpChargeSpeed;

                if (currentJumpForceX > jumpForceX * 3)
                {
                    currentJumpForceX = jumpForceX * 3;
                }

                if (currentJumpForceY > jumpForceY * 3)
                {
                    currentJumpForceY = jumpForceY * 3;
                }
            }

            
        }



    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            
            onGround = true;
            isJumping = false;

                currentJumpForceX = jumpForceX;
                currentJumpForceY = jumpForceY;
            
        }

    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);

    }


}
