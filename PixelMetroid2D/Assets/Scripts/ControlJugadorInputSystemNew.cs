using UnityEngine;
using UnityEngine.InputSystem;

public class ControlJugadorInputSystemNew : MonoBehaviour
{
    public InputAction moveAction;
    public float velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        Vector2 position = (Vector2)transform.position + move * velocity * Time.deltaTime;
        transform.position = position;
    }
}
