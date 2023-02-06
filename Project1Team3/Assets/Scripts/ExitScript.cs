using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace pest
{
    public class ExitScript : MonoBehaviour
    {
       
        public int nextScene = 0;
        public GameObject allEnemiesGoneText;


        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.gameObject.tag == "Player" && allEnemiesGoneText.active == true)
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}
