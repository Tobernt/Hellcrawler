using UnityEngine;
using UnityEngine.SceneManagement;

public class StartOver : MonoBehaviour
{
	public void StartScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
