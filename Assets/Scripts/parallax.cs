using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public float scrollSpeed;

    [SerializeField]
    Transform camera;

    Camera camComponent;

    Sprite ourSprite;

    float spriteWidth;

    Vector3 cameraPreviousPos;
    
    // Start is called before the first frame update
    void Start()
    {
        ourSprite = GetComponent<SpriteRenderer>().sprite;

        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;

        camComponent = camera.gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        float camPosDelta = cameraPreviousPos.x - camera.position.x;

        transform.position += new Vector3(camPosDelta * scrollSpeed, 0, 0);

        cameraPreviousPos = camera.position;


        checkPositionReset();
    }

    //Every once in a while we'll have to move the tiled object back a bit to maintain the infinite scrolling illusion! This checks if it's time yet.
    void checkPositionReset() {

        float camHeight = 2f * 11.76f;

        float camWidth = 16f/10f * camHeight;
        

        if (Mathf.Abs(transform.position.x - camera.position.x) > spriteWidth/2f-camWidth/2f)
        {
            transform.position += new Vector3((spriteWidth/3) * Mathf.Sign(camera.position.x-transform.position.x) , 0,0);
        }
    }

}
