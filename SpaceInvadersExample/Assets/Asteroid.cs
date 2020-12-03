using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    SpriteRenderer rend;

    float speed;

    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    public void Set(Color color, float speed, float size) {
        rend.color = color;
        this.speed = speed;

        transform.localScale *= size;
    }


}
