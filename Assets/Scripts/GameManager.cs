using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public GameObject currentSelection;
    public GameObject[] turrets;


    // Use this for initialization
    void Start()
    {
        currentSelection = null;

    }

    // Update is called once per frame
    void Update()
    {
        if (currentSelection != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit, 100f))
            {
                Debug.Log("raycast hit!");
                if (hit.transform.tag == "Ground")
                {
                    Debug.Log("raycast hit Ground!");
                    if (Input.GetMouseButtonUp(0))
                    {
                        Instantiate(currentSelection, hit.point, Quaternion.identity);
                        currentSelection = null;
                    }
                }
            }
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
