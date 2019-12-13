using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    Image image1;
    [SerializeField]
    Image image2;
    [SerializeField]
    Image image3;

    [SerializeField]
    int AmmoPistol;
    [SerializeField]
    int AmmoMG42;
    [SerializeField]
    int AmmoGrenade;

    [SerializeField]
    private List<bool> WeaponListUnlocked = new List<bool>();
    [SerializeField]
    private List<bool> WeaponListActivated = new List<bool>();


    GameObject AmmunationG;
    // Start is called before the first frame update
    void Start()
    {
        AmmunationG = GameObject.FindGameObjectWithTag("Ammo");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("1");
            GameObject g = GameObject.Find("Weapons");

            List<bool> ListUnlocked = GetComponent<WeaponController>().GetListUnlocked();
            if (ListUnlocked[0])
            {
                SetAmmoPistol(0);

                GetComponent<WeaponController>().disableWeapons();
                GetComponent<WeaponController>().enableWeapons(0);
                List<bool> ListActivated = GetComponent<WeaponController>().GetListActivated();

                for (var i = 0; i < ListActivated.Count; i++)
                {
                    g.transform.GetChild(i).gameObject.SetActive(false);
                    //ListActivated[i] = false;
                }
                g.transform.GetChild(0).gameObject.SetActive(true);
                image1.GetComponent<Image>().color = new Color32(0, 0, 0, 207);
                image2.GetComponent<Image>().color = new Color32(0, 0, 0, 130);
                image3.GetComponent<Image>().color = new Color32(0, 0, 0, 130);

            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("2");
            GameObject g = GameObject.Find("Weapons");

            List<bool> ListUnlocked = GetComponent<WeaponController>().GetListUnlocked();
            if (ListUnlocked[1])
            {
                SetAmmoMG42(0);

                GetComponent<WeaponController>().disableWeapons();
                GetComponent<WeaponController>().enableWeapons(1);
                List<bool> ListActivated = GetComponent<WeaponController>().GetListActivated();

                for (var i = 0; i < ListActivated.Count; i++)
                {
                    g.transform.GetChild(i).gameObject.SetActive(false);
                    //ListActivated[i] = false;
                }
                g.transform.GetChild(1).gameObject.SetActive(true);
                image1.GetComponent<Image>().color = new Color32(0, 0, 0, 130);
                image2.GetComponent<Image>().color = new Color32(0, 0, 0, 207);
                image3.GetComponent<Image>().color = new Color32(0, 0, 0, 130);
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("3");
            GameObject g = GameObject.Find("Weapons");

            List<bool> ListUnlocked = GetComponent<WeaponController>().GetListUnlocked();
            if (ListUnlocked[2])
            {
                SetAmmoGrenade(0);

                GetComponent<WeaponController>().disableWeapons();
                GetComponent<WeaponController>().enableWeapons(2);
                List<bool> ListActivated = GetComponent<WeaponController>().GetListActivated();

                for (var i = 0; i < ListActivated.Count; i++)
                {
                    g.transform.GetChild(i).gameObject.SetActive(false);
                    //ListActivated[i] = false;
                }
                g.transform.GetChild(2).gameObject.SetActive(true);
                image1.GetComponent<Image>().color = new Color32(0, 0, 0, 130);
                image2.GetComponent<Image>().color = new Color32(0, 0, 0, 130);
                image3.GetComponent<Image>().color = new Color32(0, 0, 0, 207);
            }
        }
    }

    public void SetActiveWeapon(int Num)
    {
        WeaponListUnlocked[Num] = true;
        Debug.Log("Weapon Activated");
    }

    public void SetUnActiveWeapon(int Num)
    {
        WeaponListUnlocked[Num] = false;
        Debug.Log("Weapon Deactivated");
    }

    public void disableWeapons()
    {
        for (var i = 0; i < WeaponListActivated.Count; i++)
        {
            WeaponListActivated[i] = false;
        }
    }

    public void enableWeapons(int Num)
    {
        WeaponListActivated[Num] = true;
    }

    public List<bool> GetListUnlocked()
    {
        return WeaponListUnlocked;
    }

    public List<bool> GetListActivated()
    {
        return WeaponListActivated;
    }

    public int GetAmmoPistol()
    {
        return AmmoPistol;
    }

    public void SetAmmoPistol(int ammoAdded)
    {
        AmmoPistol += ammoAdded;
        AmmunationG.GetComponent<AmmunationUI>().ResetAmmunation();
        AmmunationG.GetComponent<AmmunationUI>().AmmunationUpdate(AmmoPistol);
    }

    public int GetAmmoMG42()
    {
        return AmmoMG42;
    }

    public void SetAmmoMG42(int ammoAdded)
    {
        AmmoMG42 += ammoAdded;
        AmmunationG.GetComponent<AmmunationUI>().ResetAmmunation();
        AmmunationG.GetComponent<AmmunationUI>().AmmunationUpdate(AmmoMG42);

    }

    public int GetAmmoGrenade()
    {
        return AmmoGrenade;
    }

    public void SetAmmoGrenade(int ammoAdded)
    {
        AmmoGrenade += ammoAdded;
        AmmunationG.GetComponent<AmmunationUI>().ResetAmmunation();
        AmmunationG.GetComponent<AmmunationUI>().AmmunationUpdate(AmmoGrenade);

    }

}
