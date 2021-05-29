using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GS.MergerColorSortBall
{
    public class GameSceneScript : MonoBehaviour
    {
        public void RetryButtonFunc()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void BackToMainMenu()
        {
            SceneManager.LoadScene(1);
        }
    }
}