using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {
	public GameObject room;

	// Use this for initialization
	void Start () {
		//Read map from file
		string[] map = System.IO.File.ReadAllLines ("Assets/Files/map.txt");

		//Create rooms
		for (int i = 0; i < map.Length; i += 2) {
			for (int j = 0; j < map [i].Length; j += 2) {
				if (map [i] [j] != '0') {
					//Instantiate room
					GameObject go = (GameObject)Instantiate (room, new Vector3(), Quaternion.identity);

					//Set room's parent
					go.transform.parent = transform;

					//Move room to correct space
					go.transform.localPosition = new Vector3(3 * (j / 2), map[i][j] / 2f, 3 * ((map.Length - 1 - i) / 2));

					/*
					 * Children of room
					 * 0 - floor
					 * 1 - ceiling
					 * 2 - North
					 * 3 - East
					 * 4 - South
					 * 5 - West
					*/

					//Disable walls between adjacent rooms
					//North wall
					if (i > 0 && map [i - 2] [j] != '0' && !(map[i - 1][j] == ',')) {
						go.transform.GetChild (2).gameObject.SetActive (false);
					}

					//East
					if (j < map [i].Length - 2 && map [i] [j + 2] != '0' && !(map[i][j + 1] == ',')) {
						go.transform.GetChild (3).gameObject.SetActive (false);
					}

					//South
					if (i < map.Length - 1 && map [i + 2] [j] != '0' && !(map[i + 1][j] == ','))
						go.transform.GetChild (4).gameObject.SetActive (false);

					//West
					if (j > 0 && map [i] [j - 2] != '0' && !(map[i][j - 1] == ','))
						go.transform.GetChild (5).gameObject.SetActive (false);

					//Add low walls between rooms of differing height
					//North
					if (i > 0 && map[i - 2][j] != '0' && map [i] [j] > map [i - 2] [j]) {
						go.transform.GetChild (2).gameObject.SetActive (true);
						go.transform.GetChild (2).transform.localPosition -= new Vector3 (0, 3, 0);
					}

					//East
					if (j < map.Length - 1 && map[i][j + 2] != '0' && map [i] [j] > map [i] [j + 2]) {
						go.transform.GetChild (3).gameObject.SetActive (true);
						go.transform.GetChild (3).transform.localPosition -= new Vector3 (0, 3, 0);
					}

					//South
					if (i < map.Length - 1 && map[i + 2][j] != '0' && map [i] [j] > map [i + 2] [j]) {
						go.transform.GetChild (4).gameObject.SetActive (true);
						go.transform.GetChild (4).transform.localPosition -= new Vector3 (0, 3, 0);
					}

					//West
					if (j > 0 && map[i][j - 2] != '0' && map [i] [j] > map [i] [j - 2]) {
						go.transform.GetChild (5).gameObject.SetActive (true);
						go.transform.GetChild (5).transform.localPosition -= new Vector3 (0, 3, 0);
					}
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
