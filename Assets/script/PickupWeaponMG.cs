using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickupWeaponMG : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;
    Transform image1;
    Transform image2;
    Transform image3;

    // Start is called before the first frame update
    void Start()
    {
        image1 = canvas.transform.GetChild(0);
        image2 = canvas.transform.GetChild(1);
        image3 = canvas.transform.GetChild(2);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject g = GameObject.Find("Weapons");
            other.GetComponent<WeaponController>().SetAmmoMG42(100);
            other.GetComponent<WeaponController>().SetActiveWeapon(1);
            other.GetComponent<WeaponController>().disableWeapons();
            other.GetComponent<WeaponController>().enableWeapons(1);
            List<bool> ListUnlocked = other.GetComponent<WeaponController>().GetListUnlocked();
            if (ListUnlocked[1])
            {
                List<bool> ListActivated = other.GetComponent<WeaponController>().GetListActivated();

                for (var i = 0; i < ListActivated.Count; i++)
                {
                    g.transform.GetChild(i).gameObject.SetActive(false);
                    //ListActivated[i] = false;
                }
                g.transform.GetChild(1).gameObject.SetActive(true);
                image1.GetComponent<Image>().color = new Color32(0, 0, 0, 130);
                image2.GetComponent<Image>().color = new Color32(0, 0, 0, 207);
                image3.GetComponent<Image>().color = new Color32(0, 0, 0, 130);
                //image2.GetChild(1).GetComponent<TextMeshProUGUI>().text = "MG42";

                Debug.Log("Nom de l'arme : "+ image2.GetChild(1).GetComponent<TextMeshProUGUI>().name);

            }
            Destroy(gameObject);

        }
    }




}
