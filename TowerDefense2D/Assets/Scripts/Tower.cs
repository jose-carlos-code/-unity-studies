using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public float towerPrice;
    public float attackDamage;
    public float attackRange;
    public float attackSpeed;
    public GameObject projectTile;
    GameObject targetEnemy;
    float attackCooldown;


    // Building mode

    [SerializeField] private GameObject buildButton;

    // Esta no modo construcao ou nao?
    bool isBuilding = true;

    int blockedCount;
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }

    void Update()
    {
        if(isBuilding == true){buildingMode();}
    }

    void FixedUpdate()
    {
        if(isBuilding == false){Shoot();}
    }

    void Shoot()
    {
        // garantindo que: se o alvo não existir ou estiver muito longe, a torre não atira.
        if(targetEnemy == null || Vector2.Distance(transform.position, targetEnemy.transform.position) > attackRange)
        {   
           targetEnemy =  FindTarget();
        }
        else
        {
            if(attackCooldown > attackSpeed)
            {
                GameObject projectTileInstance = Instantiate(projectTile, transform.position, Quaternion.identity);
                projectTileInstance.GetComponent<Project>().projectTileDamage = attackDamage;
                projectTileInstance.GetComponent<Project>().target_ = targetEnemy.transform;
                attackCooldown = 0f;
            }
            else
            {
                attackCooldown+= Time.deltaTime;
            }

        }
       
    }

    GameObject FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject e_ in enemies)
        {
            if (Vector2.Distance(transform.position, e_.transform.position) < attackRange)
            {
                return e_;
            }
        }
        return null;
    }

    void buildingMode()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = transform.position.z;
        transform.position = mousePosition;

        if(blockedCount == 0 &&   WaveManager.Instance.player_money >= towerPrice)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            // pode construir
            if (Input.GetMouseButtonUp(0))
            {
                isBuilding = false;
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                WaveManager.Instance.player_money -= towerPrice;
                WaveManager.Instance.UpdateHUD();
                BuildManager.Instance.buildUI.SetActive(true);
            }
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            // nao pode construir
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BuildManager.Instance.buildUI.SetActive(true);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Blocked")
        {
            blockedCount++;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Blocked")
        {
            blockedCount--;
        }
    }
}
