
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetection : MonoBehaviour
{

    //! Çarpışmaları algılayacak script

    [Header("Elements")]
    [SerializeField] private CrowdSystem crowdSystem;//! crowd systeme erişiyoruz
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DetectDoors();
    }

    private void DetectDoors()
    {
        //! kapıları algılayacak bir fonksiyon yazıyoruz


        //* tespit edilen çarpıştırıcıları tutacak
        //! player etrafında küre oluşturur
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, 1);//! tüm çarpıştırıcıları tutar onları algılar




        for (int i = 0; i < detectedColliders.Length; i++)
        {
            //! çarpıştırıcılar kadar döner


            if (detectedColliders[i].TryGetComponent(out Doors doors))
            {


                //! çarpıştırıcının doors scripti varsa onu alıyor
                //! kapılara temas tespit ediyoruz
                //! 1 kapılara göre konumu alıyoruz
                //! 2 konuma göre işlemi yapıyoruz

                Debug.Log("bazı Kapılara çarptı");


                //! doors scriptinde methotlara ulaşıyoruz bonus type ve miktar alıyoruz
                int bonusAmount = doors.GetBonusAmount(transform.position.x);

                BonusType bonusType = doors.GetBonusType(transform.position.x);


                doors.Disable(); //! kapıyı kapatıyoruz
                crowdSystem.ApplyBonus(bonusType, bonusAmount); //! bonusu uyguluyoruz
            }
            else if (detectedColliders[i].tag == "Finish")
            {
                //! finishe gelmişsek


                PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);//! mevcut levele 1 ekliyoruz kaydediyoruz
                SceneManager.LoadScene(0);//!Sahneyi tekrar yüklüyor

            }
        }
    }
}
