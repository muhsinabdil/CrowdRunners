
using UnityEngine;
using TMPro;

public class CrowdCounter : MonoBehaviour
{


    [Header("CrowdCounter")]
    [SerializeField] private TextMeshPro crowdCounterText;
    [SerializeField] private Transform runnerParent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        crowdCounterText.text = runnerParent.childCount.ToString();
    }
}
