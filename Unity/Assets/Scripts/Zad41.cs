using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;
using Random = UnityEngine.Random;

public class Zad41 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    public int amount = 3;
    public Material[] materials;
    private Renderer rend;
    int objectCounter = 0;
    // obiekt do generowania
    public GameObject block;
    

    void Start()
    {
        rend = block.GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[0];
        // w momecie uruchomienia generuje 10 kostek w losowych miejscach
        List<int> pozycje_x = new List<int>(Enumerable.Range(0, 20).OrderBy(x => Guid.NewGuid()).Take(amount));
        List<int> pozycje_z = new List<int>(Enumerable.Range(0, 20).OrderBy(x => Guid.NewGuid()).Take(amount));
        
        for (int i = 0; i < amount; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 5, pozycje_z[i]));
            
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");
        foreach (Vector3 pos in positions)
        {
            int mat = Random.Range(0, 4);
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            
            yield return new WaitForSeconds(this.delay);
            this.rend.sharedMaterial = materials[mat];
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}