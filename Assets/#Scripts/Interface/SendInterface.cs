using UnityEngine;

public interface ICommunicator
{
    void SendMessage(string message);
}

// ���� Ŭ����
public class Communicator : ICommunicator
{
    public void SendMessage(string message)
    {
        Debug.Log("Sending message: " + message);
    }
}

// ��� Ŭ����
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

