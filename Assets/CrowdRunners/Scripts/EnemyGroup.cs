using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{


    [Header("Elements")]
    [SerializeField] private Enemy enemyPrefab;//! enemy
    // Start is called before the first frame update

    [Header("Settings")]
    [SerializeField] private int amount;
    [SerializeField] private float radius;//! dağılımın genişliği
    [SerializeField] private float angle;//! dağılımın açısı farklı şekiller çıkıyor
    void Start()
    {
        GenereateEnemies();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GenereateEnemies()
    {
        for (int i = 0; i < amount; i++)//!Fermat spirali kullanılacak
        {

            Vector3 enemyLocalPosition = GetRunnerLocalPosition(i);//! yerel konum
            Vector3 enemyWordPosition = transform.TransformPoint(enemyLocalPosition);//! yerel konum dünya konumuna çevrildi);
            Instantiate(enemyPrefab, enemyWordPosition, Quaternion.identity, transform);
        }
    }


    private Vector3 GetRunnerLocalPosition(int index)
    {
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * angle * index);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * angle * index);
        return new Vector3(x, 0, z);
    }
}
