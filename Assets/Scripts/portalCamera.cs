using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering;

public class portalCamera : MonoBehaviour
{
    private Vector3 startPos;
    public float distMin = -20;
    public float distMax = 10;

    void Start() {
        startPos = transform.position;
    }

    void Update() {
        UpdateCamera(GetComponent<Camera>());
    }

    void UpdateCamera(Camera camera) {
        camera.projectionMatrix = Camera.main.projectionMatrix;
        camera.transform.forward = Camera.main.transform.forward;
        var offset = (camera.transform.forward * Camera.main.transform.position.z);
        var newPos =  new Vector3(startPos.x, transform.position.y, startPos.z + offset.z);
        camera.transform.position = new Vector3(newPos.x, newPos.y, Mathf.Clamp(newPos.z, distMin, distMax));
        Debug.Log(camera.transform.position);
    }


}
