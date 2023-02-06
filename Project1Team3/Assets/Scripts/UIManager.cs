using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TMPro;
using UnityEngine;

namespace pest
{
    public class UIManager : MonoBehaviour
    {
        public int PickaxeCount = 3;
        [SerializeField] private TextMeshProUGUI pickaxeCountText;

        //list of all enemies in the scene
        public GameObject[] enemyList;

        public int enemyCount;
        public int maxEnemyCount;

        public TextMeshProUGUI enemyCountText;
        public GameObject allEnemiesGoneText;

        public GameObject progressBar;
        public float barProgress = 1.8f;

        


        // Start is called before the first frame update
        void Start()
        {
            //Scans the scene for enemies,puts them in an array
            enemyList = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemyList.Length == 0)
            {
                Debug.Log("No game objects are tagged with 'Enemy'");
            }

            maxEnemyCount = enemyList.Length;
            enemyCount = maxEnemyCount;

            enemyCountText.text = "Enemies remaining: " + enemyCount + "/" + maxEnemyCount;

        }


        //better to just edit physics object script to call UpdateEnemyCount instead
        private void Update()
        {
            //keeps track of how many enemies are in the scene
            int tempCount = 0;
            for(int i = 0; i < enemyList.Length ; i++ )
            {
                if (enemyList[i] != null)
                {
                    tempCount++;
                }
            }

            enemyCount = tempCount;
            enemyCountText.text = "Enemies remaining: " + enemyCount + "/" + maxEnemyCount;

            if (enemyCount <= 0)
            {
                allEnemiesGoneText.SetActive(true);
            }

            if (barProgress < 1.8)
            {
                barProgress += Time.deltaTime;
            }

            if (Input.GetMouseButtonDown(0) && barProgress >= 1.8f)
            {
                barProgress = 0.0f;
            }

            

            progressBar.transform.localScale = new Vector3(barProgress/1.8f, 1, 1);

            

        }

        public void UpdateCount()
        {
            PickaxeCount--;
            pickaxeCountText.text = PickaxeCount.ToString();
        }

        //maybe call this from physics object script instead of using update
        public void UpdateEnemyCount() 
        {
            enemyCount--;

            //if(enemyCount <= 0)
            //{
                //display element here
              //  enemyCountText.text = "Enemies remaining: " + enemyCount + "/" + maxEnemyCount;
           // }
        }

       
    }
}
