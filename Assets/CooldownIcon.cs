using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownIcon : MonoBehaviour
{
    public Image Explosive;
    float cooldown;
    public GameObject player;

    
    // Start is called before the first frame update
    void Start()
    {
        Explosive.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
