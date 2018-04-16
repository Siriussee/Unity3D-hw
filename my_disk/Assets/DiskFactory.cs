using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskFactory : MonoBehaviour
{
	public GameObject disk_prefab = null;                 
	private List<DiskData> used = new List<DiskData>();  
	private List<DiskData> free = new List<DiskData>(); 

	public GameObject GetDisk(int round)
	{
		int choice = 0;
		int scope1 = 1, scope2 = 4, scope3 = 7;
		float start_y = -10f; 
		float ran_x = Random.Range(-1f, 1f) < 0 ? -1 : 1;
		string tag;
		disk_prefab = null;
		for(int i=0;i<free.Count;i++)
		{
			if(free[i].tag == tag)
			{
				disk_prefab = free[i].gameObject;
				free.Remove(free[i]);
				break;
			}
		}
		disk_prefab = Instantiate(Resources.Load<GameObject>("Prefabs/disk1"), new Vector3(0, start_y, 0), Quaternion.identity);
		disk_prefab.GetComponent<DiskData>().direction = new Vector3(ran_x, start_y, 0);
		used.Add(disk_prefab.GetComponent<DiskData>());
		return disk_prefab;
	}
		
	public void FreeDisk(GameObject disk)
	{
		for(int i = 0;i < used.Count; i++)
		{
			if (disk.GetInstanceID() == used[i].gameObject.GetInstanceID())
			{
				used[i].gameObject.SetActive(false);
				free.Add(used[i]);
				used.Remove(used[i]);
				break;
			}
		}
	}
}