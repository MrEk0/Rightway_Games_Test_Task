using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamage
{
    [SerializeField] GameObject projectile;
    [SerializeField] float speed;
    [SerializeField] float offset = 0.5f;
    [SerializeField] float strength;//health
    [SerializeField] float timeBetweenFire=.1f;
    [SerializeField] float damage = 1f;

    float minX;
    float maxX;
    float timeSinceStartFire=0f;
    float fireSpeedTime;
    Coroutine fireCoroutine;//to stop fire
    bool isSpeedFire=false;
    float maxStrength;

    public event Action<float> onTakenDamage;//fdfsfsd

    private void Awake()
    {
        maxStrength = strength;
    }

    private void Start()
    {
        CheckScreenBorders();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        SpeedFireBehaviour();
        FireBehaviour();
    }

    private void FireBehaviour()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (fireCoroutine != null)
                StopCoroutine(fireCoroutine);
        }
    }

    private void SpeedFireBehaviour()
    {
            timeSinceStartFire += Time.deltaTime;
            if(timeSinceStartFire>=fireSpeedTime)
            {
                isSpeedFire = false;
                timeSinceStartFire = 0f;
            }
            if (Input.GetMouseButtonDown(0))
            {
                fireCoroutine = StartCoroutine(SpeedFire());
            }
    }

    private void Movement()
    {
        float horizPosition = Input.GetAxis("Horizontal");
        float posX = transform.position.x + horizPosition * speed * Time.deltaTime;
        posX = Mathf.Clamp(posX, minX, maxX);
        transform.position = new Vector2(posX, transform.position.y);
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);
        bullet.GetComponent<Laser>().Damage = damage;
    }

    public void ModifierFire(float timeFrame)
    {
        fireSpeedTime = timeFrame;
        isSpeedFire = true;
    }

    IEnumerator SpeedFire()
    {
        while (isSpeedFire)
        {
            GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);
            yield return new WaitForSeconds(timeBetweenFire);
        }
    }

    private void CheckScreenBorders()
    {
        Camera cam = Camera.main;
        minX = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + offset;
        maxX = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - offset;
    }

    public void ReceivePowerUp(float strengthAmount)
    {
        strength += strengthAmount;
        if (strength >= maxStrength)
            strength = maxStrength;

        //Debug.Log(strength);
    }

    public float GetStrength()
    {
        return strength;
    }

    public void TakeDamage(float damage)
    {
        strength -= damage;
        onTakenDamage(damage);
    }
}
