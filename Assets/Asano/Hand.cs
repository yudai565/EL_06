using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
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


	private GameObject holdDagashi;




	private void Start()
	{
		// ê∂ê¨
		holdDagashi = Instantiate(dagashis[Random.Range(0, dagashis.Count)], this.transform.position, Quaternion.identity);
		foreach (var col in holdDagashi.GetComponents<Collider2D>())
			col.isTrigger = true;
		holdDagashi.GetComponent<Rigidbody2D>().simulated = false;
	}


	private void FixedUpdate()
	{
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
			// éËï˙Ç∑
			holdDagashi.GetComponents<Collider2D>().Select(col => col.isTrigger = false);
			foreach (var col in holdDagashi.GetComponents<Collider2D>())
				col.isTrigger = false;
			holdDagashi.GetComponent<Rigidbody2D>().simulated = true;
			holdDagashi.GetComponent<DagashiBase>().isHold = false;
			holdDagashi.transform.position += Vector3.down * 1f;

			// ê∂ê¨
			holdDagashi = Instantiate(dagashis[Random.Range(0, dagashis.Count)], this.transform.position, Quaternion.identity);
			foreach(var col in holdDagashi.GetComponents<Collider2D>())
				col.isTrigger = true;
			holdDagashi.GetComponent<Rigidbody2D>().simulated = false;
		}
	}
}
