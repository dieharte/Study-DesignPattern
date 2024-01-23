// TODO: Manage the limit of list size

using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker
{
    List<ICommand> historicStack = new List<ICommand>();

    private int stackCurrentIndex;

    public void ExecuteCommand(ICommand command)
    {
        for (int i = historicStack.Count; i > stackCurrentIndex; i--)
            historicStack.RemoveAt(i);

        command.Execute();
        historicStack.Add(command);
        stackCurrentIndex = historicStack.Count;
    }

    public void UndoCommand()
    {
        if (historicStack.Count > 0)
        {
            ICommand activeCommand = historicStack[^1];
            historicStack.RemoveAt(historicStack.Count-1);
            activeCommand.Undo();
            stackCurrentIndex--;
        }
    }

    public void RedoCommand()
    {
        if(stackCurrentIndex == historicStack.Count)
        {
            Debug.Log("Redo Action - Is in last action");
            return;
        }
        historicStack[stackCurrentIndex].Execute();
        stackCurrentIndex++;
    }

    public void ResetStack() => historicStack.Clear();


    //private Stack<ICommand> historicStack = new Stack<ICommand>();

    //private int stackCurrentIndex;

    //public void ExecuteCommand(ICommand command)
    //{
    //    command.Execute();
    //    historicStack.Push(command);
    //}

    //public void ExecuteCommand()
    //{

    //}

    //public void UndoCommand()
    //{
    //    if (historicStack.Count > 0)
    //    {
    //        ICommand activeCommand = historicStack.Pop();
    //        activeCommand.Undo();
    //        stackCurrentIndex--;
    //    }
    //}

    //public void RedoCommand()
    //{

    //}
}