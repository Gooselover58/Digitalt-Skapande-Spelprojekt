using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTowardsPlayer : MonoBehaviour
{
    public GameObject boss;
    public GameObject player;
    [SerializeField] GameManager gm;
    [SerializeField] Vector2 offset;

    void Update()
    {
        if (gm.isGameActive)
        {
            //Sätter objektets position vid spelaren
            transform.position = (Vector2)boss.transform.position + offset;
            //Tar musens position, och använder matte för att ta reda på riktningen från objektet till musen
            Vector2 Dir = (Vector2)transform.position - (Vector2)player.transform.position;
            float angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
            //Ändrar riktningen av objektet
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
