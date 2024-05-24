using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Spawn : MonoBehaviour
{
    public List<GameObject> Cars;
    public List<float> lane_coordinate;
    System.Random rnd;// = new Random();
    public float Car_density;//out of 100
    public float start_line;
    public float gravity;
    public float delay; //minimum time gap between 2 spawns
    float delay_time=0f;
    // Start is called before the first frame update
    public float good_car_prob;//out of 100
    public GameObject traffic_light;
    RLGL control ;   
    void Start()
    {
        rnd = new System.Random();
       
      //  Debug.Log(Pow(-1,1));
    }

    int Pow_1(int y){
        if(y%2==0){return 1;}
        return -1;
    }
    // Update is called once per frame
    void Update()
    {
        delay_time += Time.deltaTime;
        if(delay_time > delay){
            delay_time = 0f;
            int x = rnd.Next(0, 100);
            if(x < Car_density){
                x = rnd.Next(0, 8);
                float X = lane_coordinate[x] + transform.position.x;
                float Gravity =  gravity * Pow_1(x+1);
                float Y =  start_line * Pow_1(x+1);
            //    Debug.Log(Pow(-1, x));
            //    Debug.Log(x);
                Vector3 position = new Vector3(X, Y, 0);
                GameObject car = Instantiate(Cars[rnd.Next(0, 8)], position, Quaternion.identity, transform);
                Rigidbody2D rb = car.GetComponent<Rigidbody2D>();
                rb.gravityScale = Gravity;
                car.transform.localScale =  new Vector3(car.transform.localScale.x, car.transform.localScale.y*Pow_1(x+1), 1);
                Car car_ = car.GetComponent<Car>();
                car_.start_line = start_line;
                car_.Gravity = Gravity;
                car_.is_ok = (rnd.Next(0, 100) < good_car_prob);
                car_.traffic_light=traffic_light;
                if(car_.is_ok)
                {
                     RLGL control = traffic_light.GetComponent<RLGL>();
    
                    control.cars.Add(car);
                }
            }
        }
    }
}
