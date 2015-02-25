using UnityEngine;
using System.Collections;

public class SaveGameData : MonoBehaviour
{
    private static GameObject player = GameObject.FindGameObjectWithTag("Player"); 
    private static PlayerData PlayerD = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
    public static void Save ()
    {
        PlayerPrefs.SetFloat("PositionX", player.transform.position.x);
        PlayerPrefs.SetFloat("PositionY", player.transform.position.y);
        PlayerPrefs.SetFloat("PositionZ", player.transform.position.z);
        PlayerPrefs.SetFloat("Experience", PlayerD.GetExp());
        PlayerPrefs.SetInt("Level", PlayerD.GetLevel());
        PlayerPrefs.SetInt("SkillPoints", PlayerD.GetPt());
        PlayerPrefs.SetInt("Life", PlayerD.GetVie());
        PlayerPrefs.SetInt("Attack", PlayerD.GetAtt());
        PlayerPrefs.SetInt("Defense", PlayerD.GetDef());
        PlayerPrefs.SetInt("CurrentLife", PlayerD.GetCurrentLife());
        PlayerPrefs.Save();
    }

    public static void Load ()
    {
        try
        {
            player.transform.position = new Vector3(PlayerPrefs.GetFloat("PositionX"), PlayerPrefs.GetFloat("PositionY"), PlayerPrefs.GetFloat("PositionZ"));
            
            PlayerD.SetExp(PlayerPrefs.GetFloat("Experience"));
            PlayerD.SetLevel(PlayerPrefs.GetInt("Level"));
            PlayerD.SetPt(PlayerPrefs.GetInt("SkillPoints"));
            PlayerD.SetVie(PlayerPrefs.GetInt("Life"));
            PlayerD.SetAtt(PlayerPrefs.GetInt("Attack"));
            PlayerD.SetDef(PlayerPrefs.GetInt("Defense"));
            PlayerD.SetCurrentLife(PlayerPrefs.GetInt("CurrentLife"));
        }
        catch (PlayerPrefsException PrefExcept)
        {

        }
        
    }
}
