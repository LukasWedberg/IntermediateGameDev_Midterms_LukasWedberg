using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject overheadRail;

    float timeAllowed = 240f;

    [SerializeField]
    TMP_Text timeRemainingUI;

    bool gameOver = false;

    public static bool victoryAchieved = false;

    [SerializeField]
    Image screenShroud;

    [SerializeField]
    Transform happyHorsey;
    
    float shroudAlpha = 0;

    float shroudFadeSpeed = 1f;

    public static string timeStoppedAt;

    [SerializeField]
    AudioSource sillyMusic;

    // Start is called before the first frame update
    void Start()
    {
        victoryAchieved = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Altering the timer
        if (timeAllowed > 0f)
        {
            if (victoryAchieved == false)
            {


                timeAllowed -= Time.deltaTime;

                string extraZero = "";

                if ((Mathf.Ceil(timeAllowed) % 60) < 10)
                {
                    extraZero = "0";
                }

                string firstPart = " ";

                if ((Mathf.Ceil((timeAllowed + 1) / 60) - 1) > 0)
                {
                    firstPart = (Mathf.Ceil((timeAllowed + 1) / 60) - 1).ToString();
                }

                timeRemainingUI.text = firstPart + " : " + extraZero + (Mathf.Ceil(timeAllowed) % 60).ToString();
            }
            else if(victoryAchieved == true)
            {
                sillyMusic.volume = Mathf.Lerp(sillyMusic.volume,0, 0.2f * Time.deltaTime);
            }
        }
        else
        {
            if (!gameOver) {
                Destroy(overheadRail);
                gameOver = true;
            }


        }

        if (gameOver)
        {

            shroudAlpha = Mathf.Lerp(shroudAlpha, 1, shroudFadeSpeed * Time.deltaTime);

            screenShroud.color = new Color(0.09803921568f, 0.15686274509f, 0.20784313725f, shroudAlpha);

            if (shroudAlpha > .999)
            {
                SceneManager.LoadScene("Bad Ending");
            }
        }
        else if (victoryAchieved && happyHorsey.position.x < -64)
        {
            shroudAlpha = Mathf.Lerp(shroudAlpha, 1, shroudFadeSpeed * Time.deltaTime);

            screenShroud.color = new Color(1, 1, 1, shroudAlpha);

            if (shroudAlpha > .999)
            {
                timeStoppedAt = timeRemainingUI.text;

                SceneManager.LoadScene("Happy Ending");
            }
        }

    }
}
