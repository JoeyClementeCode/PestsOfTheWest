using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pest
{
    public class PickaxeThrow : MonoBehaviour
    {
        private Rigidbody2D rb;
        private UIManager ui;
        private Vector2 mousePos;
        private Vector2 lookDir;
        private float angle;
        private Vector3 shootDirection;
        
        [Header("Parameters")]
        public float speed;
        [SerializeField] private GameObject pickaxePrefab;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            ui = GameObject.Find("Main UI").GetComponent<UIManager>();
        }
        
        private void FixedUpdate()
        {
            shootDirection = Input.mousePosition;
            shootDirection.z = 0.0f;
            shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
            shootDirection -= transform.position;

            if (Input.GetKeyDown(KeyCode.Mouse0) && ui.PickaxeCount > 0)
            {
                Throw();
                ui.UpdateCount();
            }
        }

        private void Throw()
        {
            GameObject newPickaxe = Instantiate(pickaxePrefab, transform.position, Quaternion.identity);
            newPickaxe.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);
        }
    }
}
