using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "commands/TextOutPut")]
public class OutPutToWindow : ICommand {

    [TextArea]
    [SerializeField]
    string _textToOutput;

    public override void Action()
    {
        RoomManager.instance.OutPutToWindow(_textToOutput);
    }
}
