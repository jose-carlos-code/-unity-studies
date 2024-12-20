using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float turnSPeed = 0;
    [SerializeField] private Vector3 movement;
    [SerializeField] private Animator animator;
    [SerializeField] private Quaternion rotation = Quaternion.identity; // o rotation começa zerado
    [SerializeField] private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movement.Set(horizontal, 0f, vertical);
        movement.Normalize();

        //  !-> contrario -> (quando horizontal for igual a 0f, a função retorna true);
        bool hasHorizontal = !Mathf.Approximately(horizontal, 0f);
        bool hasVertical = !Mathf.Approximately(vertical, 0f);

        // isWalking vai ser verdadeiro quando hasHorizontal ou hasVertical for verdadeiro
        bool isWalking = hasHorizontal || hasVertical;

        animator.SetBool("isWalking", isWalking);

                       /* Funcão para rotacionar um objeto. 1 - frente objeto,  2 - pra onde ele vai girar(para onde
                       ta apontado o Vector3 do movemente), 3 - velocidade , 4 - parâmetro que não usaremos por agora  */
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movement, turnSPeed * Time.deltaTime, 0);
        // passando de fato a rotação que eu quero para o Quaternion.
        rotation = Quaternion.LookRotation(desiredForward);
    }
    // sempre que o animator se move, ele chama essa função
    private void OnAnimatorMove()
    {
        //movimentando o personagem de acordo com animator
        rb.MovePosition(rb.position + movement * animator.deltaPosition.magnitude);
        // rotacionando
        rb.MoveRotation(rotation);
    }

}
