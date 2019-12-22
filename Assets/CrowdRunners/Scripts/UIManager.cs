using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private Slider progressBar;
    [SerializeField] private TextMeshProUGUI levelText;
    // Start is called before the first frame update
    void Start()
    {
        progressBar.value = 0f;//! slider value 0 

        gamePanel.SetActive(false); //! oyun panelini en başta pasif yapıyoruz.



        levelText.text = "Level " + (ChunkManager.instance.GetLevel() + 1);//! leveli yazdırıyoruz
    }

    // Update is called once per frame
    void Update()
    {
        UpdateProgressBar();
    }

    public void PlayButtonPressed()
    {

        //! oyun başlar
        //! oyun başlayınca ne olacak
        GameManager.instance.SetGameState(GameManager.GameState.Game);//! Oyun yöneticisinin örneğini çağırır ve setstategameile durumu ayarlar
        menuPanel.SetActive(false);//! pasif
        gamePanel.SetActive(true);//! aktif
    }
    private void UpdateProgressBar()
    {
        if (!GameManager.instance.IsGetState())//! oyun durumunda değilse 
            return;//! false ise boş döner

        float progress = PlayerController.instance.transform.position.z / ChunkManager.instance.GetFinishZ();
        progressBar.value = progress;


    }
}
