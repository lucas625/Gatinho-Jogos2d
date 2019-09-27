using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D GroundCollider;
    private float GroundHorizontalLength;


    // Start is called before the first frame update
    void Start()
    {
        GroundCollider = GetComponent<BoxCollider2D>();
        GroundHorizontalLength = GroundCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -GroundHorizontalLength)
        {
            RepositionBackground();
        }
    }

    // moves the background
    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(GroundHorizontalLength * GameController.instance.GetNumberOfBackgrounds(), 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }

}
