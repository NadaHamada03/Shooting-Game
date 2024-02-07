using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 8f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _firerate = 0.5f;
    private float _canfire = -1f;
    [SerializeField]
    public int _lives = 1;
    public SpawnManager _spawnManager;

    void Start()
    {
        transform.position = new UnityEngine.Vector3(0, 0, 0);

        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canfire)
        {
            FireLaser();
        }

    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        UnityEngine.Vector3 direction = new UnityEngine.Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * speed * Time.deltaTime);

        transform.position = new UnityEngine.Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);

        if (transform.position.x >= 11f)
        {
            transform.position = new UnityEngine.Vector3(-11f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11f)
        {
            transform.position = new UnityEngine.Vector3(11f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
        _canfire = Time.time + _firerate;
        UnityEngine.Vector3 offset = new UnityEngine.Vector3(transform.position.x, transform.position.y + 0.9f, 0);
        Instantiate(_laserPrefab, offset, UnityEngine.Quaternion.identity);
    }

    public void Damage()
    {
        _lives--;

        if (_lives == 0)
        {
            _spawnManager.StopSpawning = true;
            Destroy(this.gameObject);
        }

    }
}

