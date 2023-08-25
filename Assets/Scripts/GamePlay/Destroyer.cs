using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

namespace GS.MergerColorSortBall
{
    public class Destroyer : MonoBehaviour
    {
        private const string MERGE_BALL_HIGHSCORE = "MERGE_BALL_HIGHSCORE";
        public static Destroyer Instance { get; private set; }

        public int Score 
        {
            get 
            {
                return score; 
            }
            set 
            { 
                score = value;
                scoreText.text = score.ToString();
            }
        }

        int score = 0;

        [SerializeField] private GameObject scoreTextGameObject;
        [SerializeField] private GameObject gameOverPanel;

        [Header("Score Text")]
        [SerializeField] private Text scoreText;
        [SerializeField] private Text gameOverScoreText;
        [SerializeField] private Text gameOverHighScoreText;
        [Header("Button")]
        [SerializeField] private Button BackToMainMenuButton;
        [SerializeField] private Button BackToMainMenuFromGameOverButton;
        [SerializeField] private Button RetryFromGameOverButton;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Score = 0;

            BackToMainMenuButton.onClick.AddListener(() => 
            {
                SceneLoader.Instance.LoadScene("MainMenu");
            });
            BackToMainMenuFromGameOverButton.onClick.AddListener(() =>
            {
                SceneLoader.Instance.LoadScene("MainMenu");
            });
            RetryFromGameOverButton.onClick.AddListener(() =>
            {
                SceneLoader.Instance.LoadScene(SceneManager.GetActiveScene().name);
            });
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
                    

                    PlayerPrefs.SetInt(MERGE_BALL_HIGHSCORE, Mathf.Max(score, PlayerPrefs.GetInt(MERGE_BALL_HIGHSCORE, 0)));
                    gameOverScoreText.text = $"Score\n{score}";
                    gameOverHighScoreText.text = $"Highscore\n{Mathf.Max(score, PlayerPrefs.GetInt(MERGE_BALL_HIGHSCORE, 0))}";
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

                    PlayerPrefs.SetInt(MERGE_BALL_HIGHSCORE, Mathf.Max(score, PlayerPrefs.GetInt(MERGE_BALL_HIGHSCORE, 0)));
                    gameOverScoreText.text = $"Score\n{score}";
                    gameOverHighScoreText.text = $"Highscore\n{Mathf.Max(score, PlayerPrefs.GetInt(MERGE_BALL_HIGHSCORE, 0))}";
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