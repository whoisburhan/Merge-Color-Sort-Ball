using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using GS.PuzzleMaster;
using DG.Tweening;

namespace GS.FreeSweeper
{
    public class UI_Manager : MonoBehaviour
    {
        public static UI_Manager Instance { get; private set; }

        [SerializeField] private Button backToMainMenuButton;
        [SerializeField] private Text scoreText;
        [SerializeField] private Text highScoreText;
        [SerializeField] private Outline scoreTextOutline;
        [Header("GameOver Canvas")]
        [SerializeField] private GameObject gameOverCanvas;
        [SerializeField] private Text gameOverCanvasScoreText;
        [SerializeField] private Text gameOverCanvasHighscoreText;
        [SerializeField] private Button retryButton;
        [SerializeField] private Button backToMainMenuFromGameOverCanvasButton;
        [Header("Tutorial")]
        [SerializeField] private GameObject tutorial;

        private void OnEnable()
        {
            GameManager.OnScoreUpdate += UpdateScore;
        }

        private void OnDisable()
        {
            GameManager.OnScoreUpdate -= UpdateScore;
        }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        private void Start()
        {
            InitButton();
            if (GameData.Instance.FreeSwipeGameShowTutorial)
            {
                Time.timeScale = 0f;
                tutorial.SetActive(true);
            }
            else
            {
                gameOverCanvas.SetActive(false);
                UpdateScore(GameManager.Instance.Score);
              //  AdmobManager.Instance.LoadBannerAd();
            }
        }


        public void HideTutorial() 
        {
            tutorial.SetActive(false);
            Time.timeScale = 1f;
            GameData.Instance.FreeSwipeGameShowTutorial = false;
           // AdmobManager.Instance.LoadBannerAd();
        }

        private void InitButton() 
        {
            backToMainMenuButton.onClick.AddListener(() =>
            {
                // AdmobManager.Instance.DestroyBannerAd();
                SceneLoader.Instance.LoadScene("MainMenu");
            });
            backToMainMenuFromGameOverCanvasButton.onClick.AddListener(() =>
            {
                SceneLoader.Instance.LoadScene("MainMenu");
            });
            retryButton.onClick.AddListener(() =>
            {
                SceneLoader.Instance.LoadScene(SceneManager.GetActiveScene().name);
            });
        }


        public void ActivateGameOverCanvas()
        {
          //  AdmobManager.Instance.DestroyBannerAd();

            
            if (GameManager.Instance.Score > GameData.Instance.State.GameStates[(int)GameState.FreeSwipe]) 
            {
                GameData.Instance.State.GameStates[(int)GameState.FreeSwipe] = GameManager.Instance.Score;             
            }
      

            gameOverCanvasScoreText.text = $"Score\n{GameManager.Instance.Score}";
            gameOverCanvasHighscoreText.text = $"Highscore\n{GameData.Instance.State.GameStates[(int)GameState.FreeSwipe]}";
            scoreText.gameObject.SetActive(false);
            highScoreText.gameObject.SetActive(false);
            backToMainMenuButton.gameObject.SetActive(false);
            gameOverCanvas.SetActive(true);

            //AdmobManager.Instance.ShowAd();
        }

        public void UpdateScore(int score)
        {
            scoreText.text = "Score\n" + score.ToString();
            highScoreText.text = score > GameData.Instance.State.GameStates[(int)GameState.FreeSwipe] ? $"Highscore\n{score}" : $"Highscore\n{GameData.Instance.State.GameStates[(int)GameState.FreeSwipe]}";
        }

        public void SetScoreTextColor(Color _color)
        {
            scoreText.color = _color;
            scoreTextOutline.effectColor = _color;
        }
    }
}