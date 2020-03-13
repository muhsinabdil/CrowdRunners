
using System;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{


    //! bu sistemde fermat spirali kullanılıyor

    [Header("Elements")]

    [SerializeField] private PlayerAnimator playerAnimator;//!script
    [SerializeField] private Transform runnersParent;//! runner parent nesne içinde runners lar var onlara erişmek için kullanacağız
    [SerializeField] private GameObject runnerPrefab;
    [Header("Settings")]
    [SerializeField] private float radius;//! dağılımın genişliği
    [SerializeField] private float angle;//! dağılımın açısı farklı şekiller çıkıyor
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //!eğer oyun durumu değil ise return dönüyoruz burada amaç sürekli sorgulamasın
        if (!GameManager.instance.IsGameState())//! burada oyun durumundamı diye bakıyoruz
            return;

        PlaceRunners();
        if (runnersParent.childCount <= 0)//! koşucu bitmiş ise
        {
            GameManager.instance.SetGameState(GameManager.GameState.GameOver);//! oyun durumunu game over yapıyoruz
        }

    }

    private void PlaceRunners()
    {
        for (int i = 0; i < runnersParent.childCount; i++)
        {
            Vector3 childLocalPosition = GetRunnerLocalPosition(i);
            runnersParent.GetChild(i).localPosition = childLocalPosition;

        }
    }

    private Vector3 GetRunnerLocalPosition(int index)
    {
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * angle * index);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * angle * index);
        return new Vector3(x, 0, z);
    }

    public float GetCrowdRadius()
    {
        return radius * Mathf.Sqrt(runnersParent.childCount);//!  kalabalığın yarıçapını hesaplıyoruz
    }

    public void ApplyBonus(BonusType bonusType, int bonusAmount)
    {
        switch (bonusType)
        {
            case BonusType.Addition:
                //! kalabalığa ekleme yapacak
                AddRunners(bonusAmount);
                break;

            case BonusType.Product:
                //! kalabalığa ekleme yapacak

                int runnersToAdd = (runnersParent.childCount * bonusAmount) - runnersParent.childCount;//! kalabalığın çocuk sayısını alıyoruz çarpıyoruz  çocuk sayısını çıkarıyoruz
                AddRunners(runnersToAdd);
                break;
            case BonusType.Difference:
                //! kalabalıktan çıkarma yapacak
                RemoveRunners(bonusAmount);
                break;
            case BonusType.Division:
                //! kalabalığı bölecek
                int runnersToRemove = runnersParent.childCount - (runnersParent.childCount / bonusAmount);//! kalabalığın çocuk sayısını alıyoruz bölüyoruz ve çocuk sayısından çıkarıyoruz
                RemoveRunners(runnersToRemove);
                break;

        }
    }

    private void AddRunners(int bonusAmount)
    {
        //! AddRunners kalabalığa ekleme yapacak


        for (int i = 0; i < bonusAmount; i++)
        {
            GameObject runner = Instantiate(runnerPrefab, runnersParent);


            // runner.transform.localPosition = GetRunnerLocalPosition(runnerParent.childCount - 1);
        }
        playerAnimator.Run();//! yeni doğanlarda koşacak bu olmaz ise koşmuyorlar
    }
    private void RemoveRunners(int amount)
    {
        if (amount > runnersParent.childCount)

            amount = runnersParent.childCount;

        int runnersAmount = runnersParent.childCount;
        for (int i = runnersAmount - 1; i >= runnersAmount - amount; i--)//! 1 elemana kadar azalması için 
        {
            Transform runnerToDestroy = runnersParent.GetChild(i);//! son elemanı alıyoruz
            runnerToDestroy.SetParent(null);//! son elemanın parentını null yapıyoruz
            Destroy(runnerToDestroy.gameObject);//! son elemanı yok ediyoruz
        }


    }
}
