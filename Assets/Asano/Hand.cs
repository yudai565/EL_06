using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Hand : MonoBehaviour
{
	[SerializeField]
	List<GameObject> dagashis;

	[SerializeField]
	GameObject dagashiPos;

	[SerializeField]
	float moveRange;

	[SerializeField]
	float speed;

	[SerializeField]
	public List<Collider2D> gameoverZones;

	[SerializeField]
	string resultSceneName;


	private GameObject holdDagashi;

	public static Hand inst;




	private void Start()
	{
		inst = this;

		Generate();
	}


	private void FixedUpdate()
	{
		if (holdDagashi != null)
			holdDagashi.transform.position = dagashiPos.transform.position;


		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			if (this.transform.position.x > -moveRange)
			{
				var pos = this.transform.position;
				pos.x -= speed * Time.deltaTime;
				this.transform.position = pos;
			}
		}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			if (this.transform.position.x < +moveRange)
			{
				var pos = this.transform.position;
				pos.x += speed * Time.deltaTime;
				this.transform.position = pos;
			}
		}


		// ç∂ÉNÉäÉbÉN
		if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
		{
			if (holdDagashi == null) return;

			// éËï˙Ç∑
			holdDagashi.GetComponents<Collider2D>().Select(col => col.isTrigger = false);
			foreach (var col in holdDagashi.GetComponents<Collider2D>())
				col.enabled = true;
			holdDagashi.GetComponent<Rigidbody2D>().simulated = true;
			holdDagashi.GetComponent<DagashiBase>().isHold = false;
			holdDagashi.GetComponent<DagashiBase>().isReleased = true;
			holdDagashi.transform.position += Vector3.down * 1f;
			holdDagashi = null;
		}
	}

	public void Generate()
	{
		if (holdDagashi != null) return;

		// ê∂ê¨
		holdDagashi = Instantiate(dagashis[Random.Range(0, dagashis.Count)], this.transform.position, Quaternion.identity);
		holdDagashi.transform.position = dagashiPos.transform.position;
	}


	private void OnDestroy()
	{
		inst = null;
	}





	public void LoadResultScene()
	{
		Score.instance.UpdateHighScore();
		SceneManager.LoadScene(resultSceneName);
	}
}
