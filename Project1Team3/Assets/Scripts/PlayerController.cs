using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pest
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed = 5.0f;
        private Rigidbody2D rigidBody;
        
        // Start is called before the first frame update
        void Start()
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");

            rigidBody.velocity += new Vector2(horizontalInput * speed * Time.deltaTime, rigidBody.velocity.y);
        }
    }
}
