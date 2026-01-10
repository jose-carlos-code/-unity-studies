using UnityEngine;
using UnityEngine.InputSystem;

public class MoveController : MonoBehaviour
{
    [Header("Configurações")]
    public float speed = 5f;

    private Rigidbody2D rb;
    private Vector2 movementInput;

    // Referência ao componente PlayerInput (adicionaremos no objeto)
    private PlayerInput playerInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Este método será chamado automaticamente pelo PlayerInput
    // quando a ação "Move" for acionada
    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    void FixedUpdate()          // ← Melhor usar FixedUpdate quando mexe com física
    {
        // Usando Rigidbody2D (movimento físico correto)
        Vector2 moveVelocity = movementInput * speed;
        rb.linearVelocity = moveVelocity;

        // Alternativa (se quiser movimento não-físico como no seu código original):
        // transform.position += (Vector3)movementInput * speed * Time.deltaTime;
    }
}