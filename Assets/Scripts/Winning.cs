using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Winning : MonoBehaviour
{
    public GameObject win;
    public void Awake()
    {
        win.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        win.SetActive(true);
    }
}
