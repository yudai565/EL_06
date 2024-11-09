using UnityEngine;

public class DagashiBase : MonoBehaviour
{
	[SerializeField] private int score;
	[SerializeField] private GameObject prefNextDagashi;

	private bool isChanged = false;



	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.TryGetComponent(out DagashiBase other))
		{
			if (this.prefNextDagashi != other.prefNextDagashi) return;
			if (other.isChanged) return;

			Vector3 pos = Vector3.Lerp(this.transform.position, other.transform.position, 0.5f);
			Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, Random.Range(-180f, 180f)));
			Instantiate(prefNextDagashi, pos, rotation);

			Destroy(this.gameObject);
			Destroy(other.gameObject);

			this.isChanged = true;
		}
	}
}
