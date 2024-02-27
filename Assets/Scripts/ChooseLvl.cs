using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseLvl : MonoBehaviour
{
    public int levelIndex; // Håller reda på vilken nivå knappen representerar

    void Start()
    {
        // Hämta referensen till knappen och lägg till en lyssnare för dess klickhändelse
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        // Ladda den specifika nivån när knappen klickas
        SceneManager.LoadScene(levelIndex);
    }
}
