using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
   [SerializeField] private float _tumbleMin;
   [SerializeField] private float _tumbleMax;
   
   [SerializeField] private int _tumble;

   private void Start()
   {
      _tumble = (int)Random.Range(_tumbleMin, _tumbleMax);
      GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * _tumble;
   }
}
