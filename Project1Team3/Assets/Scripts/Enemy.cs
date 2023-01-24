using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pest
{
    public class Enemy : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.CompareTag("Player"))
                Destroy(collision.gameObject);
        } 
    }
}
