using UnityEngine;
using UnityEngine.UI;

public class SceneButtonScript : MonoBehaviour
{
    [SerializeField] Loader.Scene scene;

    public Button sceneButton;

    void Start()
    {
        Button btn = sceneButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {

        Loader.Load(scene);
    }
}
