using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] PlayerController pc;
    public float angle;
    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = pc.currentGun.shootPoint.transform.position;
        rb.rotation = angle;
    }
}
