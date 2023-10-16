using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retractor : MonoBehaviour
{
    public bool retracted = false;

    Rigidbody2D myBody;

    Rigidbody2D ropeHolderBody;

    float retractionLerpSpeed = 4f;

    LineRenderer lineRend;

    Vector3[] ropeSegments = new Vector3[9];

    public Transform ropeTetherStart;
    public Transform ropeTetherEnd;




    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();

        lineRend = GetComponent<LineRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

            if (retracted == false)
            {
                retracted = true;

                SoundManager.source.PlayOneShot(SoundManager.soundEffects[2]);
            }

            //transform.position = new Vector3(transform.position.x, 45f, 0);

            ropeHolderBody.isKinematic = true;



        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (retracted == true)
            {
                retracted = false;

                SoundManager.source.PlayOneShot(SoundManager.soundEffects[3]);
            }

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


        //This is where we draw our fancy line using the line renderer!

        ropeHolderBody = transform.GetChild(0).GetComponent<Rigidbody2D>();

        ropeSegments[0] = ropeTetherStart.position;

        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            Transform childWeGet = transform.GetChild(0).GetChild(i);

            if (childWeGet.name != "Little John")
            {

                Debug.Log(1+i);
                ropeSegments[1+i] = childWeGet.position;
            }
        }

        ropeSegments[8] = ropeTetherEnd.position;

        lineRend.positionCount = ropeSegments.Length;
        lineRend.SetPositions(ropeSegments);



    }
}
