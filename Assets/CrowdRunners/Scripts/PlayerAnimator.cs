using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private Transform runnersParent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Run()
    {

        for (int i = 0; i < runnersParent.childCount; i++)
        {

            Transform runner = runnersParent.GetChild(i);

            Animator runnerAnimator = runner.GetComponent<Animator>(); //!  runnerın animatorunu alıyoruz
            runnerAnimator.Play("Run");//! runnerın animatoruna run triggerı gönderiyoruz
        }
    }
    public void Idle()
    {
        for (int i = 0; i < runnersParent.childCount; i++)
        {

            Transform runner = runnersParent.GetChild(i);

            Animator runnerAnimator = runner.GetComponent<Animator>(); //!  runnerın animatorunu alıyoruz
            runnerAnimator.Play("Idle");//! runnerın animatoruna run triggerı gönderiyoruz
        }
    }
}
