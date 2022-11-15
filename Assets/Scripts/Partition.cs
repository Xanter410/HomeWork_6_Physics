using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partition : MonoBehaviour
{
    [SerializeField] private Transform point_1;
    [SerializeField] private Transform point_2;
    [SerializeField] private float speed = 1;

    private bool Direction = true;

    void Update()
    {
        if (Direction)
        {
            transform.position = Vector3.MoveTowards(transform.position, point_1.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, point_2.position, speed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, point_1.position) <= 0.2)
        {
            Direction = false;
        }
        else if (Vector3.Distance(transform.position, point_2.position) <= 0.2)
        {
            Direction = true;
        }
    }
}
