using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRock : MonoBehaviour
{
    [SerializeField] Asteroid asteroidType;
    [SerializeField] float rotateSpeed;
    [SerializeField] float speedDivider;

    Rigidbody2D rd;
    float speed;
    float health;
    float points;
    Vector3 rotate;
    Score score;

    private void Awake()
    {
        if (asteroidType != null)
        {
            GetComponent<SpriteRenderer>().sprite = asteroidType.GetSprite();
            transform.localScale = new Vector3(asteroidType.GetSize(), asteroidType.GetSize(), 0);
            speed = asteroidType.GetSpeed() / speedDivider;
            health = asteroidType.GetStrength();
            points = asteroidType.GetPoints();
        }
        rd = GetComponent<Rigidbody2D>();
        rotate = new Vector3(0, 0, rotateSpeed);

        score = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotate*Time.deltaTime);
    }

    private void FixedUpdate()
    {
        rd.velocity = new Vector2(0, -speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //give damage
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Laser"))
        {
            Destroy(collision.gameObject);
            if (health>0)
            {
                health--;
            }
            else
            {
                //give points
                score.IncreaseScore(points);
                Destroy(gameObject);
            }
        }
    }
}
