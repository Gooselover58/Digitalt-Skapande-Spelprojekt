using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletPool : MonoBehaviour
{
    public List<GameObject> bullets = new List<GameObject>();
    [SerializeField] GameObject bulletOb;
    [SerializeField] int bulletAmount;

    void Start()
    {
        CreateIBullet(bulletAmount, false, 0, Vector2.zero, 0, null, 0);
    }

    //false = Bullet won't activate
    //true = Bullet will be activated
    public void CreateIBullet(int amount, bool active, float angle, Vector2 pos, float speed, Rigidbody2D rb, int damage)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject newBullet = Instantiate(bulletOb, transform.position, Quaternion.identity, transform);
            BulletScript bs = newBullet.GetComponent<BulletScript>();
            bs.angle = angle;
            bs.startPos = pos;
            bs.speed = speed;
            bs.damage = damage;
            if (rb != null)
            {
                bs.initAngle = rb.rotation;
            }
            newBullet.SetActive(active);
            bullets.Add(newBullet);
        }
    }
}
