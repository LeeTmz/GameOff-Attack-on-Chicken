using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;		

public class Funcao : MonoBehaviour {

	
public void menu()
{
	   SceneManager.LoadScene ("Menu");
}
public void Tutorial()
{
	   SceneManager.LoadScene ("Tutorial");
}
public void Créditos()
{
	   SceneManager.LoadScene ("Creditos");
}
public void Fase1()
{
	   SceneManager.LoadScene ("Fase1");
}
 public void Resetar()
{
        SceneManager.LoadScene("MapaPrincipal");
}

public void Sair()
{
	Application.Quit();
}

}
