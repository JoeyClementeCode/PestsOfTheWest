using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pest
{
    public class PlayerInteraction : MonoBehaviour
    {
        private void OnTriggerStay2D(Collider2D other)
        {
            if (Input.GetKey(KeyCode.Space) && other.transform.gameObject.CompareTag("Interact"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
