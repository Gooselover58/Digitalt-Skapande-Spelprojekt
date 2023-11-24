using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTowardsMouse : MonoBehaviour
{
    public Camera cam;
    public GameObject player;
    [SerializeField] Vector2 offset;
    [SerializeField] float clampRot;

    void Update()
    {
        //Sätter objektets position vid spelaren
        transform.position = (Vector2)player.transform.position + offset;
        //Tar musens position, och använder matte för att ta reda på riktningen från objektet till musen
        Vector2 mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 Dir = mouse - (Vector2)transform.position;
        float angle = Mathf.Clamp(Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg, -clampRot, clampRot);
        //Ändrar riktningen av objektet
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
