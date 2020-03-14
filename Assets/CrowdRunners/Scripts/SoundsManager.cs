using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{

    [Header("Sounds")]
    [SerializeField] private AudioSource doorHitSound;
    // Start is called before the first frame update
    void Start()
    {

        PlayerDetection.onDoorsHit += PlayDoorHitSound;//! yöntemini dinliyoruz

    }

    private void OnDestroy()
    {
        PlayerDetection.onDoorsHit -= PlayDoorHitSound;//! yöntemini dinlemeyi bırakıyoruz
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PlayDoorHitSound()
    {
        doorHitSound.Play();
    }
}
