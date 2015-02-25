using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour 
{

    public Text life;
    public Text att;
    public Text def;
    public Text ptCompetence;

    public Button btlife;
    public Button btatt;
    public Button btdef;

    private bool paused = false;
 
    private float groupWidth = 300;
    private float groupHeight = 200;

    private GameObject menu;
    private PlayerData player;
    private Text test;

    void Awake()
    {
        Screen.lockCursor = false;
        menu = GameObject.FindGameObjectWithTag("PauseMenu");
        menu.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
    }


    void Update ()
    {
            if (Input.GetButtonUp("Pause") && paused == false)
            {
                paused = true;
                Time.timeScale = 0;
                MouseOrbit.enableMovement = false;
                menu.SetActive(true);
            }
            else if (Input.GetButtonUp("Pause") && paused == true)
            {
                paused = false;
                Time.timeScale = 1;
                MouseOrbit.enableMovement = true;
                menu.SetActive(false);
            }

            MajMenu();
    }

    void MajMenu()
    {
        life.text = "Vie: " + player.GetVie();
        att.text = "Attaque: " + player.GetAtt();
        def.text = "Defense: " + player.GetDef();
        ptCompetence.text = "Points de compétence restants: " + player.GetPt();
        StateButton();
    }

    void StateButton()
    {
        if(player.GetPt()== 0)
        {
            btlife.interactable = false;
            btatt.interactable = false;
            btdef.interactable = false;
        }
        else
        {
            btlife.interactable = true;
            btatt.interactable = true;
            btdef.interactable = true;
        }
    }

}
