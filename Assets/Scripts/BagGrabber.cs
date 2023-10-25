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

    [SerializeField]
    GameObject tutorialButtons;

    [SerializeField]
    GameObject bagBarrier;


    GameObject robinDood;

    LineRenderer lineRend;

    Vector3[] ropeSegments = new Vector3[2];

    Rigidbody2D myRB;

    [SerializeField]
    ParticleSystem coins;


    public float castDist = 1.5f;

    bool flatbedResting = false;




    // Start is called before the first frame update
    void Start()
    {
        tether = GetComponent<SpringJoint2D>();

        lineRend = GetComponent<LineRenderer>();

        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tether.enabled) {

            ropeSegments[0] = transform.position;
            ropeSegments[1] = robinDood.transform.position;

            lineRend.positionCount = ropeSegments.Length;
            lineRend.SetPositions(ropeSegments);
        }



        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, castDist);
        Debug.DrawRay(transform.position, Vector2.down * castDist, Color.red);

        if (hit.collider != null && hit.transform.name == "Flatbed")
        {
            if (tether.enabled)
            {
                //Drop the bag on the platform, disable tether
                tether.enabled = false;

                //set the front wheel to "dynamic" body type instead of "isKinematic" so that the cart can roll away
                hit.transform.parent.GetChild(1).GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

                WheelJoint2D drivingWheel = hit.transform.GetComponent<WheelJoint2D>();

                drivingWheel.useMotor = true;

                //Destroy(bagBarrier);

                lineRend.positionCount = 0;

                GameManager.victoryAchieved = true;

            }

            flatbedResting = true;
            myRB.angularVelocity /= 1.5f;
            
        }
        else
        {
            flatbedResting = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.transform.parent != null && !flatbedResting) {
            if (col.gameObject.transform.parent.gameObject.name == "Better Robin Dood" && tether.enabled == false)
            {
                Debug.Log("BUBUBBUBUBUB");

                tether.enabled = true;

                tether.connectedBody = col.rigidbody;

                robinDood = col.gameObject;

                SoundManager.source.PlayOneShot(SoundManager.soundEffects[5]);

                Destroy(tutorialButtons);


            }
            else if (col.gameObject.tag == "Ground" && tether.enabled)
            {
                coins.Play();
                SoundManager.source.PlayOneShot(SoundManager.soundEffects[6]);
            }
            
            
            /*
            else
            if (col.gameObject.transform.parent.gameObject.name == "Carriage")
            {


                Debug.Log("VROOM VROOM");

                tether.connectedBody = col.rigidbody;

                victory.SetActive(true);

                timerObject.SetActive(false);

            }
            */



        }

        

    }

}
