using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleView : MonoBehaviour
{
    public float speed;
    public Transform target;

    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed *Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            gameObject.SetActive(false);
        }
    }
}
