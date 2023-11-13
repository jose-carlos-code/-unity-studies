using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoBoss : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void criaBoss()
    {
        Instantiate(boss, transform.position, transform.rotation);

        //me matando
        //pegando o gameObject do meu pai
        var meuPai = transform.parent.gameObject;
        Destroy(meuPai);
    }
}
