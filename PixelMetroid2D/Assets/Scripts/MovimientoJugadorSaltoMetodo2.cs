using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

[RequireComponent(typeof(Rigidbody2D))]
public class MovimientoJugadorSaltoMetodo2 : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocity;

    [SerializeField] private InputActionReference accionMover;

    [Header("Salto")]
    [SerializeField] private InputActionReference accionSaltar;

    public float fuerzaImpulso = 5f;

    [Header("Chequeo de suelo")]
    [SerializeField] private float groundDistance = 0.2f; // radio esfera de la esfera pies
    [SerializeField] private Transform esferaPies; // objeto vacio en los pies
    [SerializeField] private LayerMask capaSuelo;
    private Rigidbody2D rb;
    private Vector2 entradaMovimiento;
    private bool saltoPendiente;
    private bool estaTocandoSuelo;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        entradaMovimiento = accionMover.action.ReadValue<Vector2>();

        estaTocandoSuelo = Physics2D.OverlapCircle(esferaPies.position, groundDistance, capaSuelo);

        if (accionSaltar.action.WasPressedThisFrame() && estaTocandoSuelo)
        {
            saltoPendiente = true;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(entradaMovimiento.x * velocity, rb.linearVelocity.y);

        if (saltoPendiente)
        {
            rb.AddForce(Vector2.up * fuerzaImpulso, ForceMode2D.Impulse);
        }

        saltoPendiente = false;
    }

    private void OnEnable()
    {
        if (accionMover == null || accionMover.action == null)
        {
            Debug.Log("Asigna mapa de acción Player/Mover en Acción mover");
            enabled = false;
            return;
        }

        accionMover.action.Enable();

        if (accionSaltar == null || accionSaltar.action == null)
        {
            Debug.Log("Asigna mapa de acción Player/Saltar en Acción saltar");
            enabled = false;
            return;
        }

        accionSaltar.action.Enable();
    }

    private void OnDisable()
    {
        if (accionMover != null && accionMover.action != null)
        {
            accionMover.action.Disable();
        }

        if (accionSaltar != null && accionSaltar.action != null)
        {
            accionSaltar.action.Disable();
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (esferaPies != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(esferaPies.position, groundDistance);
        }
    }
}