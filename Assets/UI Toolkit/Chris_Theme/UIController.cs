using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{

    private Button _button;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        _button = root.Q<Button>("button-green");

        // change style of button programatically
        // _button.style.backgroundColor = new Color(0.5f, 0.5f, 0.5f, 1f);

        _button.clicked += () =>
        {
            Debug.Log("Button Clicked");
        };

    }

    // Update is called once per frame
    void Update()
    {

    }
}
