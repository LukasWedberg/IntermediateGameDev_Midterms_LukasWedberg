using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VictoryManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text bPointsText;

    // Start is called before the first frame update
    void Start()
    {
        bPointsText.text = BPCounter.mainPointsInt.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
