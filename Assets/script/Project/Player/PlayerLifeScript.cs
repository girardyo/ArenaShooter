using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeScript : LifeScript
{
    public Image LifeBar;
    private bool isPlayerDead=false;
    public Canvas canvas;

    public override void Death()
    {
        Debug.Log("DEATH");
        isPlayerDead = true;
        canvas.enabled = true;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
    }

    public override void End()
    {
        //TODO Rolad scene
    }

    public override void UpdateLife(int nb)
    {
        base.UpdateLife(nb);
        LifeBar.fillAmount = (float)CurrentLife / (float)MaxLife;

    }


    public bool getIsPlayerDead()
    {
        return isPlayerDead;
    }
}
