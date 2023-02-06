using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace pest
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Parameters")]
        [SerializeField] private float speed = 5.0f;

        [SerializeField] private float jumpHeight = 10.0f;

        [Header("Ground Checking")] 
        [SerializeField] private LayerMask layerMask;
        public float extraDistance = 0.1f;

        // Components and Random Variables
        private Rigidbody2D rigidBody;
        private BoxCollider2D currentCollider;
        private float horizontalInput;
        private SoundManager sound;
        [SerializeField] private Animator animator;

        void Start()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            currentCollider = GetComponent<BoxCollider2D>();
            sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        }
        
        private void Update()
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");

            if (horizontalInput < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (horizontalInput > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        
        
        void FixedUpdate()
        {
            rigidBody.velocity = new Vector2(horizontalInput * speed, rigidBody.velocity.y);

            if (IsGrounded() && Input.GetKey(KeyCode.W))
            {
                rigidBody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                sound.SetAudio("Jump");
            }
            
            animator.SetFloat("velocityX", Mathf.Abs(rigidBody.velocity.x));
            animator.SetFloat("velocityY", rigidBody.velocity.y);
            animator.SetBool("isGrounded", IsGrounded());
        }
        
        private bool IsGrounded()
        {
            RaycastHit2D raycastHit2D = Physics2D.Raycast(currentCollider.bounds.center, Vector2.down, currentCollider.bounds.extents.y + extraDistance, layerMask);
            Color rayColor;
            if (raycastHit2D.collider != null)
            {
                rayColor = Color.green;
            }
            else
            {
                rayColor = Color.red;
            }
            
            Debug.DrawRay(currentCollider.bounds.center, Vector2.down * (currentCollider.bounds.extents.y + extraDistance), rayColor);
            return raycastHit2D.collider != null;
        }
    }
}
