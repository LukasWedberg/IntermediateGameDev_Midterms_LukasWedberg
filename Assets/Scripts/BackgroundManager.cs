using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField]
    Transform switchingSpot;

    [SerializeField]
    Transform camera;

    [SerializeField]
    GameObject forestHolder;


    [SerializeField]
    GameObject towerHolder;

    public bool forestActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (camera.position.x < switchingSpot.position.x)
        {
            if (forestActive != true)
            {
                forestActive = true;

                forestHolder.SetActive(true);

                towerHolder.SetActive(false);
            }
        }
        else
        {
            if (forestActive == true)
            {
                forestActive = false;

                forestHolder.SetActive(false);

                towerHolder.SetActive(true);
            }
        }
    }
}
