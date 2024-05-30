using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;
    public int damage;

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime; 
    }

    public void Initialize(int damage)
    {
        this.damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
            if (enemy != null && enemy.health > 0)
            {
                enemy.TakeDamage(damage);
                Vector3 spawnParticlePos = new Vector3(enemy.transform.position.x,enemy.transform.position.y + 1, enemy.transform.position.z);
                var randomParticle = Random.Range(0,GameManager.Instance.hitParticles.Length);
                Instantiate(GameManager.Instance.hitParticles[randomParticle], spawnParticlePos, Quaternion.identity);         
                Destroy(this.gameObject);
            }
        }
        else
        {
            StartCoroutine(DestroyBullet());
        }
        
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
