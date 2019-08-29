using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour, IDamage
{
    [SerializeField] Enemy enemyType;
    [SerializeField] float timeBetweenShots;

    public float Health { get; set; }

    float damage;
    float points;
    float timeSinceShot=0f;
    GameObject laserPrefab;
    Transform laserStartPosition;
    Score score;

    private void Awake()
    {
        if(enemyType!=null)
        {
            GetComponent<SpriteRenderer>().sprite = enemyType.GetSprite();
            laserPrefab = enemyType.GetLaser();
            Health = enemyType.GetStrength();
            damage = Health;
            points = enemyType.GetPoints();
        }
        laserStartPosition = transform;
        score = FindObjectOfType<Score>();

    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (timeSinceShot >= timeBetweenShots)
        {
            GameObject laser=Instantiate(laserPrefab, laserStartPosition.position, transform.rotation);
            laser.GetComponent<Laser>().Damage = damage;
            timeSinceShot = 0f;
        }
        timeSinceShot += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            float damage = collision.gameObject.GetComponent<Laser>().Damage;
            TakeDamage(damage);
            Debug.Log(Health);
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if(Health<=0)
        {
            Destroy(gameObject);
            score.IncreaseScore(points);
        }
    }
}
