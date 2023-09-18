using System;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif
using Manuki.Character.Status;

namespace Manuki.Input
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Player")]
        [Tooltip("Movement speed of the player")]
        public float movementSpeed = 2.0f;
        public float dashspeed = 6f;
        public float dashcooldowmtime = 5;

        public bool isAttacking = false;

        [SerializeField] public bool enableMove = true;
        [SerializeField] public bool enableAttack = true;


#if ENABLE_INPUT_SYSTEM
        private PlayerInput playerInput;
#endif
        private InputCatcher input;
        private Animator animator;
        private Rigidbody2D body;

        private ManukaStatus status;

        private bool hasAnimator;

        private bool dashcooldown = false;
        private float dashcooldowntimer;

        //        private bool isUsingMoveKeyboard
        //        {
        //            get
        //            {
        //#if ENABLE_INPUT_SYSTEM
        //            // Get PlayerInput Control Scheme as Keyboard and Mouse           
        //#else
        //                return false;
        //#endif
        //            }
        //        }

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
            input = GetComponent<InputCatcher>();
#if ENABLE_INPUT_SYSTEM
            playerInput = GetComponent<PlayerInput>();
#endif
            status = GetComponent<ManukaStatus>();


            hasAnimator = TryGetComponent(out animator);
        }

        private void Start()
        {
            dashcooldowntimer = dashcooldowmtime;
        }

        private void Update()
        {
            hasAnimator = TryGetComponent(out animator);

            Movement();
            Attack();
            Dash();
            DashTimer();
        }
        private void Movement()
        {

            float targetSpeed;
            bool isMoving = false;

            if (input.move != new Vector2(0, 0))
            {
                isMoving = true;
            }

            if (hasAnimator == true && isMoving == true)
                animator.SetBool("moving", true);
            else
                animator.SetBool("moving", false);

            if (enableMove == true)
            {
                if (status != null)
                {
                    targetSpeed = status.maxSpeed * Time.fixedDeltaTime; // * sprinting speed
                    body.MovePosition(body.position + input.move * targetSpeed);
                }
                else
                {
                    targetSpeed = movementSpeed * Time.fixedDeltaTime; // * sprinting speed
                    body.MovePosition(body.position + input.move * targetSpeed);
                }

                Debug.Log($"TargetSpeed = {targetSpeed}");

                Flip();
            }
        }

        private void Attack()
        {
            if (input.attack == true) //When button is press
            {
                if (enableAttack == true)
                {
                    // Play the attack animation
                    // Disallow the player move
                    // Disallow the player to attack
                    DisableMovementAndAttack();
                    animator.SetBool("attacking", true);
                }
                // Collider Appear for the sword, 
                // Whatever the sword touch, it will damage it.


                // Finish swing the sword, let her able to walk again
                // Stop playing the Animation
                // Allow the Player Attack again
                // Finish Attack Animation Event, has embbed into the Animation.
            }

            if (isAttacking)
            {
                animator.SetBool("attacking", true);
            }
        }

        private void Dash()
        {
            if(enableMove)
            {
                if (input.dash == true)
                {
                    if (!dashcooldown)
                    {
                        if (input.move != new Vector2(0, 0))
                        {
                            body.MovePosition(body.position + input.move * dashspeed);
                            dashcooldown = true;
                            dashcooldowntimer = dashcooldowmtime;
                        }
                    }
                }
            }
        }

        private void DashTimer()
        {
            if (dashcooldown)
            {
                dashcooldowntimer -= Time.deltaTime;
            }

            if (dashcooldowntimer <= 0)
            {
                dashcooldowntimer = dashcooldowmtime;
                dashcooldown = false;
            }
        }


        public void FinishAttack() // This is an AniamtionEvent
        {
            input.attack = false;
            EnableMovementAndAttack();
            animator.SetBool("attacking", false);
        }

        public void EnableMovementAndAttack()
        {
            enableMove = true;
            enableAttack = true;
        }

        public void DisableMovementAndAttack()
        {
            enableMove = false;
            enableAttack = false;
        }

        private void DealDamage()
        {
            // This one is a damage counter thingy
            Debug.Log("You have not yet coded DealDamage yet.");


        }

        private void Flip()
        {
            // Get Input.Value A = -1, D = +1 (This one will only affect x value)

            // if x is positive, Manuka is positive then don't do anything
            // if x is negative, Manuka scale is at positive, make Manuka positive value * -1

            Vector2 theScale = transform.localScale;
            if (input.move.x < 0 && theScale.x > 0 || input.move.x > 0 && theScale.x < 0)
            {
                theScale.x *= -1;
                transform.localScale = theScale;
            }
        }
    }
}

