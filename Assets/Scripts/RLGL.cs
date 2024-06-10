using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RLGL : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Green;
    System.Random rnd;
    public GameObject Red;
    public List<GameObject> cars;
    public GameObject pedest;
    public int stop_probability;//out of 100
    public float pedest_speed;
    public float delay;
    float delay_time=0f;
    bool stop = false;
    void Start()
    {
        Red.SetActive(false);
        Green.SetActive(true);
        rnd = new System.Random();
    }

    void Update()
    {
        delay_time += Time.deltaTime;
        if(rnd.Next(0,100)<stop_probability && stop == false && delay_time > delay)
        {
            delay_time = 0f;
            Red.SetActive(true);
            Green.SetActive(false);
            stop = true;
        }

        if(stop)
        {
            for(int i=0; i<cars.Count; i++)
            {
                if (cars[i] == null){}
                else if(cars[i].GetComponent<Car>().is_ok){
                    Rigidbody2D rb2 = cars[i].GetComponent<Rigidbody2D>();
                    rb2.velocity = new Vector3(0,0,0);
                    rb2.gravityScale = 0;
                }
            }
            pedest.transform.position = new Vector3(pedest.transform.position.x + pedest_speed * Time.deltaTime, 0, 1);
            if(pedest.transform.position.x > 10)
            {
                pedest.transform.position = new Vector3(-10, 0, 1);
                stop = false;
                Red.SetActive(false);
                Green.SetActive(true);
                delay_time = 0f;
                for(int i=0; i<cars.Count; i++)
                {
                    Rigidbody2D rb2 = cars[i].GetComponent<Rigidbody2D>();
                    rb2.gravityScale = cars[i].GetComponent<Car>().Gravity;
                }
                
            }
         
        }
    }
}
