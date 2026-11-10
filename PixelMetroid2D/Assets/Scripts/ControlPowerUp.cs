using UnityEngine;

public class ControlPowerUp : MonoBehaviour
{
    [SerializeField, Range(1, 10)] private int cantidad = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        if(collision.gameObject.TryGetComponent(out MovimientoJugador jugador))
        {
            jugador.IncrementarPuntos(cantidad);
            Destroy(gameObject);
        } else
        {
            Debug.LogError("El objeto player necesita un componente MovimientoJugador");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
