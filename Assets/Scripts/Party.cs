using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour {

    [SerializeField] protected int maxSize = 4;
    protected int size = 0;
    protected List<Classes> members;

    public void AddMember(Classes member) {
        if (size < maxSize) {
            members.Add(member);
            size++;
        }
    }

    public void RemoveMember(Classes member) {
        if (members.Contains(member)) {
            members.Remove(member);
            size--;
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
