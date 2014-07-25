using UnityEngine;
using System.Collections;

public class CubeMover : MonoBehaviour {

	public GameObject FixedCube;
	public GameObject AccCube;


	public float CubeSpeed;
	public float AccSpeed;
	public float MaxAccSpeed;
	public float SpeedIncrement;
	public float Friction;
	private Vector3 MoveLeftVector;

	// Use this for initialization
	void Start () {
		FixedCube.transform.position = new Vector3(0, 0, 0);
		AccCube.transform.position = new Vector3(0, 0, 2.0f);

		CubeSpeed = 0.05f;
		AccSpeed = 0.0f;
		MaxAccSpeed = CubeSpeed * 4;
		SpeedIncrement = 0.001f;
		Friction = SpeedIncrement / 2;

		MoveLeftVector = new Vector3(-CubeSpeed, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKey(KeyCode.RightArrow)) {
			FixedCube.transform.position = new Vector3(FixedCube.transform.position.x + CubeSpeed, FixedCube.transform.position.y, FixedCube.transform.position.z);
		} else if (Input.GetKey(KeyCode.LeftArrow)) {
			FixedCube.transform.Translate(MoveLeftVector);
		}
		if (Input.GetKey(KeyCode.D)) {
			AccSpeed += SpeedIncrement;
			if (AccSpeed > MaxAccSpeed) {
				AccSpeed = MaxAccSpeed;
			}
		} else if (Input.GetKey(KeyCode.A)) {
			AccSpeed -= SpeedIncrement;
			if (AccSpeed < (-1 * MaxAccSpeed)) {
				AccSpeed = -1 * MaxAccSpeed;
			}
		}
		if (AccSpeed < Friction && AccSpeed > (-1 * Friction)) {
			AccSpeed = 0.0f;
		} else {
			AccCube.transform.position = new Vector3(AccCube.transform.position.x + AccSpeed, AccCube.transform.position.y, AccCube.transform.position.z);
			if (AccSpeed > Friction) {
				AccSpeed -= Friction;
			} else {
				AccSpeed += Friction;
			}
		}
	}
}
