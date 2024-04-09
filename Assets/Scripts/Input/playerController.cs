using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{

    private PlayerControls playerControls;

    private Vector2 inputVector;
    Animator playerAnimator;
    Rigidbody2D playerRigidBody;
    SpriteRenderer playerSpriteRenderer;
    public float moveSpeed;
    public float jumpHeight;

    [SerializeField] Transform groundCheck;
    [SerializeField] Transform groundCheckL;
    [SerializeField] Transform groundCheckR;

    //State variables
    Vector2 direction = Vector2.zero;
    bool isGrounded;
    float isJumping;
    float isFiring;
    enum animationList
    {
        Mech_Idle,
        Mech_Walk,
        Mech_Special,
        Mech_Jump,
        Mech_Attack

    };


    void Awake()
    {
        playerControls = new PlayerControls();
        playerAnimator = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void FixedUpdate()
    {

        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;

        }
        else
        {
            isGrounded = false;

        }

        //! Get Input from directional controls

        if (direction.x >= 0.80)
        {
            playerRigidBody.velocity = new Vector2(moveSpeed, playerRigidBody.velocity.y);
            if (isGrounded && isJumping == 0)
                playerAnimator.Play(animationList.Mech_Walk.ToString());
            playerSpriteRenderer.flipX = false;
        }
        if (direction.x <= -0.80)
        {
            playerRigidBody.velocity = new Vector2(-moveSpeed, playerRigidBody.velocity.y);
            if (isGrounded && isJumping == 0)
                playerAnimator.Play(animationList.Mech_Walk.ToString());
            playerSpriteRenderer.flipX = true;
        }

        if (isJumping == 1 && isGrounded)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpHeight);
            playerAnimator.Play(animationList.Mech_Jump.ToString());
            isJumping = 0;
        }
        if (isFiring == 1 && isGrounded)
        {
            playerAnimator.Play(animationList.Mech_Attack.ToString());
            isFiring = 0;

        }
        else if (playerRigidBody.velocity.x == 0 && isGrounded)
        {

            playerAnimator.Play(animationList.Mech_Idle.ToString());
        }


    }
    private void OnJump(InputValue _value)
    {
        isJumping = _value.Get<float>();

    }
    private void OnFire(InputValue _value)
    {
        isFiring = _value.Get<float>();

    }

    private void OnMove(InputValue _value)
    {
        direction = _value.Get<Vector2>();
    }

    private void OnSpecial()
    {
        Debug.Log("Special");
    }
}
