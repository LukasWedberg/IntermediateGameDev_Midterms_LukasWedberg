using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pButton : MonoBehaviour
{
    [SerializeField]
    KeyCode keyToCheck;

    SpriteRenderer renderer;
    Color originalColor;

    Color interactColor = new Color(0.02352941176f, 0.48235294117f, 0.46274509803f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        originalColor = renderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToCheck))
        {
            renderer.color = interactColor;
        }
        else if(Input.GetKeyUp(keyToCheck)){
            renderer.color = originalColor;
        }
    }
}
