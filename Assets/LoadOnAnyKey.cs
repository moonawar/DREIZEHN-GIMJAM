using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnAnyKey : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("HowToPlay");
        }
    }
}
