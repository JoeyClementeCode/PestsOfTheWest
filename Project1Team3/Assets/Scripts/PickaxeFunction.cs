using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pest
{
    public class PickaxeFunction : MonoBehaviour
    {
        public float pickaxeDestroyTime = 2.5f;
        
        private void Start()
        {
            Destroy(gameObject, pickaxeDestroyTime);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Throwable"))
            {
                Destroy(col.gameObject);
            }
        }
    }
}
