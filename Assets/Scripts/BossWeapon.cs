using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public GameObject shootPoint;
    private AudioSource shootSound;
    [SerializeField] GameManager gm;
    [SerializeField] ParticleSystem shootPar;
    [SerializeField] Rigidbody2D pivotRb;
    [SerializeField] Animator shootAnim;
    public float coolDown;
    public int price;
    [SerializeField] bool piercing;
    [SerializeField] int damage;
    [SerializeField] float spread;
    [SerializeField] float bulletSpeed;
    [SerializeField] int bulletAmount;
    [SerializeField] BulletPool bPool;
    [SerializeField] LayerMask layer;
    private LineRenderer lr;
    private Camera cam;

    void Start()
    {
        shootSound = GetComponent<AudioSource>();
        shootPoint = transform.GetChild(0).gameObject;
        shootPar = transform.GetChild(1).gameObject.GetComponent<ParticleSystem>();
        lr = GetComponent<LineRenderer>();
        cam = Camera.main;
    }

    public void Shoot()
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            bPool.CreateIBullet(1, true, spread, shootPoint.transform.position, bulletSpeed, pivotRb, damage, piercing, true);
        }
        ShotEffects();
    }

    void ShotEffects()
    {
        shootSound.Play();
        shootPar.Play();
        shootAnim.SetTrigger("ShootAnim");
    }
}