using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementExample : MonoBehaviour
{
    public float controlSpeed = 10, touchPosX = 0;
    private Touch touch;
    private float speedModifier = 0.01f;
    void Start()
    {
        speedModifier = 0.01f;
    }

    void Update()
    {
        #if UNITY_EDITOR
        GetInput();
        #else
        GetTouch();
        #endif
    }

    // Editor
    void GetInput(){
        if(Input.GetMouseButton(0)){ // if there is any click
            touchPosX += Input.GetAxis("Mouse X") * controlSpeed * Time.deltaTime; // get x axis during click * my factor
            if(touchPosX > -3 && touchPosX < 3){ // min max controls
                transform.position = new Vector3(touchPosX, transform.position.y, transform.position.z); // set new x axis to the object
            }
        }
    }

    // Mobile
    void GetTouch(){
        if(Input.touchCount > 0){ // if there is any click
            touch = Input.GetTouch(0); // assign the touching
            if(touch.phase == TouchPhase.Moved){ // if there is a moving
                float newX = transform.position.x+touch.deltaPosition.x*speedModifier; // old position + finger moving length * my factor
                if(newX > -3 && newX < 3){ // min max controls
                    transform.position = new Vector3(newX, transform.position.y, transform.position.z); // set new x axis to the object
                }
            }
        }
    }
}