using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour {

	public Transform player;
	public float spawnInterval = 1f;

	public float minDistanceFromPlayer = 10f;

	public GameObject[] objects;
	public float[] weights;

	float minX, minZ, maxX, maxZ;
	Transform self;
	float sumWeights;
	int numObjects;

    // Start is called before the first frame update
    void Start() {
        self = GetComponent<Transform>();
		Vector3 position = self.position;
		Vector3 scale = self.lossyScale;
		minX = position.x - scale.x/2;
		maxX = position.x + scale.x/2;
		minZ = position.z - scale.z/2;
		maxZ = position.z + scale.z/2;

		sumWeights = 0;
		numObjects = 0;
		foreach(float weight in weights) {
			sumWeights += weight;
			++numObjects;
		}

		StartCoroutine("SelectObjectToSpawn");
		StartCoroutine("SelectObjectToSpawn");
		StartCoroutine("SelectObjectToSpawn");
    }

    IEnumerator SelectObjectToSpawn() {

		float randomNumber = Random.Range(0.0f, sumWeights);

		int i = 0;
		foreach(float weight in weights) {
			if (randomNumber < weight) break;
			++i;
			randomNumber -= weight;
		}

		if (i >= numObjects) i = numObjects-1;

		Spawn(i);

		yield return new WaitForSeconds(spawnInterval);
		StartCoroutine("SelectObjectToSpawn");
	}

	void Spawn(int objIndex) {

		Vector3 randomPosition; 
		Quaternion randomRotation = Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f);

		do {
			randomPosition = new Vector3(Random.Range(minX, maxX), player.position.y, Random.Range(minZ, maxZ));
		} while (CloseToPlayer(randomPosition));
		

		if (objIndex < 0 || objIndex >= numObjects) return;
		GameObject obj = Instantiate(objects[objIndex], randomPosition, randomRotation);
		
		Destroy(obj, Random.Range(10, 15));
	}

	bool CloseToPlayer(Vector3 position) {
		return ((position - player.position).magnitude < minDistanceFromPlayer);
	}

}
