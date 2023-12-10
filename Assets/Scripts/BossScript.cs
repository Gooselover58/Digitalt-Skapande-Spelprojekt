using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] GameManager gm;
    [SerializeField] int baseHealth;
    public int maxHealth;
    public int health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm.StartBoss(this, baseHealth, "Steve, Destroyer of ponds");
    }

    public void opening()
    {

    }
    void Update()
    {

    }
}
