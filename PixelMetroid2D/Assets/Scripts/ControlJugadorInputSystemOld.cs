using UnityEngine;

public class ControlJugadorInputSystemOld : MonoBehaviour
{

    public float velocidad;

    private Rigidbody2D fisica;
    private float entradaX;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Obtengo el componente Rigidbody del player para modificar posteriormente su linearVelocity.
        fisica = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    Vector2 position = transform.position;

    //    position.x = position.x + 0.1f;

    //    transform.position = position;

    //}

    private void FixedUpdate()
    {
        entradaX = Input.GetAxis("Horizontal");

        fisica.linearVelocity = new Vector2(entradaX * velocidad, fisica.linearVelocity.y);
    }

}
