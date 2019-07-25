using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "commands/setTag")]
public class SetTag : ICommand {

    [SerializeField]
    TagManager.Tag _tagToSet;

    public override void Action()
    {
        TagManager.instance.SetTag(_tagToSet);
        RoomManager.instance.LoadRoom();
    }
}
