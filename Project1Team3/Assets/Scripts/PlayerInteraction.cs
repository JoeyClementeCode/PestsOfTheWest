using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pest
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        private SoundManager sound;

        private void Start()
        {
            sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.transform.gameObject.CompareTag("Interact"))
            {
                //spriteRenderer.material.shader = Shader.Find("Shader Graphs/OutlineShader");
                
                if (Input.GetKey(KeyCode.Space))
                {
                    Destroy(other.gameObject);
                    sound.SetAudio("Interact");
                }
            }
        }
        
        /*private void OnTriggerExit2D(Collider2D other)
        {
            spriteRenderer.material.shader = Shader.Find("Universal Render Pipeline/2D/Sprite-Lit-Default");
        }*/
    }
}
