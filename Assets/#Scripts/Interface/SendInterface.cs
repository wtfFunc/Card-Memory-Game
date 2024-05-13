using UnityEngine;

public interface ICommunicator
{
    void SendMessage(string message);
}

// 구현 클래스
public class Communicator : ICommunicator
{
    public void SendMessage(string message)
    {
        Debug.Log("Sending message: " + message);
    }
}

// 요소 클래스
public class Element
{
    private ICommunicator communicator;

    public Element(ICommunicator communicator)
    {
        this.communicator = communicator;
    }

    public void PerformAction()
    {
        communicator.SendMessage("Performing action");
    }

}

