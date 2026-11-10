
using System;
using UnityEngine;

public class EfectoParallax : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)]
    private float factorHorizontal = 0.6f;

    [SerializeField] private Transform camara;

    private Vector3 ultimaPosicionCamara;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (camara == null && Camera.main != null)
            camara = Camera.main.transform;

        if(camara == null)
        {
            Debug.LogError("Asigna camara");
            enabled = false;
            return;
        }

        ultimaPosicionCamara = camara.position;
      
    }

    private void LateUpdate()
    {
        Vector3 cambioCamara = camara.position - ultimaPosicionCamara;
        transform.position += new Vector3(cambioCamara.x * factorHorizontal,
                                            cambioCamara.y, 0f);

        ultimaPosicionCamara = camara.position;
    }
}
