using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    [SerializeField] float size;
    [SerializeField] float speed;
    [SerializeField] Vector3 startPos;

    void Start()
    {
        transform.position = startPos;
    }
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= -size)
        {
            transform.position = startPos;
        }
    }
}
