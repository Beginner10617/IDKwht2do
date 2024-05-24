using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
  public Camera mainCamera; // Reference to the main camera (optional)
  public Vector3 targetPosition; // The desired position to move the car to
  public string carTag = "Car"; // Tag assigned to all car prefabs (replace with your tag if used)

  void Update()
  {
    if (Input.GetMouseButtonDown(0)) // Check for left mouse button click
    {
      // Raycast from the main camera towards the mouse click position
      Ray ray = mainCamera != null ? mainCamera.ScreenPointToRay(Input.mousePosition) : Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;

      // Check if the raycast hits a car
      if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.CompareTag(carTag))
      {
        // Move the clicked car to the target position
        hit.collider.gameObject.transform.position = targetPosition;
      }
    }
  }
}

