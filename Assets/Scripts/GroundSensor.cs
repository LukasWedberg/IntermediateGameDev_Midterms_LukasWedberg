using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{

    public bool canJump = true;

    [SerializeField]
    Transform rightLeg;

    [SerializeField]
    Transform leftLeg;

    Rigidbody2D rightLegBody;
    Rigidbody2D leftLegBody;

    float legPower = 40f;

    // Start is called before the first frame update
    void Start()
    {
        rightLegBody = rightLeg.gameObject.GetComponent<Rigidbody2D>();
        leftLegBody = leftLeg.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (canJump)
        {

            if (Input.GetKeyDown(KeyCode.P))
            {
                leftLegBody.AddForce(new Vector3(2, 3, 0) * legPower, ForceMode2D.Impulse);

                canJump = false;
            }
            else if(Input.GetKeyDown(KeyCode.O))
            {
                rightLegBody.AddForce(new Vector3(-2, 3, 0) * legPower, ForceMode2D.Impulse);

                canJump = false;
            }

        }

    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.transform.parent != null)
        {
            if (col.gameObject.transform.parent.gameObject.name == "Ground" || col.gameObject.transform.parent.gameObject.name == "Carriage")
            {
                Debug.Log("Robin, you're grounded!");

                canJump = true;
            }
        }



    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.transform.parent != null)
        {
            if (col.gameObject.transform.parent.gameObject.name == "Ground" || col.gameObject.transform.parent.gameObject.name == "Carriage")
            {
                Debug.Log("Robin, you're grounded!");

                canJump = true;
            }
        }

        
    }

}
