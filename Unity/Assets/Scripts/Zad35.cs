using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Zad35 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 1.0f;
    int objectCounter = 0;
 
    public GameObject block;

    void Start()
    {
        List<int> pozycje_x = new List<int>(Enumerable.Range(-10, 10).OrderBy(x => Guid.NewGuid()).Take(10));
        List<int> pozycje_z = new List<int>(Enumerable.Range(-10, 10).OrderBy(x => Guid.NewGuid()).Take(10));

        for (int i = 0; i < 10; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 5, pozycje_z[i]));
        }
       
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
      
        foreach (Vector3 pos in positions)
        {
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            yield return new WaitForSeconds(this.delay);
        }
        StopCoroutine(GenerujObiekt());
    }
}