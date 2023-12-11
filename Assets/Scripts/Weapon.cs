using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
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

    void Update()
    {
        if (lr != null && gm.isGameActive)
        {
            Vector2 dir = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(shootPoint.transform.position, -dir, 100, layer);

            if (hit.collider != null)
            {
                DrawLine(shootPoint.transform.position, hit.point);
            }
            else
            {
                DrawLine(shootPoint.transform.position, -dir.normalized * 100);
            }
        }
    }
    public void Shoot() 
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            bool foundBullet = false;
            foreach (GameObject b in bPool.bullets)
            {
                if (!b.activeSelf)
                {
                    foundBullet = true;
                    BulletScript bs = b.GetComponent<BulletScript>();
                    bs.angle = spread;
                    bs.startPos = shootPoint.transform.position;
                    bs.speed = bulletSpeed;
                    bs.initAngle = pivotRb.rotation;
                    bs.damage = damage;
                    bs.piercing = piercing;
                    b.SetActive(true);
                    break;
                }
            }
            if (!foundBullet)
            {
                bPool.CreateIBullet(1, true, spread, shootPoint.transform.position, bulletSpeed, pivotRb, damage, piercing, false);
            }
        }
        ShotEffects();
    }

    void ShotEffects()
    {
        shootSound.Play();
        shootPar.Play();
        shootAnim.SetTrigger("ShootAnim");
    }

    void DrawLine(Vector2 startPos, Vector2 endPos)
    {
        lr.positionCount = 2;
        lr.SetPosition(0, startPos);
        lr.SetPosition(1, endPos);
    }
}