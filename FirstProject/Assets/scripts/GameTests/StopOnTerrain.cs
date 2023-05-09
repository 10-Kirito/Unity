using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnTerrain : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("¼ì²âµ½Åö×²!!!");
        if (collision.collider.CompareTag("Terrain"))
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                rigidbody.velocity = Vector3.zero;
                rigidbody.isKinematic = true;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
