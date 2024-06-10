using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    // Start is called before the first frame update
    public float start_line;
    public int lane;
    public float Gravity;
    public bool is_ok;
    public GameObject traffic_light;
    RLGL control ;   
    void Start()
    {
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Game Over");//GAME OVER
            return;
        }
    }

    private void OnTriggerExit(Collider other)
    {
    }
    // Update is called once per frame
    void Update()
    {
        if(Gravity > 0)
        {
            if(transform.position.y < -start_line)
            {
                RLGL control = traffic_light.GetComponent<RLGL>();
                control.cars.Remove(gameObject);
                transform.parent.gameObject.GetComponent<Spawn>().cars_in_lane[lane]-=1;
                Destroy(gameObject);
                }
                
        }
        else
        {
            if(transform.position.y > start_line)
            {
                RLGL control = traffic_light.GetComponent<RLGL>();
                transform.parent.gameObject.GetComponent<Spawn>().cars_in_lane[lane]-=1;
                control.cars.Remove(gameObject);
                Destroy(gameObject);}
        }
    }
}
