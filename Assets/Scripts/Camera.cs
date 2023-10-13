using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform transformWeFollow;

    float lerpSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(Mathf.Lerp(transform.position.x, transformWeFollow.position.x, lerpSpeed), transform.position.y, -10);
        
    }
}
