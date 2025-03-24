package main

import (
	"fmt"
	"io"
	"net"
)

const PORT int = 9000

func main() {
	address := fmt.Sprintf(":%d", PORT)
	lsnr, err := net.Listen("tcp", address)
	if err != nil {
		fmt.Println("Error:", err)
		return
	}
	defer lsnr.Close()

	fmt.Println("Server listening on port ", address)

	for {
		conn, err := lsnr.Accept()
		if err != nil {
			if err == io.EOF {
				fmt.Println("Client Disconnected: ", conn.RemoteAddr())
			} else {
				fmt.Println("Error reading:", err)
			}
			return
		}

		go handleConnection(conn)
	}
}

func handleConnection(conn net.Conn) {
	defer conn.Close()
	fmt.Println("client connected: ", conn.RemoteAddr())

	buffer := make([]byte, 1024)
	n, err := conn.Read(buffer)
	if err != nil {
		fmt.Println("Error reading:", err)
		return
	}
	fmt.Println("Received:", string(buffer[:n]))

	conn.Write([]byte("Hello from server\n"))
}
