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
<<<<<<< Updated upstream
        CreateIBullet(bulletAmount, false, 0, Vector2.zero, 0, null, 0);
=======
        CreateIBullet(bulletAmount, false, 0, Vector2.zero, 0, null);
>>>>>>> Stashed changes
    }

    //false = Bullet won't activate
    //true = Bullet will be activated
<<<<<<< Updated upstream
    public void CreateIBullet(int amount, bool active, float angle, Vector2 pos, float speed, Rigidbody2D rb, int damage)
=======
    public void CreateIBullet(int amount, bool active, float angle, Vector2 pos, float speed, Rigidbody2D rb)
>>>>>>> Stashed changes
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject newBullet = Instantiate(bulletOb, transform.position, Quaternion.identity, transform);
            BulletScript bs = newBullet.GetComponent<BulletScript>();
            bs.angle = angle;
            bs.startPos = pos;
            bs.speed = speed;
<<<<<<< Updated upstream
            bs.damage = damage;
=======
>>>>>>> Stashed changes
            if (rb != null)
            {
                bs.initAngle = rb.rotation;
            }
            newBullet.SetActive(active);
            bullets.Add(newBullet);
        }
    }
}
