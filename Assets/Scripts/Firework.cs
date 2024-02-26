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
    

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rend = GetComponent<SpriteRenderer>();
        timeToExplode=UnityEngine.Random.Range(minFireworks, maxFireworks);
        _rend.color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.velocity = dir * force;
    }
}
