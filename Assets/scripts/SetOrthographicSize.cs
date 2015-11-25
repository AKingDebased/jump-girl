using UnityEngine;
using System.Collections;

public class SetOrthographicSize : MonoBehaviour {

	private float baseOrthographicSize;

	void Start () {
		baseOrthographicSize = Screen.height / 64.0f / 2.0f;
		Camera.main.orthographicSize = baseOrthographicSize;
	}
}
