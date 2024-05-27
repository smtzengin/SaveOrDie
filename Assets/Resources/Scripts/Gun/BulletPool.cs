using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize = 30;

    private List<GameObject> bulletPool;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        bulletPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab,this.transform);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    public GameObject GetBullet()
    {
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }

        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.SetActive(false);
        bulletPool.Add(newBullet);
        return newBullet;
    }
}
