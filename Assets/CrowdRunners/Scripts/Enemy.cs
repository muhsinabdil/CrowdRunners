using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    enum State { Idle, Running }//Düşman durumları için


    [Header("Settings")]
    [SerializeField] private float searchRadius;//! arama yarıçapı. bu playerı aradığı çap
    [SerializeField] private float moveSpeed;//! hareket hızı
    private State state;//! durum için

    private Transform targetRunner;//! hedef runner

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ManageState();//! fonksiyonunu sürekli çalıştırıyoruz
    }

    private void ManageState()
    {
        switch (state)
        {
            case State.Idle://! bekleme durumu
                SearchForTarget();//! arama fonksiyonu
                break;
            case State.Running://! koşma durumu
                RunTowardsTarget(); //! hedefe koşma fonksiyonu
                break;

        }
    }
    private void SearchForTarget()
    {
        //! enemy objesinin posizyonunda bir alan oluşturuyoruz. 
        //!bu alanın yarıçapı searchRadius.
        //!bu alan içindeki colliderları döndürüyoruz
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, searchRadius);

        for (int i = 0; i < detectedColliders.Length; i++)
        {
            //! dönen colliderların içinde player var mı diye bakıyoruz
            if (detectedColliders[i].TryGetComponent(out Runner runner))//! dönen colliderların içinde runner var mı diye bakıyoruz
            {
                if (runner.IsTarget())//! bu runnerı başka bir enemy objesi tarafından hedef alınmış mı diye bakıyoruz
                {
                    continue;//! eğer hedef alınmışsa döngüye devam ediyoruz başka bir runnera bakıyoruz
                }
                runner.SetTarget(true);//! eğer hedef alınmamışsa bu runnerı hedef alıyoruz
                targetRunner = runner.transform;//! hedefimiz bu runner oluyor.
                StartRunningTowardsTarget();
            }
            //! player yoksa idle durumuna geçiyoruz
            state = State.Idle;
        }

    }
    private void StartRunningTowardsTarget()
    {
        state = State.Running;//! enemy durumunu değiştirdik
        GetComponent<Animator>().Play("Run");
    }
    private void RunTowardsTarget()
    {
        if (targetRunner == null)
            return;

        transform.position = Vector3.MoveTowards(transform.position, targetRunner.position, Time.deltaTime * moveSpeed);//! enemy objesini hedefe doğru hareket ettiriyoruz

        //! distance 2 konum arası mesafeyi döner 
        if (Vector3.Distance(transform.position, targetRunner.position) < 0.1f)//! 0.1den küçükse
        {
            //! enemy objesi hedefe ulaştıysa
            Destroy(targetRunner.gameObject);//! runner ölüyor

            Destroy(gameObject);//! Enemy obj yok edildi

        }

    }


}
