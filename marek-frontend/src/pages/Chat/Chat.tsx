import React, { useState, useEffect, useRef } from "react";
import { HubConnectionBuilder, HubConnection } from "@microsoft/signalr";

import ChatWindow from "./ChatWindow";
import ChatInput from "./ChatInput";

interface ChatMessage {
  user: string;
  message: string;
}

const Chat: React.FC = () => {
  const [chat, setChat] = useState<ChatMessage[]>([]);
  const latestChat = useRef<ChatMessage[]>([]);

  latestChat.current = chat;

  useEffect(() => {
    const connection: HubConnection = new HubConnectionBuilder()
      .withUrl("https://localhost:7043/Chat/messages")
      .withAutomaticReconnect()
      .build();

    connection
      .start()
      .then((result) => {
        console.log("Connected!");

        connection.on("ReceiveMessage", (message: ChatMessage) => {
          const updatedChat = [...latestChat.current];
          updatedChat.push(message);

          setChat(updatedChat);
        });
      })
      .catch((e) => console.log("Connection failed: ", e));
  }, []);

  const sendMessage = async (user: string, message: string) => {
    const chatMessage: ChatMessage = {
      user: user,
      message: message,
    };

    try {
      await fetch("https://localhost:7043/Chat/messages", {
        method: "POST",
        body: JSON.stringify(chatMessage),
        headers: {
          "Content-Type": "application/json",
        },
      });
    } catch (e) {
      console.log("Sending message failed.", e);
    }
  };

  return (
    <div>
      <ChatInput sendMessage={sendMessage} />
      <hr />
      <ChatWindow chat={chat} />
    </div>
  );
};

export default Chat;
