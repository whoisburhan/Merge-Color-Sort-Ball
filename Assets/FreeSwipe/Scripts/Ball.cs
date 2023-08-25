using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GS.FreeSweeper
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip scoreSoundClip;
        [SerializeField] private AudioClip gameOverSoundClip;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Tiles"))
            {
                GameManager.Instance.ScorePoint();
                audioSource.PlayOneShot(scoreSoundClip);
            }

            if (col.CompareTag("Bomb"))
            {
                
                UI_Manager.Instance.ActivateGameOverCanvas();
                GameManager.Instance.GameOverEffects();
                audioSource.PlayOneShot(gameOverSoundClip);
                DOTween.KillAll();
                this.gameObject.SetActive(false);
            }
        }
    }
}