using System.Collections.Generic;
using UnityEngine;


public class BulletSpawner : MonoBehaviour
{
    enum SpawnerType { Normal, Spin }


    [Header("Bullet Attributes")]
    [SerializeField] private List<GameObject> _bullet;
    public float bulletLife = 1f;
    public float speed = 1f;


    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] public float firingRate = 1f;


    private GameObject spawnedBullet;
    private float timer = 0f;
    public int _currentBulletUpgrade = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (spawnerType == SpawnerType.Spin) transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 1f);
        if (timer >= firingRate)
        {
            Fire();
            timer = 0;
        }
    }


    private void Fire()
    {
        
            spawnedBullet = Instantiate(_bullet[_currentBulletUpgrade], transform.position, Quaternion.identity);
            Playerbullet playerBullet = spawnedBullet.GetComponent<Playerbullet>();

            if (playerBullet != null)
            {
                playerBullet.force = speed;
                Destroy(spawnedBullet, bulletLife);
            }
            else
            {
                Bullet enemyBullet = spawnedBullet.GetComponent<Bullet>();
                enemyBullet.speed = speed;
                enemyBullet.bulletLife = bulletLife;
            }
            spawnedBullet.transform.rotation = transform.rotation;
        
    }
}
