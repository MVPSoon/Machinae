using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void BeginGame()
    {
        Application.LoadLevel("main_scene");
    }
    public void ContinueGame()
    {
        //TODO A voir quand Romain aura fini de faire les fonctions de sauvegarde et de chargement.
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
