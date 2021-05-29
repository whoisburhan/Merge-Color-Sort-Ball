using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GS.MergerColorSortBall
{
    public class Destroyer : MonoBehaviour
    {
        public static Destroyer Instance { get; private set; }

        public int score = 0;

        [SerializeField] private GameObject scoreTextGameObject;
        [SerializeField] private GameObject gameOverPanel;

        [Header("Score Text")]
        [SerializeField] private Text scoreText;
        [SerializeField] private Text gameOverScoreText;

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            scoreText.text = score.ToString();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            Ball _ball = col.GetComponent<Ball>();

            if (_ball != null)
            { 
                if (_ball.IsDetectable && !Spawner.Instance.IsGameOver)
                {
                    Spawner.Instance.IsGameOver = true;
                    scoreTextGameObject.SetActive(false);
                    gameOverScoreText.text = score.ToString();
                    gameOverPanel.SetActive(true);

                    if (AudioManager.Instance != null)
                    {
                        AudioManager.Instance.AudioChangeFunc(0, 2);
                    }
                }
            }
        }

        private void OnTriggerStay2D(Collider2D col)
        {
            Ball _ball = col.GetComponent<Ball>();

            if (_ball != null)
            {
                if (_ball.IsDetectable && !Spawner.Instance.IsGameOver)
                {
                    Spawner.Instance.IsGameOver = true;
                    scoreTextGameObject.SetActive(false);
                    gameOverScoreText.text = score.ToString();
                    gameOverPanel.SetActive(true);

                    if (AudioManager.Instance != null)
                    {
                        AudioManager.Instance.AudioChangeFunc(0, 2);
                    }
                }
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            Ball _ball = col.GetComponent<Ball>();

            if (_ball != null)
            {
                if (!_ball.IsDetectable)
                {
                    _ball.IsDetectable = true;
                }
            }
        }
    }
}