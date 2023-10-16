using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagGrabber : MonoBehaviour
{
    SpringJoint2D tether;

    [SerializeField]
    GameObject timerObject;

    [SerializeField]
    GameObject victory;

    // Start is called before the first frame update
    void Start()
    {
        tether = GetComponent<SpringJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.transform.parent != null) {
            if (col.gameObject.transform.parent.gameObject.name == "Better Robin Dood" && tether.enabled == false)
            {
                Debug.Log("BUBUBBUBUBUB");

                tether.enabled = true;

                tether.connectedBody = col.rigidbody;
            }
            else if (col.gameObject.transform.parent.gameObject.name == "Carriage")
            {


                Debug.Log("VROOM VROOM");

                tether.connectedBody = col.rigidbody;

                victory.SetActive(true);

                timerObject.SetActive(false);

            }
        }
    }

}
