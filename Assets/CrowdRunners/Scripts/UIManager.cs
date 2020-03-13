using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject levelCompletePanel;
    [SerializeField] private Slider progressBar;
    [SerializeField] private TextMeshProUGUI levelText;
    // Start is called before the first frame update
    void Start()
    {
        progressBar.value = 0f;//! slider value 0 

        gamePanel.SetActive(false); //! oyun panelini en başta pasif yapıyoruz.
        gameOverPanel.SetActive(false); //! game over panelini en başta pasif yapıyoruz.



        levelText.text = "Level " + (ChunkManager.instance.GetLevel() + 1);//! leveli yazdırıyoruz

        GameManager.onGameStateChanged += GameStateChangedCallback;//! oyun durumunu dinliyoruz
    }

    private void OnDestroy()
    {

        //! start içinde oyun durumuna abonelik yapmıştık 
        //! nesne yok olduğunda bu abonelikten çıkıyoruz

        GameManager.onGameStateChanged += GameStateChangedCallback;//! dinlemeyi bıraktık
    }


    // Update is called once per frame
    void Update()
    {
        UpdateProgressBar();//! bu method ile ilerleme progresini güncelliyoruz
    }

    private void GameStateChangedCallback(GameManager.GameState gameState)//! oyun durumunu alan methodu yarattık
    {
        //! oyun durumunu kalabalık yöneticisinden değiştiriyoruz
        //
        switch (gameState) //! oyun durumuna göre yapılacak işlemler
        {
            case GameManager.GameState.Menu:
                // ShowMenu();
                break;
            case GameManager.GameState.Game:
                //  ShowGame();
                break;
            case GameManager.GameState.LevelComplete:
                ShowLevelComplete();//! level tamamlandı panel aktif ettik
                break;
            case GameManager.GameState.GameOver:
                ShowGameOver();//! game over panel aktif ettik
                break;
            default:
                break;
        }


    }
    public void PlayButtonPressed()
    {

        //! oyun başlar
        //! oyun başlayınca ne olacak
        GameManager.instance.SetGameState(GameManager.GameState.Game);//! Oyun yöneticisinin örneğini çağırır ve setstategameile durumu ayarlar
        menuPanel.SetActive(false);//! pasif
        gamePanel.SetActive(true);//! aktif
    }

    public void RetryButtonPressed()
    {
        //! sahneyi tekrar yükleyecek SceneManagement kütüphanesi gerekir
        SceneManager.LoadScene(0);
    }

    public void ShowGameOver()
    {

        //! oyun manager state yönetimine abone olmak gerek bunu start ta yaptık

        gamePanel.SetActive(false);//! Oyun panelini pasif yapıyoruz
        gameOverPanel.SetActive(true);//! Game over paneli aktif yapıyoruz
    }
    public void ShowLevelComplete()
    {

        //! oyun manager state yönetimine abone olmak gerek bunu start ta yaptık

        gamePanel.SetActive(false);//! Oyun panelini pasif yapıyoruz
        levelCompletePanel.SetActive(true);//! level complete paneli aktif yapıyoruz
    }
    private void UpdateProgressBar()
    {
        if (!GameManager.instance.IsGameState())//! oyun durumunda değilse 
            return;//! false ise boş döner

        float progress = PlayerController.instance.transform.position.z / ChunkManager.instance.GetFinishZ();
        progressBar.value = progress;


    }
}
