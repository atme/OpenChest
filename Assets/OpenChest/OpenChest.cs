using UnityEngine;
using System.Collections;

public class OpenChest : MonoBehaviour {

	private ArrayList items;
	private int chances = 0;
	private GameObject droppedItem;

	// Use this for initialization
	void Start () {
		items = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void DropItem () {
		int random = Random.Range(0, chances);
		int currentSum = 0;
		foreach (Hashtable item in items) {
			int chance = (int)item["chance"];
			if (currentSum <= random && random < currentSum + chance) {
				droppedItem = (GameObject)item["object"];
				break;
			}
			currentSum += chance;
		}
	}

	public void AddObject (GameObject addedObject, int chance) {
		Hashtable item = new Hashtable();
		item.Add("object", addedObject);
		item.Add("chance", chance);
		items.Add(item);

		chances += chance;
	}

	public void StartAnimation () {
		DropItem();
	}

	public GameObject GetDroppedItem () {
		return droppedItem;
	}
}
