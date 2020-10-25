﻿
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class Zadanie31 : MonoBehaviour
{
    public float speed = 10.1f;
    Vector3 pointA;
    Vector3 pointB;

    void Start()
    {
        pointA = new Vector3(0, 0, 0);
        pointB = new Vector3(10, 0, 0);
    }

    void Update()
    {
        //PingPong between 0 and 1
        float time = Mathf.PingPong(Time.time/speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);
    }
}