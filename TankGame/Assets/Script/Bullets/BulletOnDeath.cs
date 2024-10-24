using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOnDeath : NewBulletController
{

    protected override void Explode()
    {
        base.Explode();
        for (int i = 0; i < stats.amountOfDeathBullets; i++)
        {
            GameObject bullet = Instantiate(stats.deathBulletStats.bulletPrefab,transform.position + Vector3.up,transform.rotation);
            NewBulletController controller = bullet.GetComponent<NewBulletController>();
            controller.stats = stats.deathBulletStats;

            
            Rigidbody2D rigidB = bullet.GetComponent<Rigidbody2D>();
            rigidB.velocity = gameObject.GetComponent<Rigidbody2D>().velocity * 2;
            rigidB.AddForce(Vector3.up * stats.deathBulletStats.speed, ForceMode2D.Impulse);
        }
    }
}
