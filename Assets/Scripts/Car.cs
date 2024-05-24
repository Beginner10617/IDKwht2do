using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    // Start is called before the first frame update
    public float start_line;
    public float Gravity;
    public bool is_ok;
    public bool on_cross = false;
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
        on_cross = true;
        Debug.Log("on cross");
    }

    private void OnTriggerExit(Collider other)
    {
        on_cross = false;
        Debug.Log("off cross");
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
                Destroy(gameObject);}
        }
        else
        {
            if(transform.position.y > start_line)
            {
        RLGL control = traffic_light.GetComponent<RLGL>();
                control.cars.Remove(gameObject);
                Destroy(gameObject);}
        }
    }
}
