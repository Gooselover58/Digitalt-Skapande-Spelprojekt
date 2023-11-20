using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //GetAxisRaw inneh�ller ett v�rde som antingen �r mellan -1 och 1
        //V�rdet �kar n�r man trycker upp, och minskar n�r man trycker ner
        float y = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(0, y);
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
