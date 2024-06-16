using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    [SerializeField] private float _speedMin;
    [SerializeField] private float _speedMax;
    
    private int _speed;
    
    // Start is called before the first frame update
    void Start()
    {
        _speed = (int)Random.Range(_speedMin, _speedMax);
        GetComponent<Rigidbody>().velocity = transform.forward * -_speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
