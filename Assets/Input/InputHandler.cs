//using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
public class InputHandler : MonoBehaviour
{
    #region Variables
    public Transform car;
    public int lives = 3;
    public int points = 0;
    public Vector3 target;
    

    private Camera _mainCamera;
    //public Vector3 target;
    #endregion

    private void Awake()
    {
        _mainCamera = Camera.main;
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
                points--;
                if(lives == 0)
                {
                    SceneManager.LoadScene(2);
                }
            }
        }
    }
}