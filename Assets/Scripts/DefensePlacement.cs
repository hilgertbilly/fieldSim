using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DefensePlacement : MonoBehaviour {

	public Transform[] choiceA;
	public Transform[] choiceB;

	public Transform[] redMounts;
	public Transform[] blueMounts;

	void Start () {
		if (choiceA.Length != 4 ||
			choiceB.Length != 4 ||
			redMounts.Length != 4 ||
			blueMounts.Length != 4) {
			Debug.LogError("Not all slots filled");
			return;
		}

		List<Transform> redDefenses = new List<Transform>();
		for (int i = 0; i < 4; i++) {
			Transform nextDefense;
			if (Random.value < 0.5)
				nextDefense = choiceA[i];
			else
				nextDefense = choiceB[i];

			redDefenses.Add(nextDefense);
		}
		redDefenses.OrderBy(u => Random.value);
		for (int i = 0; i < 4; i++) {
			Transform spawnedDefense = Instantiate(redDefenses[i]);
			spawnedDefense.parent = redMounts[i];
			spawnedDefense.localPosition = Vector3.zero;
			spawnedDefense.localRotation = Quaternion.identity;
		}

		List<Transform> blueDefenses = new List<Transform>();
		for (int i = 0; i < 4; i++) {
			Transform nextDefense;
			if (Random.value < 0.5)
				nextDefense = choiceA[i];
			else
				nextDefense = choiceB[i];

			blueDefenses.Add(nextDefense);
		}
		blueDefenses.OrderBy(u => Random.value);
		for (int i = 0; i < 4; i++) {
			Transform spawnedDefense = Instantiate(blueDefenses[i]);
			spawnedDefense.parent = blueMounts[i];
			spawnedDefense.localPosition = Vector3.zero;
			spawnedDefense.localRotation = Quaternion.identity;
		}
	}
}
