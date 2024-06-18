using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExistObject : MonoBehaviour
{
    private GameObject explosion;
    void OnTriggerExit (Collider other)
    {
        Instantiate(explosion, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation);
        if (other.tag == "Bolt")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
