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
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        
        private void FixedUpdate()
        {
            lookDir = (mousePos - rb.position).normalized;
            angle = Mathf.Atan2(lookDir.y ,lookDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0,0,angle);
        }
    }
}
