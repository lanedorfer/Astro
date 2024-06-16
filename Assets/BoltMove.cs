using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMove : MonoBehaviour
{
    [SerializeField] private int _speed;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * -_speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
