using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//! bonus type her yerde kullanabiliyoruz
public enum BonusType
{
    Addition, Difference, Product, Division
}

public class Doors : MonoBehaviour
{


    //! toplanacak mı çıkarılacak mı bölecek mi çarpacak mı bunları enum içinde tutuyoruz

    //* TODO:  burada ürün seçtirebilirmiyiz ???? 

    [Header("Elements")]
    [SerializeField] private SpriteRenderer rightDoorRenderer;
    [SerializeField] private SpriteRenderer leftDoorRenderer;

    [SerializeField] private TextMeshPro rightDoorText;
    [SerializeField] private TextMeshPro leftDoorText;
    [SerializeField] private Collider collider;
    [Header("Settings")]
    [SerializeField] private BonusType rightDoorBonusType;//! select button oluyor
    [SerializeField] private int rightDoorBonusAmount;//! kapı değeri
    [SerializeField] private BonusType leftDoorBonusType;//! select button oluyor
    [SerializeField] private int leftDoorBonusAmount;//! kapı değeri

    [SerializeField] private Color bonusColor;//! ödül rengi
    [SerializeField] private Color penaltyColor;//! ceza rengi
    // Start is called before the first frame update
    void Start()
    {
        ConfigureDoors();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ConfigureDoors()
    { //! kapıları yapılandıracak bir fonksiyon yazıyoruz


        switch (rightDoorBonusType)//! daha önce if ti  daha iyi  oldu.
        {

            //! sağ kapıyı yapılandıracak 

            case BonusType.Addition:

                //! kapı bonus kapısı ise
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "+" + rightDoorBonusAmount;
                break;
            case BonusType.Difference:

                //! kapı ceza kapısı ise
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "-" + rightDoorBonusAmount;
                break;
            case BonusType.Product:
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "x" + rightDoorBonusAmount;
                break;
            case BonusType.Division:

                //! kapı ceza kapısı ise
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "/" + rightDoorBonusAmount;
                break;
        }





        switch (leftDoorBonusType)//! daha önce if ti  daha iyi  oldu.
        {

            //! sağ kapıyı yapılandıracak 

            case BonusType.Addition:

                //! kapı bonus kapısı ise
                //! kapı bonus kapısı ise
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "+" + leftDoorBonusAmount;
                break;
            case BonusType.Difference:

                //! kapı ceza kapısı ise
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "-" + leftDoorBonusAmount; ;
                break;
            case BonusType.Product:
                //! kapı bonus kapısı ise
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "x" + leftDoorBonusAmount;
                break;
            case BonusType.Division:

                //! kapı ceza kapısı ise
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "/" + leftDoorBonusAmount; ;
                break;
        }



    }

    public int GetBonusAmount(float xPosition)
    {
        //! bonus miktarı dönüyoruz
        if (xPosition > 0)
        {
            //! sağ kapı ise 

            return rightDoorBonusAmount;
        }
        else
        {
            //! sol kapı ise 

            return leftDoorBonusAmount;
        }
    }

    public BonusType GetBonusType(float xPosition)
    {
        //! bonus tipi dönüyoruz

        if (xPosition > 0)
        {
            //! sağ kapı ise
            return rightDoorBonusType;

        }
        else
        {
            //! sol kapı ise
            return leftDoorBonusType;
        }




    }

    public void Disable()
    {
        //! kapının colliderını kapatıyoruz
        collider.enabled = false;

    }
}
