using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{

    [Header("Settings")]
    private bool haptics;//! unityde vibration managerda 3 noktada debug açık bu sayede bunu görebiliyoruz


    // Start is called before the first frame update
    void Start()
    {
        PlayerDetection.onDoorsHit += Vibrate;//! ondoorshit olayını dinliyoruz
                                              //  Enemy.onRunnerDied += Vibrate;//! 
        GameManager.onGameStateChanged += GameStateChangedCallback;//! oyun durumunu dinliyoruz
    }


    private void OnDestroy()
    {
        PlayerDetection.onDoorsHit -= Vibrate;//! ondoorshit olayını dinlemeyi bırakıyoruz
                                              //  Enemy.onRunnerDied -= Vibrate;//! enemy yok olunca dinlemeyi bırakıyoruz
        GameManager.onGameStateChanged -= GameStateChangedCallback;//! oyun durumunu dinlemeyi bıraktık
    }
    private void GameStateChangedCallback(GameManager.GameState state)
    {
        switch (state)
        {
            case GameManager.GameState.GameOver:
                Vibrate();
                break;
            case GameManager.GameState.LevelComplete:
                Vibrate();
                break;
            default:
                break;
        }
    }

    private void Vibrate()
    {
        if (haptics)
            Handheld.Vibrate();//! titreşim
        Debug.Log("Vibrate");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisableHaptics()
    {
        haptics = false;
    }

    public void EnableHaptics()
    {
        haptics = true;
    }
}
