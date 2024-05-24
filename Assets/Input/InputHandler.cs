using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    #region Variables

    private Camera _mainCamera;

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
            }
            else{
                Debug.Log("Wrong");
            }
        }
    }
}