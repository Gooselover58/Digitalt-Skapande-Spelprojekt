using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] Vector3 startPos;
    [SerializeField] GameManager gm;
    [SerializeField] int baseHealth;
    public int maxHealth;
    public int health;

    void OnEnable()
    {
        transform.position = startPos;
        rb = GetComponent<Rigidbody2D>();
        gm.StartBoss(this, "Steve, Destroyer of ponds");
    }

    public void opening()
    {
        while (transform.position.x > 6)
        {
            transform.Translate(Vector2.left * Time.deltaTime * 3);
        }
    }
    void Update()
    {

    }
}
