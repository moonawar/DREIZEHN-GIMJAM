using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBar : MonoBehaviour
{
    int maxHealth = 5;
    public void SetHeartBarDown(int health){
        for (int i = maxHealth; i > health; i--)
        {
            if (i >= 1 && i < maxHealth+1)
            {
                transform.GetChild(i-1).gameObject.SetActive(false);
            }  
        }
    }

    public void SetHeartBarUp(int health){
        for (int i = 0; i < health; i++)
        {
            if (i >= 0 && i < maxHealth+1)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }  
        }
    }
}
