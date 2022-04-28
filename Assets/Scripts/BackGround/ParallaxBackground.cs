using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Vector2 parallaxEffectMultiphier;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    private void Start() {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    private void LateUpdate() {
        Vector3 deltaMove = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMove.x * parallaxEffectMultiphier.x,deltaMove.y * parallaxEffectMultiphier.x,0);
        lastCameraPosition = cameraTransform.position;
    }
}
