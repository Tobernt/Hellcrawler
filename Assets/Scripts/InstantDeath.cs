using UnityEngine;

public class InstantDeath : MonoBehaviour
{
	public GameObject Player = new GameObject("Player");

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Destroy(collision.gameObject);
	}
	private void OnCollisionEnter(Collision collision)
	{
		Destroy(collision.gameObject);
	}
	private void Start()
	{

	}
	void Update()
	{

	}
}