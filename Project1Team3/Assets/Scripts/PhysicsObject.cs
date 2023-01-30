using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pest
{
    public class PhysicsObject : MonoBehaviour
    {
        private Rigidbody2D rb;
        public Vector2 currentVelocity;
        
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            currentVelocity = rb.velocity;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.transform.CompareTag("Enemy") && (currentVelocity.x > 0 || currentVelocity.x < 0 || currentVelocity.y > 0 || currentVelocity.y < 0))
            {
                Destroy(col.gameObject);
            }
        }
    }
}
