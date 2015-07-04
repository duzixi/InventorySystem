using UnityEngine;
using System.Collections;

public class Info : MonoBehaviour {

	public static string debugStr = "";

	void OnGUI() {
		GUILayout.Label(debugStr);

	}
}
