import React from "react";
import Message from "./Message";

interface ChatWindowProps {
  chat: { user: string; message: string }[];
}

const ChatWindow: React.FC<ChatWindowProps> = ({ chat }) => {
  const chatComponents = chat.map((m, index) => (
    <Message key={index} user={m.user} message={m.message} />
  ));

  return <div>{chatComponents}</div>;
};

export default ChatWindow;
