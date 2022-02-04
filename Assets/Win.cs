using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
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
