using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : MonoBehaviour
{
    public float force, minTimeToExplode, maxTimeToExplode;
    public int minFireworks, maxFireworks;
    public GameObject fireworkPrefab;
    public int maxExplosions = 3;

    private Rigidbody2D _rb;
    private SpriteRenderer _rend;
    private int _count = 0;
    private Vector2 dir = Vector2.up;
    private float currentTime, timeToExplode;
    private int nFirework = 0;
    private int nExplosion = 0;


    // Start is called before the first frame update
    void Start()
    {

        nExplosion = GameManager.instance.GetFireworks();
        nExplosion++;
        GameManager.instance.SetFireworks(nExplosion);
        _rb = GetComponent<Rigidbody2D>();
        _rend = GetComponent<SpriteRenderer>();
        timeToExplode = UnityEngine.Random.Range(minTimeToExplode, maxTimeToExplode);
        _rend.color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.velocity = dir * force;
        currentTime += Time.deltaTime;

        if (currentTime >= timeToExplode)
        {
            nFirework++;
            _count = UnityEngine.Random.Range(minFireworks, maxFireworks);
            if (nFirework <= maxExplosions)
            {

                for (int i = 0; i < _count; i++)
                {
                    GameObject fireworkPrefab1 = Instantiate(fireworkPrefab, transform.position, Quaternion.identity);
                    fireworkPrefab1.GetComponent<Firework>().dir.x = UnityEngine.Random.Range(-1, 2);
                    fireworkPrefab1.GetComponent<Firework>().dir.y = UnityEngine.Random.Range(-1, 2);
                    fireworkPrefab1.GetComponent<Firework>().nFirework = nFirework;
                }
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

        }
    }

}