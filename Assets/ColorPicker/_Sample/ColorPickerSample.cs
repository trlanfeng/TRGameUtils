using UnityEngine;
using System.Collections;

public class ColorPickerSample : MonoBehaviour {

    ColorPick cp;
	// Use this for initialization
	void Start () {
        cp = transform.GetComponent<ColorPick>();
	}
	
	// Update is called once per frame
	void Update () {
        Camera.main.backgroundColor = cp.useColor;
	}
}
