using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class MovimientoJugador : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocity;

    [SerializeField] private InputActionReference accionMover;

    [Header("Salto")]
    [SerializeField] private InputActionReference accionSaltar;

    public float fuerzaImpulso = 5f;
    [SerializeField] private LayerMask capaSuelo;

    private Rigidbody2D rb;
    private Vector2 entradaX;
    private bool saltoPendiente;
    private bool estaTocandoSuelo;

    [SerializeField]
    private float longitudRaycast = 1.6f;


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
        entradaX = accionMover.action.ReadValue<Vector2>();

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRaycast, capaSuelo);

        estaTocandoSuelo = hit.collider != null;

        Color colorRayo = estaTocandoSuelo ? Color.green : Color.red;

        Debug.DrawRay(transform.position, Vector2.down * longitudRaycast, colorRayo);

        if (accionSaltar.action.WasPressedThisFrame() && estaTocandoSuelo)
        {
            saltoPendiente = true;
        }

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

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(entradaX.x * velocity, rb.linearVelocity.y);
        if (saltoPendiente)
        {
            rb.AddForce(Vector2.up * fuerzaImpulso, ForceMode2D.Impulse);
        }

        saltoPendiente = false;

    }
}