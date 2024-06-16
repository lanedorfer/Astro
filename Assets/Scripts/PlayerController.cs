using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float  xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _tilt;

    private Rigidbody _rb;

    [SerializeField] private Boundary _boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate = 0.5f;
    public float nextFire = 0.0f;


    public void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, transform.position, shotSpawn.rotation);
        }
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        _rb.velocity = movement * _speed;

        _rb.position = new Vector3
        (
            Math.Clamp(_rb.position.x, _boundary.xMin, _boundary.xMax),
            0.0f,
            Math.Clamp(_rb.position.z, _boundary.zMin,_boundary.zMax)
            
        );
        
        _rb.rotation = Quaternion.Euler(0,0,_rb.velocity.x * _tilt);
        
    }
}
