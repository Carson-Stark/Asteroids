using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{

    SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    //[HideInInspector]
    public bool isWrappingX;
    public bool isWrappingY;

    float buffer = 0.1f;

    // Update is called once per frame
    void Update()
    {

        if (!renderer.isVisible)
        {
            Vector2 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
            Vector2 newPos = transform.position;

            if (!isWrappingX && (viewportPos.x > 1 || viewportPos.x < 0))
            {
                if (transform.position.x < 0)
                    newPos.x = -transform.position.x - buffer;
                if (transform.position.x > 0)
                    newPos.x = -transform.position.x + buffer;

                isWrappingX = true;
            }

            if (!isWrappingY && (viewportPos.y > 1 || viewportPos.y < 0))
            {
                if (transform.position.y < 0)
                    newPos.y = -transform.position.y - buffer;
                if (transform.position.y > 0)
                    newPos.y = -transform.position.y + buffer;

                isWrappingY = true;
            }

            transform.position = newPos;
        }
        else
        {
            isWrappingX = false;
            isWrappingY = false;
        }
    }
}
