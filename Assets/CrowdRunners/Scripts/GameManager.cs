using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public static GameManager instance;//! singeltona dönüştürmek için


    public enum GameState { Menu, Game, LevelComplete, GameOver } //! oyun durumları

    private GameState gameState;//! oyun durumunu tutacak

    public static Action<GameState> onGameStateChanged;//! oyun durumunu değiştirecek
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            //! başka bir oyun yöneticisi var ise
            Destroy(gameObject);//! bu oyun yöneticisini yok et

        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState; //! playe basınca game durumunu çağıracak
        //! oyun durumunu ayarlayacak

        onGameStateChanged?.Invoke(gameState);//! bu şekilde ypamaz isek hata alabiliriz ?.invoke
        switch (gameState)
        {
            case GameState.Menu:
                Debug.Log("Menu");
                break;
            case GameState.Game:
                Debug.Log("Game");
                break;
            case GameState.LevelComplete:
                Debug.Log("LevelComplete");
                break;
            case GameState.GameOver:
                Debug.Log("GameOver");
                break;
            default:
                break;
        }
    }

    public bool IsGetState()
    {
        return gameState == GameState.Game;//! oyun durumunu döndürür
    }
}
