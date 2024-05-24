using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class rlgl : MonoBehaviour
{
  public Rigidbody2D rb11;
  public Rigidbody2D rb12;
  public Rigidbody2D rb13;
  public Rigidbody2D rb14;

  public Rigidbody2D rb21;
  public Rigidbody2D rb22;
  public Rigidbody2D rb23;

  public Rigidbody2D rb24;
  

  public SpriteRenderer sprite1; // Assign SpriteRenderer for circle 1 in Inspector
  public SpriteRenderer sprite2; // Assign SpriteRenderer for circle 2 in Inspector
  public float lightSwitchTime = 2.0f; // Time between color switches (adjust in Inspector)

  private bool isRedLight;

  void Start()
  {
    isRedLight = true; // Start with Red Light
   // rb1.isStatic = false;
    SetColors();
  }

  void Update()
  {
    lightSwitchTime -= Time.deltaTime;

    if (lightSwitchTime <= 0)
    {
      isRedLight = !isRedLight; // Toggle between Red and Green Light
      SetColors();
      lightSwitchTime = Random.Range(3,6); // Reset timer
    }
    
  }

  void SetColors()
  {
    if (isRedLight)
    {
      sprite1.color = Color.red;
      sprite2.color = Color.black;
    }
    else
    {
      sprite1.color = Color.black;
      sprite2.color = Color.green;
    }
    if(isRedLight){
      rb11.gravityScale = 0.0f;
      rb12.gravityScale = 0.0f;
      rb13.gravityScale = 0.0f;
      rb14.gravityScale = 0.0f;
      rb21.gravityScale = 0.0f;
      rb22.gravityScale = 0.0f;
      rb23.gravityScale = 0.0f;
      rb24.gravityScale = 0.0f;
      rb11.velocity = Vector2.zero;
      rb21.velocity = Vector2.zero;
      rb12.velocity = Vector2.zero;
      rb13.velocity = Vector2.zero;
      rb14.velocity = Vector2.zero;
      rb22.velocity = Vector2.zero;
      rb23.velocity = Vector2.zero;
      rb24.velocity = Vector2.zero;


   } 
    else {
      rb11.gravityScale = 0.02f;
      rb12.gravityScale = 0.02f;
      rb13.gravityScale = 0.02f;
      rb14.gravityScale = 0.02f;
      rb21.gravityScale = -0.02f;
      rb22.gravityScale = -0.02f;
      rb23.gravityScale = -0.02f;
      rb24.gravityScale = -0.02f;
      
    }
  }
}