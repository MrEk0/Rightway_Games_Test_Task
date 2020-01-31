using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyShip : MonoBehaviour, IDamage
{
    [SerializeField] Enemy enemyType;

    public float Health { get; set; }
    public event Action onDead;

    float timeBetweenShots;
    float speed;
    float damage;
    float points;
    float timeSinceShot=0f;

    int laserCount = 0;
    int wayPointIndex = 0;

    GameObject laserPrefab;
    Transform laserStartPosition;
    Score score;
    List<Transform> laserPositions = new List<Transform>();  
    List<Transform> wayPoints = new List<Transform>(); 

    private void Awake()
    {
        if(enemyType!=null)
        {
            GetComponent<SpriteRenderer>().sprite = enemyType.GetSprite();
            laserPrefab = enemyType.GetLaser();
            Health = enemyType.GetStrength();
            damage = Health;
            points = enemyType.GetPoints();
            wayPoints = enemyType.GetWayPoints();
            speed = enemyType.GetSpeed();
            timeBetweenShots = enemyType.GetTimeShots();
        }
        score = FindObjectOfType<Score>();
        FindLasers();

    }

    private void FindLasers()
    {
        foreach(Transform child in transform)
        {
            laserPositions.Add(child);
        }

        laserCount = laserPositions.Count;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        GoThroughPath();
    }

    private void Fire()
    {
        if (timeSinceShot >= timeBetweenShots)
        {
            for (int i = 0; i < laserCount; i++)
            {
                GameObject laser = Instantiate(laserPrefab, laserPositions[i].position, transform.rotation);
                laser.GetComponent<Laser>().Damage = damage;
            }
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
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if(Health<=0)
        {
            Destroy(gameObject);
            score.IncreaseScore(points);
            onDead();
        }
    }

    private void GoThroughPath()
    {
        if(wayPointIndex<=wayPoints.Count-1)
        {
            var targetPosition = wayPoints[wayPointIndex].position;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if(transform.position==targetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            wayPointIndex = 0;
        }
    }
}
