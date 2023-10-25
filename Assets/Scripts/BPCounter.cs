using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BPCounter : MonoBehaviour
{

    [SerializeField]
    TMP_Text mainPointsText;

    [SerializeField]
    TMP_Text pointsToAddText;

    public static int mainPointsInt;

    static int pointsToAddInt = 0;

    static float addPointsTime = 1;
    static float addPointsTimer = 0;

    float targetPointsAddSize;


    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level")
        {
            mainPointsInt = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (addPointsTimer > 0)
        {
            addPointsTimer -= Time.deltaTime;
        }
        else
        {
            if (pointsToAddInt > 0)
            {
                mainPointsInt += pointsToAddInt;
                pointsToAddInt = 0;
            }
        }

        mainPointsText.text = mainPointsInt.ToString();

        if (pointsToAddInt > 0)
        {
            pointsToAddText.text = "+" + pointsToAddInt.ToString();

            targetPointsAddSize = 60 + 7 * addPointsTimer*addPointsTimer*addPointsTimer*addPointsTimer;
        }
        else
        {
            pointsToAddText.text = "";
        }

        pointsToAddText.fontSize = Mathf.Lerp(pointsToAddText.fontSize,targetPointsAddSize,.2f);
        
    }

    public static void AddPoint() {
        pointsToAddInt++;

        addPointsTimer = addPointsTime;
    }
}
