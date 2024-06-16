using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;
    [SerializeField] private GameObject _playerExplosion;

    private int _scoreValue;
    
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        if (_explosion != null)
        {
            Instantiate(_explosion, transform.position, transform.rotation);
        }

        if (other.tag == "Player")
        {
            Instantiate(_playerExplosion, other.transform.position, other.transform.rotation);
        }
        
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
