using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu(menuName = "Room")]
public class Room : ScriptableObject {

    [SerializeField]
    private string _roomName;
    public Path[] paths;
    [SerializeField]
    private LoadCondition[] _loadConditions;
    public Sprite roomSprite;

    //getters and setters
    public string GetRoomName()
    { return _roomName;  }

    public void OnLoad()
    {
        var tagDict = TagManager.instance.TagDict;
        foreach (var loadCondition in _loadConditions)
        {
            if (CheckConditions(loadCondition.conditions))
                RoomManager.instance.OutPutToWindow(loadCondition.textOutput);
        }
    }  
    
    private bool CheckConditions(Condition[] conditions)
    {
        var tagDict = TagManager.instance.TagDict;
        foreach (var condition in conditions)
        {
            if (tagDict[condition.tag] != condition.isSet)
                return false;
        }
        return true;
    }
}

[System.Serializable]
public struct LoadCondition
{
    public Condition[] conditions;
    [TextArea]
    public string textOutput;
}
