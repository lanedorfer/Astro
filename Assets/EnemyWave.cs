using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] private Boundary _boundary;
    [SerializeField] private float _tilt;

    [SerializeField] private float _dodge;
    [SerializeField] private float _smoothing;
    [SerializeField] private Vector2 _startWait;
    [SerializeField] private Vector2 _waveTimer;
    [SerializeField] private Vector2 _waveWait;

    private float _currentSpeed;
    private float _targetWave;

    private void Start()
    {
        _currentSpeed = GetComponent<Rigidbody>().velocity.z;
        StartCoroutine(Evade());
    }


    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(_startWait.x, _startWait.y));
        while (true)
        {
            _targetWave = Random.Range(1, _dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(_waveTimer.x, _waveTimer.y));
            _targetWave = 0;
            yield return new WaitForSeconds(Random.Range(_waveWait.x, _waveWait.y));
        }
    }
    private void FixedUpdate()
    {
        float newManeuver = 
            Mathf.MoveTowards(GetComponent<Rigidbody>().velocity.x, _targetWave, _smoothing * Time.deltaTime);
        GetComponent<Rigidbody>().velocity = new Vector3(newManeuver, 0.0f, _currentSpeed);
        GetComponent<Rigidbody>().position = new Vector3
        (
            Math.Clamp(GetComponent<Rigidbody>().position.x, _boundary.xMin, _boundary.xMax),
            0.0f,
            Math.Clamp(GetComponent<Rigidbody>().position.z, _boundary.xMin, _boundary.zMax)
        );
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(0,0, GetComponent<Rigidbody>().velocity.x * _tilt);
    }
}
