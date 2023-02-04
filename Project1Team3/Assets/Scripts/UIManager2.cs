using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pest
{
    public class UIManager2 : MonoBehaviour
    {
        //list of all enemies in the scene
        public GameObject[] enemyList;

        public int enemyCount;
        public int maxEnemyCount;

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

        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
