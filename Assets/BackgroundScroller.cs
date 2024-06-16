using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed;
    [SerializeField] private float _titleSizeY;

    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        float newPosition = Mathf.Repeat(t:Time.time * _scrollSpeed, _titleSizeY);
        transform.position = _startPosition + Vector3.forward * newPosition;
    }
}
