using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class movement : MonoBehaviour
{
    
    public float speed ;
    // Start is called before the first frame update
    void Start()
    {
        speed  = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, speed*Time.deltaTime,0));
    }
}
