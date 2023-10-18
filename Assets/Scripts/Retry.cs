using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Retry : MonoBehaviour
{
    public AudioClip appropriatesound;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.source.PlayOneShot(appropriatesound);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Level");
        }
    }
}
