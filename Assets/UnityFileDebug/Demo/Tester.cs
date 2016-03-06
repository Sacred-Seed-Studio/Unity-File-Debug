using UnityEngine;
using System.Collections;
using System;

public class Tester : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Test", DLogType.AI);

        Debug.Log("Test with a super dooper long name akjlsdf klajsd lfkjads flkjasd flkjasdf ljkasdl fkjasl kfjasdlkf jasl fjaslk fjasldjf klasjfd lkasjdf klasjfd klsjadf klasjfd lkasjdf klasjdf ;lkasjfd lksajd fk", DLogType.Log);
        Debug.LogFormat("<color=green>This is a green message!</color>");
	}
}
