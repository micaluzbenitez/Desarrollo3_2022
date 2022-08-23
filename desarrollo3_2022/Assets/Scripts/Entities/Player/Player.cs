using System.Collections;
using UnityEngine;
using TMPro;

namespace Entities.Player
{
    public class Player : MonoBehaviour
    {
        [Header("Move data"), Tooltip("Horizontal movement speed")]
        public float moveSpeed = 2f;

        [Header("Jump data"), Tooltip("Jump speed")]
        public float jumpUpSpeed = 5f;
        [Tooltip("Multiple down acceleration")]
        public float fallGravityMultiplier = 2f;
        [Tooltip("Number of jumps allowed in the air")]
        public int allowJumpTimesOnAir = 0;

        /// Horizontal input
        private float inputHorizontal = 0;
        /// If the player press the jump key
        private bool jumpPressed = false;
        /// If the player looks to the right or not
        private bool faceRight = true;
        /// If the player touches the ground
        private bool isGrounded = false;
        /// Conteo de los saltos actuales
        private int airJumpCount = 0;

        /// Rigidbody parameter
        private Rigidbody2D rigidBody = null;
        /// Animator parameter
        private Animator animator = null;

        /// <summary>
        /// Initialize private parameters
        /// </summary>
        private void Start()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        /// <summary>
        /// Player's input
        /// </summary>
        private void Update()
        {
            /// Move
            inputHorizontal = Input.GetAxisRaw("Horizontal");

            /// Jump
            if (Input.GetButtonDown("Jump")) jumpPressed = true;
        }

        /// <summary>
        /// Player's movement
        /// </summary>
        private void FixedUpdate()
        {
            Move();
            CheckJump();
            SwitchAnimState();
        }

        /// <summary>
        /// Horizontal movement
        /// </summary>
        private void Move()
        {
            rigidBody.velocity = new Vector2(inputHorizontal * moveSpeed, rigidBody.velocity.y);
            if (inputHorizontal > 0 && !faceRight || inputHorizontal < 0 && faceRight) Flip();
        }

        /// <summary>
        /// Check jump conditions
        /// </summary>
        private void CheckJump()
        {
            if (jumpPressed)
            {
                if (isGrounded) /// Ground jump
                {
                    Jump();
                }
                else
                {
                    if (airJumpCount < allowJumpTimesOnAir) /// Air jump
                    {
                        Jump();
                        airJumpCount++;
                    }
                }
            }

            /// Improve movement
            if (rigidBody.velocity.y < 0) rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallGravityMultiplier - 1) * Time.fixedDeltaTime;
        }

        /// <summary>
        /// Jump
        /// </summary>
        private void Jump()
        {
            rigidBody.velocity = Vector2.up * jumpUpSpeed;
            jumpPressed = false;
            isGrounded = false;
        }

        /// <summary>
        /// Horizontally rotate the player sprite depending on if it goes left or right
        /// </summary>
        private void Flip()
        {
            faceRight = !faceRight;

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        /// <summary>
        /// Update animations
        /// </summary>
        private void SwitchAnimState()
        {
            /// Correr
            if (inputHorizontal == 0) animator.SetBool("Running", false);
            else animator.SetBool("Running", true);

            /// Salto
            animator.SetFloat("SpeedH", Mathf.Abs(rigidBody.velocity.x));
            animator.SetFloat("SpeedV", rigidBody.velocity.y);

            /// Si esta tocando el piso
            animator.SetBool("IsGrounded", isGrounded);
        }

        /// <summary>
        /// Check if the player is colliding with the floor
        /// </summary>
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Floor")
            {
                isGrounded = true;
                airJumpCount = 0;
            }
        }
    }
}