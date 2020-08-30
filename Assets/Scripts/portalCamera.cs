using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering;

public class portalCamera : MonoBehaviour
{
    void Update() {
        UpdateCamera(this.GetComponent<Camera>());
        transform.forward = Camera.main.transform.forward;
    }

    void UpdateCamera(Camera camera) {
        camera.projectionMatrix = Camera.main.projectionMatrix;
    }


}
