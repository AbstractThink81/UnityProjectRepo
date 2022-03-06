using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeOpacityOnCollision : MonoBehaviour
{
	public float opacityChanged;
	public Tilemap tilemap;
	//private Color color;
	public void Start()
	{
		//color = tilemap.color;
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
			StartCoroutine(ChangeOpacity(opacityChanged));
	}
	IEnumerator ChangeOpacity(float newOpacity)
	{
		if (newOpacity < tilemap.color.a)
		{
			while (tilemap.color.a > newOpacity)
			{
				tilemap.color = new Vector4(tilemap.color.r, tilemap.color.g, tilemap.color.b, tilemap.color.a - 0.05f);
				yield return new WaitForSeconds(0.01f);
			}
		}
		else
		{
			while (tilemap.color.a < newOpacity)
			{
				tilemap.color = new Vector4(tilemap.color.r, tilemap.color.g, tilemap.color.b, tilemap.color.a + 0.05f);
				yield return new WaitForSeconds(0.01f);
			}
		}
		tilemap.color = new Vector4(tilemap.color.r, tilemap.color.g, tilemap.color.b, newOpacity);
	}
}
