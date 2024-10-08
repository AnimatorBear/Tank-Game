using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTankController : MonoBehaviour
{
    [SerializeField] private BulletScriptable[] selectedBullets = new BulletScriptable[4];
    [SerializeField] private Transform firePoint;

    [Header("Health")]
    private float currentHealth = 100;
    [SerializeField] private float startHealth = 100;
    [SerializeField] private float maxHealth = 150;

    private void Start()
    {
        currentHealth = startHealth;
        if(firePoint == null)
        {
            firePoint = transform.Find("Firepoint");
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            FireBullet();
        }
        if (Input.GetKey(KeyCode.V))
        {
            FireBullet();
        }
    }

    public void FireBullet()
    {
        BulletScriptable scrip = selectedBullets[0];
        GameObject bullet = Instantiate(
            selectedBullets[0].bulletPrefab,
            firePoint.position,
            firePoint.rotation
        );

        NewBulletController controller = bullet.GetComponent<NewBulletController>();
        controller.stats = selectedBullets[0];
        Rigidbody2D rigidB = bullet.GetComponent<Rigidbody2D>();
        rigidB.AddForce(firePoint.up * scrip.speed,ForceMode2D.Impulse);
        bullet.transform.Find("ParticleTrail").gameObject.SetActive(true);
    }

    public void DoDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            print("You ded");
        }else if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
