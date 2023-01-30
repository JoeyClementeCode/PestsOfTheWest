using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pest
{
    public class PickaxeThrow : MonoBehaviour
    {
        private Rigidbody2D rb;
        private Vector2 mousePos;
        private Vector2 lookDir;
        private float angle;
        private Vector3 shootDirection;

        private bool canThrow = true;
        
        [Header("Parameters")]
        public float speed;
        [SerializeField] private GameObject pickaxePrefab;
        public float throwDelay = 2.0f;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        
        private void FixedUpdate()
        {
            shootDirection = Input.mousePosition;
            shootDirection.z = 0.0f;
            shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
            shootDirection -= transform.position;

            if (Input.GetKeyDown(KeyCode.Mouse0) && canThrow)
            {
                StartCoroutine(Throw());
            }
        }
        
        private IEnumerator Throw()
        {
            GameObject newPickaxe = Instantiate(pickaxePrefab, transform.position, Quaternion.identity);
            newPickaxe.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);
            canThrow = false;
            yield return new WaitForSeconds(throwDelay);
            canThrow = true;
        }
    }
}
