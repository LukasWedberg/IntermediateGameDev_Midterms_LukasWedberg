using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    float timeAllowed = 300f;

    [SerializeField]
    TMP_Text timeRemainingUI;

    [SerializeField]
    GameObject moneyBag;

    [SerializeField]
    GameObject failureScreen;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeAllowed > 0f)
        {
            timeAllowed -= Time.deltaTime;

            timeRemainingUI.text = Mathf.Round(timeAllowed).ToString();

        }else {
            timeAllowed = 0f;

            Destroy(moneyBag);

            failureScreen.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }





    }
}
