using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "commands/exit")]
public class Exit : ICommand
{
    public Room newRoom;
    public TagManager.Tag[] tags;

    public override void Action()
    {
        RoomManager.instance.ChangeRoom(newRoom);
    }

    

}
