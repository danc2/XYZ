using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[Header("Units")]
	public GameObject currentSelection;
    public GameObject[] turrets;

	[Header("Waves Settings")]
	[Range(1,10)]
	public int NumberOfWave;

	[Header("Health Settings")]
	public int UnitsHealth = 100;
	public int FPSHealth = 100;
	public int EnemyHealth = 100;

	[Header("FPS Mode")]
	public bool FPSAvailable;
	public GameObject[] Weapons;
	public GameObject Equipped;

	[Header("Camera Control")]
	public bool FPSon;
	public bool RTSon;
	public GameObject FPS;
	public GameObject RTS;

	[Header("HUD Settings")]
	public GameObject RTSHud;
	public GameObject FPSHud;

    // Use this for initialization
    void Start()
    {
		RTSon = true;
		FPSon = false;

        currentSelection = null;
    }

    // Update is called once per frame
    void Update()
	{
		if (currentSelection != null) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit = new RaycastHit ();

			if (Physics.Raycast (ray, out hit, 1000f)) {
				Debug.Log ("raycast hit!");
				if (hit.transform.tag == "Ground") {
					Debug.Log ("raycast hit Ground!");
					if (Input.GetMouseButtonUp (0)) {
						Instantiate (currentSelection, hit.point, Quaternion.identity);
						currentSelection = null;
					}
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.F)) {
			if (RTSon == true && FPSAvailable == true) {
				FPSon = true;
				RTSon = false;
				FPS.SetActive (true);
				RTS.SetActive (false);
				FPSHud.SetActive (true);
				RTSHud.SetActive (false);
				Cursor.visible = false;
			} else if (FPSon == true) {
				FPSon = false;
				RTSon = true;
				FPS.SetActive (false);
				RTS.SetActive (true);
				FPSHud.SetActive (false);
				RTSHud.SetActive (true);
				Cursor.visible = true;
			} 

		}

		if (FPSControl.HandGun == true) {
			

			Weapons[1].SetActive (false);
			Weapons[2].SetActive (false);
			Weapons[0].SetActive (true);
			Equipped = Weapons [0];
		} else if (FPSControl.Assault == true) {
			

			Weapons[0].SetActive (false);
			Weapons[2].SetActive (false);
			Weapons[1].SetActive (true);
			Equipped = Weapons [1];

		}  else if (FPSControl.ShotGun == true) {
			Equipped = Weapons [2];
			Weapons[2].SetActive (true);
			Weapons[0].SetActive (false);
			Weapons[1].SetActive (false);

		}
	}
    public void SelectTurret(int i)
    {
        if (i < turrets.Length)
        {
            currentSelection = turrets[i];
        }
}
}
