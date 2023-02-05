using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace pest
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private bool Paused;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Paused = !Paused;
            }

            if (Paused == true)
            {
                Time.timeScale = 0;
                EnterMenu();
            }
            else
            {
                Time.timeScale = 1;
                ExitMenu();
            }
        }

        public void EnterMenu()
        {
            pauseMenu.SetActive(true);
        }

        public void ExitMenu()
        {
            pauseMenu.SetActive(false);
            Paused = false;
        }

        ///MenuButtons///

        public void ResumeButton()
        {
            ExitMenu();
        }

        public void RestartButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void QuitButton()
        {
            ExitMenu();
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }
}