using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace pest
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject MenuMain;
        public GameObject CreditsMenu;

        public void StartButton()
        {
            SceneManager.LoadScene(1);
        }

        public void CreditsButton()
        {
            MenuMain.SetActive(false);
            CreditsMenu.SetActive(true);
            //SceneManager.LoadScene(6);
        }

        public void BackButton()
        {
            MenuMain.SetActive(true);
            CreditsMenu.SetActive(false);
        }

        public void QuitButton()
        {
            Application.Quit();
        }

        public void MenuVisit()
        {
            SceneManager.LoadScene(0);
        }
        
    }
}
