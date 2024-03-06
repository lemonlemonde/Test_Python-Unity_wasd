using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;

public class Connection : MonoBehaviour
{
    Thread thread;
    int connectionPort = 3000;
    TcpListener server;
    TcpClient client;
    bool running;

    public Controller controller;


    void Start()
    {
        // Receive on a separate thread so Unity doesn't freeze waiting for data
        ThreadStart ts = new ThreadStart(GetData);
        thread = new Thread(ts);
        thread.Start();
    }

    void GetData()
    {
        // Create the server
        server = new TcpListener(IPAddress.Any, connectionPort);
        server.Start();

        // Create a client to get the data stream
        client = server.AcceptTcpClient();

        // Start listening
        running = true;
        while (running)
        {
            GetConnection();
        }
        server.Stop();
    }

    void GetConnection()
    {
        // Read data from the network stream
        NetworkStream nwStream = client.GetStream();
        byte[] buffer = new byte[client.ReceiveBufferSize];
        int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

        // Decode the bytes into a string
        string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        
        // Make sure we're not getting an empty string
        //dataReceived.Trim();
        if (dataReceived != null && dataReceived != "")
        {
            // Debug.Log("received: " + dataReceived);
            controller.Command(dataReceived);
        }
    }


    // Position is the data being received in this example
    Vector3 position = Vector3.zero;

    void Update()
    {
        // Set this object's position in the scene according to the position received
        // transform.position = position;
    }
}