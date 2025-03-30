using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Familliar : MonoBehaviour
{
    public float lastFire;
    private GameObject player;
    public FamilliarData familliar;
    private float lastOffsetX;
    private float lastOffsetY;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float shootHor = Input.GetAxis("ShootHorizontal");
        float shootVer = Input.GetAxis("ShootVertical");
        if ((shootHor != 0 || shootVer != 0) && Time.time > lastFire + familliar.fireDelay)
        {
            Shoot(shootHor, shootVer);
            lastFire = Time.time;
        }
        if (horizontal != 0 || vertical != 0)
        {
            float offsetX = (horizontal<0) ? Mathf.Floor(horizontal) : Mathf.Ceil(horizontal);
            float offsetY = (vertical < 0) ? Mathf.Floor(vertical) : Mathf.Ceil(vertical);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, familliar.speed * Time.deltaTime);
            lastOffsetX = offsetX;
            lastOffsetY = offsetY;
        }
        else
        {
            if (!(transform.position.x < lastOffsetX + 0.5f) || !(transform.position.y < lastOffsetY + 0.5f))
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x - lastOffsetX, player.transform.position.y - lastOffsetY), familliar.speed * Time.deltaTime);
            }
        }
    }

    private void Shoot(float x, float y)
    {
        GameObject bullet = Instantiate(familliar.bulletPrefab, transform.position, Quaternion.identity) as GameObject;
        float posX = (x < 0) ? Mathf.Floor(x) * familliar.speed : Mathf.Ceil(x) * familliar.speed;
        float posY = (y < 0) ? Mathf.Floor(y) * familliar.speed : Mathf.Ceil(y) * familliar.speed;
        bullet.GetComponent<Rigidbody2D>().gravityScale = 0;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(posX, posY);
        print("posX: " + posX + " posY: " + posY);
    }
}

