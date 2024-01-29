using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform carTransform;

    public float followSpeed = 15f; // Velocidad de seguimiento

    public float tiltAngle = 10f; // Ángulo de inclinación deseado

    void FixedUpdate()
    {
        if (carTransform == null)
        {
            Debug.LogWarning("Car Transform not set in CameraFollow script.");
            return;
        }

        // Mover la cámara un poco a la izquierda, directamente detrás del coche con tilt
        Vector3 targetPosition = carTransform.position - (carTransform.forward * 9.2f) + (carTransform.up * 1.3f) - (carTransform.right * 0.1f);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Calcular la rotación con tilt
        Quaternion targetRotation = Quaternion.LookRotation(carTransform.forward, carTransform.up);
        targetRotation *= Quaternion.Euler(Vector3.up * tiltAngle); // Aplicar el ángulo de inclinación

        // Suavizar la rotación
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, followSpeed * Time.deltaTime);
    }
}
