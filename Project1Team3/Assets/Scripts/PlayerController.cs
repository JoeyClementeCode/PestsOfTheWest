using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

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
        private CapsuleCollider2D currentCollider;
        private float horizontalInput;
        
        void Start()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            currentCollider = GetComponent<CapsuleCollider2D>();
        }
        private void Update()
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
        }
        void FixedUpdate()
        {
            rigidBody.velocity = new Vector2(horizontalInput * speed, rigidBody.velocity.y);

            if (IsGrounded() && Input.GetKey(KeyCode.W))
            {
                rigidBody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            }
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
