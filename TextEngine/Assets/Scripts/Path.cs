using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Path  {

    //private variables
    [SerializeField]
    private string pathName;
    [TextArea]
    public string pathDescription;
    [SerializeField]
    private List<ICommand> _commands = new List<ICommand>();
    [SerializeField]
    private List<Condition> conditions = new List<Condition>();

    //getters and setters
    public string GetPathName()
    { return pathName; }
    public string GetPathDescription()
    { return pathDescription; }
    public List<ICommand> commands
    {
        set { _commands = value; }   
        get { return _commands; }
    }

    public bool CheckTags()
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
