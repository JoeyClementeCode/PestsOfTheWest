using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace pest
{
    public class UIManager : MonoBehaviour
    {
        public int PickaxeCount = 3;
        [SerializeField] private TextMeshProUGUI pickaxeCountText;

        public void UpdateCount()
        {
            PickaxeCount--;
            pickaxeCountText.text = PickaxeCount.ToString();
        }
    }
}
