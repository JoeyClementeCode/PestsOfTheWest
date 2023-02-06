using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace pest
{
    public class PlayerDeath : MonoBehaviour
    {
        public static void PlayerDead()
        {
            SceneManager.LoadScene(1);
        }
    }
}
