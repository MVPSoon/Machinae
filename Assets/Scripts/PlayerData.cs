using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour 
{
    public Text niveau;
    public Text experience;
    public Text sante;

    public float timeInterval;

    private float exp;
    private int level;
    private int pointCompetence;

    private int vie;
    private int att;
    private int def;

    private int currentlife;
    public void Constructor()
    {
        timeInterval = 1f;
        exp = 1f;
        level = 1;
        pointCompetence = 0;
        vie = 100;
        att = 10;
        def = 10;
        currentlife = vie;
    }
    

    void Awake()
    {
        LevelCap.LoadCap();
        if (PlayerPrefs.HasKey("PositionX"))
        {
            SaveGameData.Load();
        }
        else Constructor();
    }
    void Update()
    {
        niveau.text = "Niveau: " + level;
        sante.text = "SANTE: " + currentlife + "/" + vie;
        if (level < 3)
        {
            exp++;
            experience.text = "Exp: " + (int)exp + "/" + (int)LevelCap.GetExpLevel(level);
            if (exp == LevelCap.GetExpLevel(level))
            {
                level++;
                pointCompetence++;
                exp = 0;
            }
        }
        else
        {
            SetCurrentLife(0);
            SaveGameData.Save();
        }
    }
	
    public float GetExp ()
    {
        return exp;
    }

    public void SetExp(float experience)
    {
        exp = experience;
    }

    public int GetLevel ()
    {
        return level;
    }

    public void SetLevel (int lvl)
    {
        level = lvl;
        Debug.Log("this.level : " + this.level);
    }
    public int GetVie()
    {
        return vie;
    }

    public void SetVie (int Life)
    {
        vie = Life;
    }

    public int GetAtt()
    {
        return att;
    }

    public void SetAtt (int Atk)
    {
        att = Atk;
    }
    public int GetDef()
    {
        return def;
    }

    public void SetDef (int defense)
    {
        def = defense;
    }
    public int GetPt()
    {
        return pointCompetence;
    }

    public void SetPt(int SkillPoint)
    {
        pointCompetence = SkillPoint;
    }
    public int GetCurrentLife ()
    {
        return currentlife;
    }

    public void SetCurrentLife (int CurentLife)
    {
        currentlife = CurentLife;
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
