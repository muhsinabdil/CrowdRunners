using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{

    [Header("Sounds")]
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private AudioSource doorHitSound;
    [SerializeField] private AudioSource runnerDieSound;
    [SerializeField] private AudioSource levelCompleteSound;
    [SerializeField] private AudioSource gameOverSound;
    // Start is called before the first frame update
    void Start()
    {

        PlayerDetection.onDoorsHit += PlayDoorHitSound;//! yöntemini dinliyoruz
        GameManager.onGameStateChanged += GameStateChangedCallback;//! oyun durumunu dinliyoruz
        Enemy.onRunnerDied += PlayRunnerDiedSound;//! yöntemini dinliyoruz
    }

    private void OnDestroy()
    {
        PlayerDetection.onDoorsHit -= PlayDoorHitSound;//! yöntemini dinlemeyi bırakıyoruz
        GameManager.onGameStateChanged -= GameStateChangedCallback;//! yöntemini dinlemeyi bırak
        Enemy.onRunnerDied -= PlayRunnerDiedSound;//! Enemy nesnesini yok ettiğimizde dinlemeyi bırakıyoruz
    }

    private void PlayRunnerDiedSound()
    {
        runnerDieSound.Play();
    }

    private void GameStateChangedCallback(GameManager.GameState gameState)
    {
        switch (gameState)
        {
            case GameManager.GameState.GameOver:
                gameOverSound.Play();
                break;
            case GameManager.GameState.LevelComplete:
                levelCompleteSound.Play();
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PlayDoorHitSound()
    {
        doorHitSound.Play();
    }

    public void DisableSounds()
    {
        buttonSound.volume = 0;
        doorHitSound.volume = 0;
        runnerDieSound.volume = 0;
        levelCompleteSound.volume = 0;
        gameOverSound.volume = 0;
    }

    public void EnableSounds()
    {
        buttonSound.volume = 1;
        doorHitSound.volume = 1;
        runnerDieSound.volume = 1;
        levelCompleteSound.volume = 1;
        gameOverSound.volume = 1;
    }
}
