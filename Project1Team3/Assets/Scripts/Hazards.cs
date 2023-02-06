using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pest
{
    public class Hazards : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("Enemy"))
            {
                if (collision.transform.CompareTag("Player"))
                {
                    Destroy(collision.gameObject);
                    PlayerDeath.PlayerDead();
                }
                
                Destroy(collision.gameObject);
            }

        }
    }
}
