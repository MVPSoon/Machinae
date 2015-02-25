using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour 
{

    public Text niveau;
    public Text experience;
    public Text sante;

    public float timeInterval = 1f;

    private float exp = 1;
    private int level = 0;
    private int pointCompetence = 0;

    private int vie = 100;
    private int att = 10;
    private int def = 10;

    private int currentlife;

    void Awake()
    {
        LevelCap.LoadCap();
        currentlife = vie;
    }
    void Update()
    {
        sante.text = "SANTE: " + currentlife + "/" + vie;
        if (level < 4)
        {
            exp++;
            experience.text = "Exp: " + (int)exp + "/" + (int)LevelCap.GetExpLevel(level);
            if (exp == LevelCap.GetExpLevel(level))
            {
                level++;
                pointCompetence++;
                exp = 0;
            }
            niveau.text = "Niveau: " + (level+1);

        }
    }
	
    public int GetVie()
    {
        return vie;
    }

    public int GetAtt()
    {
        return att;
    }
    public int GetDef()
    {
        return def;
    }
    public int GetPt()
    {
        return pointCompetence;
    }
    public void AddLife()
    {
        
        vie += 10;
        pointCompetence--;
    }

    public void AddAtt()
    {
        att += 1;
        pointCompetence--;
    }
    
    public void AddDef()
    {
        def += 1;
        pointCompetence--;
    }

}
