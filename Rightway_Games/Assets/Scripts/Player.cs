using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float speed;
    [SerializeField] float offset = 0.5f;
    [SerializeField] float strength;
    [SerializeField] float timeBetweenFire=.1f;

    float minX;
    float maxX;
    float timeSinceStartFire=0f;
    float fireSpeedTime;
    Coroutine fireCoroutine;//to stop fire
    bool isSpeedFire=false;

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

    private void CheckScreenBorders()
    {
        Camera cam = Camera.main;
        minX = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x+offset;
        maxX = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x-offset;
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);
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

    public void ReceivePowerUp(float strengthAmount)
    {
        strength += strengthAmount;
        Debug.Log(strength);
    }
}
