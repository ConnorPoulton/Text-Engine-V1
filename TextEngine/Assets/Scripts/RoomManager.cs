using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour {
    //UI elemenets
    public Text roomDescription;
    public GameObject buttonPanel;
    public static RoomManager instance;
    public Image roomImage;

    [SerializeField]
    private Room currentRoom;
    [SerializeField]
    private int _maxPaths;
    private GameObject[] children;

    void Awake()
    {
        instance = this;
        children = new GameObject[_maxPaths];
    }

    void Start()
    {
        LoadRoom();
    }

	public void LoadRoom()
    {
        roomDescription.text = "";
        roomImage.sprite = currentRoom.roomSprite;
        currentRoom.OnLoad();
        ClearPaths();
        foreach (Path path in currentRoom.paths)
        {
            if (path.CheckTags())
            {
                GameObject button = PathButtonPool.instance.GetPooledObject();
                button.transform.SetParent(buttonPanel.transform, false);
                button.GetComponentInChildren<Text>().text = path.GetPathDescription();
                button.transform.localScale = new Vector3(1, 1, 1);
                for (int i = 0; i < path.commands.Count; i++)
                {
                    var pathRef = path.commands[i]; //see variable capture for why we need to do this. 
                    button.GetComponentInChildren<Button>().onClick.AddListener(() => pathRef.Action());
                }
            }
            
        }
    }

    public void ChangeRoom(Room newRoom)
    {
        currentRoom = newRoom;
        LoadRoom();
    }

    public void OutPutToWindow(string output)
    {
        roomDescription.text += " " + output;
    }

    public void ClearPaths()
    {
        Debug.Log("clear");
        int childCount = buttonPanel.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            var child = buttonPanel.transform.GetChild(0);
            child.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
            PathButtonPool.instance.ReturnToPool(child.gameObject);
        }
    }
}
