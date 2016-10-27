using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {

	[Header("Units")]
	public GameObject currentSelection;
    public GameObject[] turrets;
	public float NumOfTurret = 0;
	public float NumOfML = 0;
	public float MaxNum = 10;


	[Header("FPS Mode")]
	public bool FPSAvailable;
	public GameObject[] Weapons;
	public GameObject Equipped;

	[Header("Camera Control")]
	public static bool FPSon;
	public static bool RTSon;
	public GameObject FPS;
	public GameObject RTS;

	[Header("HUD Settings")]
	public GameObject RTSHud;
	public GameObject FPSHud;
	public Text Ammo_UIText;
	public Text CurrencyText;
	public Text MGlimit;
	public Text MLlimit;
	public static int coins;
	public static int totalcoins;
	public int currency;
	private int CostOfTurret = 50;
	private int CostOfMl = 100;
	private int CostOfHealth = 1000;
	private int CostOfAmmo = 500;
	public Button turret;
	public Button ml;
	public static float numofkilled;
	public static string maxnumofkill;
	public InputField maxnum;
	public InputField setcoins;
	public Text numkilled;
	public Text vic;
	public GameObject win;
	public GameObject lose;
	[Header("Menu")]
	public static bool pause = false;
	public static bool play;


    // Use this for initialization
    void Start()
    {
		numofkilled = 0;
		coins = 500;
		RTSon = true;
		FPSon = false;
		Ammo_UIText.text = "";
        currentSelection = null;
		pause = true;
    }

    // Update is called once per frame
    void Update()
	{

		if (pause == true) {
			Time.timeScale = 0;

		}
		else
			Time.timeScale = 1;
		if (!pause) {

			
			maxnumofkill = maxnum.text;
			numkilled.text = "Enemy killed: " + numofkilled + "/" +  maxnumofkill;
			currency = coins;
			CurrencyText.text = currency.ToString ();
			MGlimit.text = NumOfTurret + "/" + MaxNum;
			MLlimit.text = NumOfML + "/" + MaxNum;
			Ammo_UIText.text = FPSshooting.bullets.ToString () + "/" + FPSshooting.clips;
			if (currentSelection != null) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit = new RaycastHit ();

				if (Physics.Raycast (ray, out hit, 1000f)) {
					Debug.Log ("raycast hit!");
					if (hit.transform.tag == "Ground") {
						Debug.Log ("raycast hit Ground!");
						if (Input.GetMouseButtonUp (0) && !EventSystem.current.IsPointerOverGameObject ()) {

							Instantiate (currentSelection, hit.point, Quaternion.identity);
							if (currentSelection == turrets [0]) {
								NumOfTurret++;
								coins = coins - CostOfTurret;
								currentSelection = null;
							} else if (currentSelection == turrets [1]) {
								NumOfML++;
								coins = coins - CostOfMl;
								currentSelection = null;
							}
						}

					}
				}
		
			}

			if (currency < CostOfTurret || NumOfTurret == MaxNum) {
				turret.interactable = false;
			} else {
				turret.interactable = true;
			}
			if (currency < CostOfMl || NumOfML == MaxNum) {
				ml.interactable = false;
			} else {
				ml.interactable = true;
			}
		
			if (Input.GetKeyDown (KeyCode.F)) {
				if (RTSon == true && FPSAvailable == true) {
					FPSon = true;
					RTSon = false;
					FPS.SetActive (true);
					RTS.SetActive (false);
					FPSHud.SetActive (true);

					Cursor.visible = false;
				} else if (FPSon == true) {
					FPSon = false;
					RTSon = true;
					FPS.SetActive (false);
					RTS.SetActive (true);
					FPSHud.SetActive (false);
					Cursor.visible = true;
				} 
			}

			if (FPSControl.HandGun == true) {
				Weapons [1].SetActive (false);
				Weapons [2].SetActive (false);
				Weapons [0].SetActive (true);
				Equipped = Weapons [0];
			} else if (FPSControl.Assault == true) {
				Weapons [0].SetActive (false);
				Weapons [2].SetActive (false);
				Weapons [1].SetActive (true);
				Equipped = Weapons [1];

			} else if (FPSControl.ShotGun == true) {
				Equipped = Weapons [2];
				Weapons [2].SetActive (true);
				Weapons [0].SetActive (false);
				Weapons [1].SetActive (false);
			}
			if (FPShealth.death == true) {
				FPSAvailable = false;
				FPSon = false;
				RTSon = true;
				FPS.SetActive (false);
				RTS.SetActive (true);
				FPSHud.SetActive (false);
				RTSHud.SetActive (true);
				Cursor.visible = true;
			}
			if (numofkilled.ToString() == maxnumofkill) {
				winscreen ();
			}
			if (BaseHealth.death == true)
				losescreen ();
		}

	}
    public void SelectTurret(int i)
    {
        if (i < turrets.Length)
        {
            currentSelection = turrets[i];
        }
}
	public void winscreen(){
		win.SetActive(true);
		pause = true;
		vic.text = "Enemy killed: " + numofkilled + "\n" + "Coins Gained: " + totalcoins;
	}
	public void losescreen(){
		lose.SetActive(true);
		pause = true;
		Cursor.visible = true;
	}
}
