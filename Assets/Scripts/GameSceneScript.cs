using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GS.MergerColorSortBall
{
    public class GameSceneScript : MonoBehaviour
    {
        [SerializeField] private GameObject quitMenu;

        public void RetryButtonFunc()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void BackToMainMenu()
        {
            SceneManager.LoadScene(1);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!quitMenu.activeSelf)
                {
                    quitMenu.SetActive(true);
                }
            }
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}