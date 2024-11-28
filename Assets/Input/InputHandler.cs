//using System.Numerics;
#if UNITY_EDITOR
using UnityEditor.SearchService;
#endif
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
public class InputHandler : MonoBehaviour
{
    public TextMeshProUGUI t;
    #region Variables
    public Transform car;
    public int lives = 3;
    public int points = 0;
    public Vector3 target;
    public Transform car1, car2;
    public float ttt = 60.0f;
    

    private Camera _mainCamera;
    //public Vector3 target;
    #endregion

    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    private void Update()
    {
        ttt -= Time.deltaTime;
        if (ttt <= 0) SceneManager.LoadScene(2);
        UpdateScore();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
       
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;
        
//        Debug.Log(rayHit.collider.gameObject.name);
        GameObject obj = rayHit.collider.gameObject;
        if(obj.transform.parent.gameObject.CompareTag("Player"))
        {
            if(obj.GetComponent<Car>().is_ok == false){
                Debug.Log("Correct");
                obj.transform.position = target;
                points++;
                if(points == 20) SceneManager.LoadScene(3);

                //hit.collider.car.transform.position = target;

            }
            else{
                Debug.Log("Wrong");
                lives--; 
                points -= 3;
                if(lives == 0)
                {
                    SceneManager.LoadScene(2);
                }
                if(lives == 1) { car1.transform.position = target; }
                else if(lives == 2) { car2.transform.position = target; }
            }
           
        }
    }
    void UpdateScore()
    {
        t.text = "Score: " + points.ToString();
    }
}
