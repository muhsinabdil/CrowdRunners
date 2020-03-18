using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{


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
        Handheld.Vibrate();//! titreşim
        Debug.Log("Vibrate");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
