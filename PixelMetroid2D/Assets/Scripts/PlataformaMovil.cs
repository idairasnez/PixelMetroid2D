using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


[RequireComponent(typeof(Rigidbody2D))]
public class PlataformaMovil : MonoBehaviour
{

    [SerializeField] private Transform puntoA;
    [SerializeField] private Transform puntoB;

    [SerializeField, UnityEngine.Min(0f)] private float velocidad = 2f;

    private Rigidbody2D fisica;
    private bool haciaB = true;
    private float tolerancia = 0.01f;

    private void Awake()
    {
        fisica = GetComponent<Rigidbody2D>();
    }

    public Vector2 Velocidad { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(puntoA == null || puntoB == null)
        {
            Debug.LogError("Asigna el punto A y el punto B a la plataforma móvil.", this);
            return;
        }
        //Punto origen de la plataforma.
        fisica.position = (Vector2)puntoA.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        Vector2 destino = haciaB ? (Vector2)puntoB.position : (Vector2)puntoA.position;

        if(Vector2.Distance(fisica.position, destino) <= tolerancia)
        {
            haciaB = !haciaB;
            destino = haciaB ? (Vector2)puntoB.position : (Vector2)puntoA.position;
        }

        Vector2 siguiente = Vector2.MoveTowards(fisica.position, destino, velocidad * Time.fixedDeltaTime);

        fisica.MovePosition(siguiente);

    }

    private void OnDrawGizmos()
    {
        if(puntoA == null || puntoB == null || fisica == null)
            return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(puntoA.position, puntoB.position);
        
    }
}
