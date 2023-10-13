using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftLeg : MonoBehaviour
{
    float legPower = 40f;

    Rigidbody2D myBody;


    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {


            myBody.AddForce(new Vector3(2, 3, 0) * legPower, ForceMode2D.Impulse);
        }
    }
}
