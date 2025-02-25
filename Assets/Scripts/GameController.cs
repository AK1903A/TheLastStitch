using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{

    public static GameController instance;

    private static float health = 100;
    private static int maxHealth = 100;
    private static float moveSpeed = 5f;
    private static float fireRate = 0.5f;
    private static float bulletSize = 0.5f;
    public static float Health { get => health; set => health = value; }
    public static int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public static float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public static float FireRate { get => fireRate; set => fireRate = value; }
    public static float BulletSize { get => bulletSize; set => bulletSize = value; }
    public TMP_Text healthText;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //healthText.text = "Health: " + health;
    }
    public void DamagePlayer(int damage)
    {
        health -= damage;
        UpdateHealthText();
        if (Health <= 0)
        {
            KillPLayer();
        }
    }
    public static void HealPLayer(float healAmount)
    {
        health = Mathf.Min(MaxHealth, health + healAmount);
    }
    public static void MoveSpeedChange(float speed)
    {
        moveSpeed += speed;
    }
    public static void FireRateChange(float rate)
    {
        fireRate -= rate;
    }
    public static void BulletSizeChange(float size)
    {
        bulletSize += size;
    }
    private void KillPLayer()
    {
        Debug.Log("Player has died");
    }
    public void UpdateHealthText()
    {
        healthText.text = $"Health: {health}";
    }
}