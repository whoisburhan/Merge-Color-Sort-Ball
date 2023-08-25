using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MergeBall_And_FreeSwipe_MainMenu
{
    public class SeleectGamePanel : MonoBehaviour
    {
        [SerializeField] private Button FreeSwipe;
        [SerializeField] private Button MergeBall;

        private void Start()
        {
            FreeSwipe.onClick.AddListener(() => 
            {
                SceneLoader.Instance.LoadScene("FreeSwipe");
            });

            MergeBall.onClick.AddListener(() =>
            {
                SceneLoader.Instance.LoadScene("MergeBall");
            });
        }
    }
}