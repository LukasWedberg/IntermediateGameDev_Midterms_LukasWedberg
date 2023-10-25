using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeDisplay : MonoBehaviour
{
    [SerializeField]
    TMP_Text displayText;


    // Start is called before the first frame update
    void Start()
    {
        displayText.text = GameManager.timeStoppedAt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
