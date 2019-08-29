using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    [SerializeField] Enemy enemyType;
    [SerializeField] float timeBetweenShots;

    float health;
    float timeSinceShot=0f;
    GameObject laser;
    Transform laserStartPosition;

    private void Awake()
    {
        if(enemyType!=null)
        {
            GetComponent<SpriteRenderer>().sprite = enemyType.GetSprite();
            laser = enemyType.GetLaser();
            health = enemyType.GetStrength();
        }
        laserStartPosition = transform;

    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        //StartCoroutine(Shooting());
    }

    private void Fire()
    {
        if (timeSinceShot >= timeBetweenShots)
        {
            Instantiate(laser, laserStartPosition.position, transform.rotation);
            timeSinceShot = 0f;
        }
        timeSinceShot += Time.deltaTime;
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            Instantiate(laser, laserStartPosition.position, transform.rotation);
            yield return new WaitForSeconds(timeBetweenShots);
        }
    }
}
