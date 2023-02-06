using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pest
{
    public class PickaxeFunction : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject, 4.0f);
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
