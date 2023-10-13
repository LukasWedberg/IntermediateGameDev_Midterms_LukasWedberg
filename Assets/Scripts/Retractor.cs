using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retractor : MonoBehaviour
{
    public bool retracted = false;

    Rigidbody2D myBody;

    Rigidbody2D ropeHolderBody;

    float retractionLerpSpeed = 4f;





    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();

        ropeHolderBody = transform.GetChild(0).GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            retracted = true;

            //transform.position = new Vector3(transform.position.x, 45f, 0);

            ropeHolderBody.isKinematic = true;

        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            retracted = false;

            //transform.position = new Vector3(transform.position.x, 18.4f, 0);

            ropeHolderBody.isKinematic = false;

        }

        if (retracted)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, 45f, retractionLerpSpeed * Time.deltaTime), 0);
        }
        else {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, 18.4f, retractionLerpSpeed * Time.deltaTime), 0);
        }

    }
}
