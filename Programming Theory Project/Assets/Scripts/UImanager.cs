using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckEnter();
    }

    void CheckEnter()
    {
        if (Input.GetKeyDown(KeyCode.Return) && inputField.text.Length >= 1)
        {
            Debug.Log(inputField.text);
            DontDestroy.Instance.name = inputField.text;
            SceneManager.LoadScene(1);
        }
    }
}
