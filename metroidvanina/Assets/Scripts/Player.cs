using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float fireRate;

    [SerializeField] float maxSpeed;
    [SerializeField] Transform groundCheck;
    [SerializeField] float jumpForce;

    public ConsumableItem item;
    public int maxHealth;
    public int maxMana;

    [SerializeField] float speed;
    private Rigidbody2D rb;
    private bool onGround;
    private bool doubleJump;
    private bool jump = false;
    public Weapon weaponEquipped;
    private Animator anim;
    private Attack attack;
    private float nextAttack;
    public int health;
    public int mana;



    [SerializeField] bool facingRight = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = maxSpeed;
        anim = GetComponent<Animator>();
        attack = GetComponentInChildren<Attack>();
    }

    void Update()
    {
        onGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (onGround)
        {
            doubleJump = false;
        }

        if(Input.GetButtonDown("Jump") && (onGround || !doubleJump))
        {
            jump = true;
            if(!onGround && !doubleJump)
            {
                doubleJump = true;
            }

        }

        if (Input.GetButtonDown("Fire3")) // botão do meio do mouse
        {
            // usar o item consumível e depois remover do inventário
            UseItem(item);
            Inventory.inventory.RemoveItem(item);
        }


        if (Input.GetButtonDown("Fire1") && Time.time > nextAttack && weaponEquipped != null)
        {
            anim.SetTrigger("Attack");
            attack.PlayAnimation(weaponEquipped.animation);
            nextAttack = Time.time + fireRate;
        }
    }

    private void FixedUpdate()
    {
        //GetAxisRaw não pega a acelaração, já vai logo para o valor máximo
        float h = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(h * speed, rb.velocity.y);
        if(h > 0 && !facingRight)
        {
            Flip();
        }
        else if (h < 0 && facingRight)
        {
            Flip();
        }

        if (jump)
        {
            //zerando a velocidade do player antes pulo
            // porque segundo o professo, assim fica melhor
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
            jump = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        // pegando o atributo scale do meu component Player
        Vector3 scale = transform.localScale;
        // invertendo a escala(scale) do meu component Player
        scale.x *= -1;
        transform.localScale = scale;
    }


    public void AddWeapon(Weapon weapon)
    {
        weaponEquipped = weapon;
        GetComponentInChildren<Attack>().SetWeapon(weaponEquipped.damage);
    }

    public void UseItem(ConsumableItem item)
    {
        health += item.healthGain;
        if(health > maxHealth)
        {
            health = maxHealth;
        }

        mana += item.manaGain;
        if ((mana >= maxMana))
        {
            mana = maxMana;
        }
    }
}
