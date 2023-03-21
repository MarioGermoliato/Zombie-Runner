using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] RigidbodyFirstPersonController fpsController;
    [SerializeField] Camera mainCamera;
    [SerializeField] float normalZoom = 60f;
    [SerializeField] float scopeZoom = 25f;
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = 0.5f;
    bool isZoomOn;

    private void Update()
    {
        TurnOnScope();
    }

    private void TurnOnScope()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(isZoomOn == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }

        
    }

    private void ZoomIn()
    {
        isZoomOn = true;
        mainCamera.fieldOfView = scopeZoom;
        fpsController.mouseLook.XSensitivity = zoomInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomInSensitivity;
    }

    private void ZoomOut()
    {
        isZoomOn = false;
        mainCamera.fieldOfView = normalZoom;
        fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
    }
      
    private void OnDisable()
    {
        ZoomOut();
    }

}
