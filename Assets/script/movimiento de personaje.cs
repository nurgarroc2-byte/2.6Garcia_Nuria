using UnityEngine;

public class movimientodepersonaje : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;

    [SerializeField] private Collider colliderAtaque;

    [Header("MOVIMIENTO")]
    [SerializeField] private float velocidad = 5.0f;
    [SerializeField] private float velocidadGiro = 200.0f;
    [SerializeField] private float fuerzaSalto = 5.0f;

    private bool salto;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>(); // o GetComponentInChildren<Animator>() si está en un hijo
        Cursor.lockState = CursorLockMode.Locked;
    }

   private void Update()
{
    if (Input.GetButtonDown("Jump"))
    {
        salto = true;
        anim.SetTrigger("Jump");
    }
    if (Input.GetButtonDown("Fire1"))
    {
        anim.SetTrigger("Attack");
    }
}

    private void FixedUpdate()
    {
        // MOVIMIENTO
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direccion = (transform.right * h + transform.forward * v).normalized;
        Vector3 movimiento = direccion * velocidad * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + movimiento);

        // ANIMACIONES
        bool estaMoviendose = h != 0.0f || v != 0.0f;
        anim.SetBool("IsMoving", estaMoviendose);
        anim.SetBool("IsMovingLeft", h < 0);
        anim.SetBool("IsMovingR", h > 0);

        // SALTO
        if (salto)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            salto = false;
        }

        // GIRO CON RATÓN
        float giroY = Input.GetAxis("Mouse X") * velocidadGiro * Time.fixedDeltaTime;
        Quaternion rotacion = Quaternion.Euler(0.0f, giroY, 0.0f);
        rb.MoveRotation(rb.rotation * rotacion);
    }
    //Habilitar colider
    private void Habilitar()
    {
        colliderAtaque.enabled =true;
    }


    //Desabilitar colider
    private void Desabilitar()
    {
        colliderAtaque.enabled = false;
    }
}
