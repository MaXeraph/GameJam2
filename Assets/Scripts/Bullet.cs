using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 5;
    public float bulletSpeed = 1f;
    public bool playerBullet = true; // true if bullet was shot by player, false otherwise


    public static void Create(Vector3 position, Vector3 direction, float bulletSpeed, int damage, bool playerBullet)
    {
        GameObject newObject = Instantiate(Resources.Load("Bullet")) as GameObject;
        newObject.transform.position = position;
        newObject.transform.forward = direction;
        Bullet bulletComponent = newObject.GetComponent<Bullet>();
        bulletComponent.damage = damage;
        bulletComponent.bulletSpeed = bulletSpeed;
        bulletComponent.playerBullet = playerBullet;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * bulletSpeed * SpeedManager.bulletSpeedScaling * Time.deltaTime;
    }

    void OnTriggerEnter(Collider c) {
        Stats statsComponent = c.gameObject.GetComponent<Stats>();
        if (statsComponent) {
            if (c.gameObject.tag == "Player" && playerBullet == false) {
                statsComponent.currentHealth -= damage;
                SpeedManager.updateSpeeds(statsComponent.currentHealth / statsComponent.maxHealth);
            }
            else if  (c.gameObject.tag == "Enemy" && playerBullet == true) {
                statsComponent.currentHealth -= damage;
            }
        }
        Destroy(this.gameObject);
    }
}