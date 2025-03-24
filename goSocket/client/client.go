package main

import (
	"fmt"
	"net"
)

const PORT int = 9000

func main() {
	address := fmt.Sprintf("localhost:%d", PORT)
	conn, err := net.Dial("tcp", address)

	if err != nil {
		fmt.Println("Error: ", err)
		return
	}
	defer conn.Close()

	message := "Hello, Server!"
	conn.Write([]byte(message))

	buffer := make([]byte, 1024)
	n, err := conn.Read(buffer)

	if err != nil {
		fmt.Println("Error reading:", err)
		return
	}
	fmt.Println("Server response: ", string(buffer[:n]))
}
