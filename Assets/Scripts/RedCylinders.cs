using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCylinders : MonoBehaviour
{
    [SerializeField] private int _hitPower;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != null)
        {
            Vector3 superVector = transform.position;
            Vector3 collisionVector = collision.transform.position;

            Vector3 hitVector = Vector3.Normalize(superVector - collisionVector) * _hitPower;

            collision.rigidbody.AddForce(-hitVector, ForceMode.Impulse);
        }
    }
}
