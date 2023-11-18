using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerController : MonoBehaviour
{
    //ESSE EVENTO VEM ANTES MESMO DO START!
    private void Awake()
    {
        //Garantindo que só existe 1 game manager por vez
        //contando quantos game managers existem na cena;
        int quantidade = FindObjectsOfType<GameManagerController>().Length;

        //Se existir um game manager eu o mantenho nas proxima cenas
        if(quantidade > 1)
        {
            //Eu não vou ser destruído quando ele mudar de cena;
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    //criando um método que roda depois de um certo tempo
    //iss daqui de baixo é uma corrotina, vou aprender mais sobre isso depois
    //uma corrotina é como se fosse um mini script dentro do meu script maior. 
    //é tipo um script simplificado
    IEnumerator PrimeiraCena()
    {
        yield return new WaitForSeconds(2f);
        //to o código daqui só vai rodar depois de 2 segundos
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        
    }

    //criando o método para ir para o jogo
    public void IniciaJogo()
    {
        //carregar a cena que tem o meu jogo
        SceneManager.LoadScene("Jogo1");
    }

    //criando o método para ir para a tela inicial
    public void Inicio()
    {
        //iniciando minha corrotina
        StartCoroutine(PrimeiraCena());
    }

    public void Sair()
    {
        Application.Quit();
    }
}   
