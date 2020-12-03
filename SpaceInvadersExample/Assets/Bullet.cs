using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 direction;
    float speed;


    private void Update()
    {
        transform.position += new Vector3(direction.x, direction.y) * speed * Time.deltaTime;
    }

    public void Set(Vector2 direction, float speed) {
        this.direction = direction;
        this.speed = speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9) {
            //Colisiono contra el asteroide
            Debug.Log("Collisiono contra el asteroid");
            Destroy(gameObject);
        }
    }
}
