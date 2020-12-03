using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    Vector2 inputs;

    float refSmoothDampVel = 0f;
    float rotationSpeed = .1f;
    float speed = 3f;

    [SerializeField] GameObject bulletPrefab;



    private void Update()
    {
        inputs = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        Movement();

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Shoot();
        }
    }

   
    

    void Movement() {

        var direction = inputs.normalized * speed;

        transform.position += new Vector3(direction.x,  direction.y, 0) * Time.deltaTime;

       LookAtDirection(inputs);
    }
    void LookAtDirection(Vector2 direction)
    {
        if (direction.magnitude > 0)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, -targetAngle, ref refSmoothDampVel, rotationSpeed);
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
    void Shoot() {

        GameObject bullet = GameObject.Instantiate(bulletPrefab, transform.position + transform.up/2, Quaternion.identity);
        bullet.GetComponent<Bullet>().Set(transform.up, 6f);

    }

}
