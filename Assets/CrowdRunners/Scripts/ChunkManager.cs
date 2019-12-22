
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    // Start is called before the first frame update


    public static ChunkManager instance;//! chunkmanagerın örneğini alıyoruz tek olmalı

    [Header("Elements")]
    [SerializeField] private LevelSO[] levels;

    //[SerializeField] private Chunk[] chunksPrefabs;
    // [SerializeField] private Chunk[] levelChunks;
    private GameObject finishLine;//! bitişin konumunu almak için yardımcı olacak bu sayede slidera etki edeceğiz


    public void Awake()
    {//! instance varsa onu yok ediyoruz
     //! çünkü parça yöneticisi tek olmalı

        if (instance != null)
        {
            Destroy(gameObject);//! parça yöneticisini yok ediyoruz
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {

        GenerateLevel();

        finishLine = GameObject.FindWithTag("Finish");//! bitişi alıyoruz
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void GenerateLevel()
    {
        //! seviyeye göre uygulayacağız
        int currentLevel = GetLevel();
        currentLevel = currentLevel % levels.Length;//! seviye sayısını alıyoruz
        LevelSO level = levels[currentLevel];


        CreateLevel(level.chunks);
    }

    private void CreateLevel(Chunk[] levelChunks)
    {

        Vector3 chunkPosition = Vector3.zero;

        for (int i = 0; i < levelChunks.Length; i++)//! levelchunks içindeki parçalar kadar döner
        {


            Chunk chunkToCreate = levelChunks[i];//! parçaları sırayla alıyoruz 

            if (i > 0)
            {

                Debug.Log(i + "ilk Okuma:" + chunkPosition.z);
                chunkPosition.z += chunkToCreate.GetLength() / 2;//!  parçanın  uzunluğunun yarısını alıyoruz
                Debug.Log(i + "orta Okuma:" + chunkPosition.z);
            }

            Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);
            //!parçalar farklı olduğu için uzunlukların yarısı kadar ileriye gidiyoruz
            chunkPosition.z += chunkInstance.GetLength() / 2;

            Debug.Log(i + "Son Okuma z:" + chunkPosition.z);

        }

    }

    /* //!burası iptal oldu LevelSO geldi
        private void CreateOrderedLevel()
        {

            Vector3 chunkPosition = Vector3.zero;

            for (int i = 0; i < levelChunks.Length; i++)//! levelchunks içindeki parçalar kadar döner
            {


                Chunk chunkToCreate = levelChunks[i];//! parçaları sırayla alıyoruz 

                if (i > 0)
                {

                    Debug.Log(i + "ilk Okuma:" + chunkPosition.z);
                    chunkPosition.z += chunkToCreate.GetLength() / 2;//!  parçanın  uzunluğunun yarısını alıyoruz
                    Debug.Log(i + "orta Okuma:" + chunkPosition.z);
                }

                Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);
                //!parçalar farklı olduğu için uzunlukların yarısı kadar ileriye gidiyoruz
                chunkPosition.z += chunkInstance.GetLength() / 2;

                Debug.Log(i + "Son Okuma z:" + chunkPosition.z);

            }

        }

        private void CreateRandomLevel()
        {

            Vector3 chunkPosition = Vector3.zero;//! ilk değeri 0 atıyoruz
            Debug.Log("start Okuma chunk:" + chunkPosition);
            for (int i = 0; i < 10; i++)
            {
                //! MANTIK
                //! parçaları oluştururken parçaların uzunlukları farklı olduğu için 
                //! ilk nesneden sonra diğer nesnelerin uzunluklarının yarısı kadar toplayarak ileriye gidiyoruz
                //! her turda 2 defa toplama var. 
                //! 1.si önceki nesnenin yarısı 
                //! 2.si ise yeni nesnenin yarısı

                Chunk chunkToCreate = chunksPrefabs[Random.Range(0, chunksPrefabs.Length)];//! parçaların içinden random birini seçiyoruz 

                if (i > 0)
                {

                    Debug.Log(i + "ilk Okuma:" + chunkPosition.z);
                    chunkPosition.z += chunkToCreate.GetLength() / 2;//!  parçanın  uzunluğunun yarısını alıyoruz
                    Debug.Log(i + "orta Okuma:" + chunkPosition.z);
                }

                Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);
                //!parçalar farklı olduğu için uzunlukların yarısı kadar ileriye gidiyoruz
                chunkPosition.z += chunkInstance.GetLength() / 2;

                Debug.Log(i + "Son Okuma z:" + chunkPosition.z);

            }
        } */
    public float GetFinishZ()
    {
        return finishLine.transform.position.z;
    }


    public int GetLevel()
    {
        return PlayerPrefs.GetInt("level", 0);//! default değeri 1
    }
}
