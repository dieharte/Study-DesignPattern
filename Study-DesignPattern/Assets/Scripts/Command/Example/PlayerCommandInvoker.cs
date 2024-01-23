using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommandInvoker : MonoBehaviour
{
    private PlayerMove playerMove;
    private CommandInvoker commandInvoker;

    private void Awake()
    {
        playerMove = gameObject.AddComponent<PlayerMove>();
        commandInvoker = new CommandInvoker();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            commandInvoker.ExecuteCommand(new MoveCommand(playerMove, Vector3.up));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            commandInvoker.ExecuteCommand(new MoveCommand(playerMove, Vector3.down));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("MYLOG: right");
            commandInvoker.ExecuteCommand(new MoveCommand(playerMove, Vector3.right));
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            commandInvoker.ExecuteCommand(new MoveCommand(playerMove, Vector3.left));
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            commandInvoker.UndoCommand();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            commandInvoker.RedoCommand();
        }
    }
}
