// ----------------------------------------------------------------------
// -------------------- 3D Hit Text
// -------------------- David Dorrington, UoB, 2023
// ----------------------------------------------------------------------
using UnityEngine;

public class DD_Hit_Text : MonoBehaviour
{
	public float fl_life_time = 2;
	public float fl_speed = 3;
    // ----------------------------------------------------------------------

    void Start()
	{
		Destroy(gameObject, fl_life_time);
		transform.LookAt(GameObject.FindWithTag("MainCamera").transform.position);
		transform.Rotate(0,180,0);
	}//-----

	// Update is called once per frame
	void Update()
	{
		// Animate the Text Upwards
		transform.Translate(0, fl_speed * Time.deltaTime, 0);
	}//-----

}//==========
