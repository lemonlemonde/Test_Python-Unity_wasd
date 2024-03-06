import socket
import keyboard




def on_key_down(key):
    global key_pressed
    global client_socket
    

def on_key_up(key):
    global key_pressed
    global client_socket
    

def main():
    key_pressed = False;
    client_socket = None;
    # Port to open the socket connection
    # get the ip addr
    # ip = "10.26.243.233"
    ip = "127.0.0.1"
    port = 3000  # initiate port num above 1024

    # Create a socket object
    client_socket = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
    print("Socket successfully created on ip: " + ip + " and port: " + str(port))
    # server_socket.bind((ip, port))

    client_socket.connect((ip, port))

    # one client can connect
    # server_socket.listen(1)
    # conn, address = server_socket.accept()
    # print("Connection from: " + str(address))

    # # Hotkeys for sending the WASD commands
    # keyboard.add_hotkey('w', sendKey, args=(client_socket, "w"))
    # keyboard.add_hotkey('a', sendKey, args=(client_socket, "a"))
    # keyboard.add_hotkey('s', sendKey, args=(client_socket, "s"))
    # keyboard.add_hotkey('d', sendKey, args=(client_socket, "d"))
    # keyboard.add_hotkey('q', sendKey, args=(client_socket, "q"))
    
    while True:
        # Wait for the next event.
        event = keyboard.read_event()

        if event.event_type == keyboard.KEY_DOWN:
            print(event.name) # to check key name
            if (event.name == "esc"):
                break
            
            if key_pressed == False:
                print("Sending: " + event.name + " down")
                client_socket.sendall((event.name + " down").encode('utf-8'))
                key_pressed = True

        elif event.event_type == keyboard.KEY_UP:
            print(event.name)
            key_pressed = False
            print("Sending: " + event.name + " up")
            client_socket.sendall((event.name + " up").encode('utf-8'))
        



    # Keep the program running until interrupted
    # try:
    #     while True:
    #         pass
    # except KeyboardInterrupt:
    #     pass

    # unhook
    # keyboard.unhook_all()
    # Close the socket connection
    client_socket.close()
    # server_socket.close()
    print("Connection closed")


if __name__ == "__main__":
    main()