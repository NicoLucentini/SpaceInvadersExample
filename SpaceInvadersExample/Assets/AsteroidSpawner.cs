using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] Vector2 startSize;
    [SerializeField] Vector2 startSpeed;
    [SerializeField] List<Color> startColor;

    [SerializeField] Vector2 spawnFrequency;


    public static List<Asteroid> asteroids = new List<Asteroid>();


    private void Start()
    {
        StartCoroutine(Spawn());
    }


    IEnumerator Spawn() {

        while (true) {
            float freq = Random.Range(spawnFrequency.x, spawnFrequency.y);
            CreateAsteroid();

            yield return new WaitForSeconds(freq);
        }

    }

    void CreateAsteroid() {
        GameObject asteroid = GameObject.Instantiate(asteroidPrefab);


        float size = Random.Range(startSize.x, startSize.y);
        float speed = Random.Range(startSpeed.x, startSpeed.y);
        int color = Random.Range(0, startColor.Count);
        asteroid.transform.position = new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-5f, 5f));

        Asteroid ast = asteroid.GetComponent<Asteroid>();
        ast.Set(startColor[color], speed, size);
        asteroids.Add(ast);


    }

    
}
