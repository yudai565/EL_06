using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DagashiBase : MonoBehaviour
{
	[SerializeField] private int score;
	[SerializeField] private GameObject prefNextDagashi;


	

	private bool isChanged = false;
	public bool isHold = true;
	public bool isReleased = false;



	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (isHold) return;

		foreach (var col in collision.gameObject.GetComponents<Collider>())
			if (!col.enabled) return;


		if (isReleased)
		{
			Hand.inst.Generate();
			isReleased = false;
		}


		if (collision.gameObject.TryGetComponent(out DagashiBase other))
		{
			if (this.prefNextDagashi != other.prefNextDagashi) return;

			if (other.isChanged)
			{
				this.isChanged = true;
				return;
			}

			Destroy(this.gameObject);
			Destroy(other.gameObject);

			this.isChanged = true;

			Score.instance.AddScore(score);

			if (prefNextDagashi == null) return;

			Vector3 pos = Vector3.Lerp(this.transform.position, other.transform.position, 0.5f);
			Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, Random.Range(-180f, 180f)));
			var tmpDagashi = Instantiate(prefNextDagashi, pos, rotation);
			tmpDagashi.GetComponent<DagashiBase>().isHold = false;
			foreach (var col in tmpDagashi.GetComponents<Collider2D>())
				col.enabled = true;
			tmpDagashi.GetComponent<Rigidbody2D>().simulated = true;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (isHold) return;
		if (isReleased) return;


		if (Hand.inst.gameoverZones.Contains(collision))
		{
			Hand.inst.LoadResultScene();
		}
	}
}
