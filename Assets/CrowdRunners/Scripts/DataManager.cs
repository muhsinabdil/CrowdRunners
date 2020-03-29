using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{

    [Header("Coin Texts")]
    [SerializeField] private Text[] coinTexts;


    private int coins;

    void Awake()
    {
        coins = PlayerPrefs.GetInt("coins", 0);

    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateCoinsTexts();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateCoinsTexts()
    {
        foreach (Text coinText in coinTexts)
        {
            coinText.text = coins.ToString();
        }
    }
}
