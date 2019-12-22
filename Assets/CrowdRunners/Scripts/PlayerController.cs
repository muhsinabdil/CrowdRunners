using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    // Start is called before the first frame update
    [Header("Elements")]
    [SerializeField] private CrowdSystem crowdSystem;//! crowdSystem scriptini çağırıyoruz
    [SerializeField] private PlayerAnimator playerAnimator;//! animatoru alır
    [Header("Settings")] //! inspectorde gruplama yapmak için kullanılır
    [SerializeField] private float moveSpeed;//! ileri hareket hızı
    [SerializeField] private float roadWidth;//! yol genişliği
    private bool canMove;//! hareket edebilir mi? default false

    [Header("Control")]//! inspectorde gruplama yapmak için kullanılır
    [SerializeField] private float slideSpeed;//! sağa sola kaydırma hızı

    private Vector3 clickedScreenPosition; //! ekran konumu
    private Vector3 clickedPlayerPosition; //! player konumu

    private void Awake()
    {

        //! player yönteici tek olmalı varsa yok olacak
        if (instance != null)
        {
            Destroy(gameObject);//! playerı yok ediyoruz
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        GameManager.onGameStateChanged += GameStateChangedCallBack;//! etkinlik aboneliğini yapıyoruz
    }

    private void OnDestroy()
    {
        //! nesne kaybolunca çalışır
        GameManager.onGameStateChanged -= GameStateChangedCallBack;//! etkinlik aboneliğini iptal ediyoruz
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)//! hareket edebilir true olunca hareket edebilecek
        {
            MoveForward();
            ManageControl();
        }


    }

    private void GameStateChangedCallBack(GameManager.GameState gameState)
    {
        //! oyun durumunu alıyoruz

        switch (gameState)
        {
            case GameManager.GameState.Menu:
                StopMovig();
                break;
            case GameManager.GameState.Game:
                StartMovig();
                break;
            case GameManager.GameState.LevelComplete:
                StopMovig();
                break;
            case GameManager.GameState.GameOver:
                StopMovig();
                break;
            default:
                break;
        }

    }
    private void StartMovig()
    {

        canMove = true;//! hareket edebilir
        playerAnimator.Run();
    }

    private void StopMovig()
    {

        canMove = false;//! hareket edemez
        playerAnimator.Idle();
    }


    private void MoveForward()
    {
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;


    }
    private void ManageControl()
    {
        if (Input.GetMouseButtonDown(0))
        { //! dokunmaları alıyoruz

            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPosition = transform.position;
        }
        else if (Input.GetMouseButton(0))
        {

            //! tıklama konumu ile ekrandaki mevcut konum farkını hesaplıyoruz
            float xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;

            xScreenDifference /= Screen.width;//! ekranın genişliğine bölüyoruz
            xScreenDifference *= slideSpeed;//! sağa sola kaydırma hızıyla çarpıyoruz

            //!iptal ediyoruz
            // transform.position = clickedPlayerPosition + Vector3.right * xScreenDifference;//! playerın konumuna ekliyoruz
            //! yukarıdaki işlemde mouse tıklanınca player duruyor sadece sağa sola gidiyor bunu engellemek için aşağıdakileri yapacağız
            //! sağ sol hareketi için x değerini değiştirmeliyiz.
            Vector3 position = transform.position; //!  1 => position değişkeni oluşturuyoruz player positionunu atıyoruz
            position.x = clickedPlayerPosition.x + xScreenDifference;//! 2 =>sadece x değeri ile oynuyoruz
            position.x = Mathf.Clamp(position.x, -roadWidth / 2 + crowdSystem.GetCrowdRadius(), roadWidth / 2 - crowdSystem.GetCrowdRadius());//! 3=> x değerini min ve max olarak sınırlıyoruz sol sınıra kuşucuların yarıçapını ekliyoruz ve sağ sınırdan koşucuların yarı çapını çıkarıyoruz
            transform.position = position; //! 3 oluşturulan positionu playera atıyoruz

        }


    }
}
