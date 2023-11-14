import React, { useState } from "react";

interface ChatInputProps {
  sendMessage: (user: string, message: string) => void;
}

const ChatInput: React.FC<ChatInputProps> = (props) => {
  const [user, setUser] = useState("");
  const [message, setMessage] = useState("");

  const onSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    const isUserProvided = user && user !== "";
    const isMessageProvided = message && message !== "";

    if (isUserProvided && isMessageProvided) {
      props.sendMessage(user, message);
    } else {
      alert("Please insert an user and a message.");
    }
  };

  const onUserUpdate = (e: React.ChangeEvent<HTMLInputElement>) => {
    setUser(e.target.value);
  };

  const onMessageUpdate = (e: React.ChangeEvent<HTMLInputElement>) => {
    setMessage(e.target.value);
  };

  return (
    <form onSubmit={onSubmit}>
      <label htmlFor="user">User:</label>
      <br />
      <input id="user" name="user" value={user} onChange={onUserUpdate} />
      <br />
      <label htmlFor="message">Message:</label>
      <br />
      <input
        type="text"
        id="message"
        name="message"
        value={message}
        onChange={onMessageUpdate}
      />
      <br />
      <br />
      <button>Submit</button>
    </form>
  );
};

export default ChatInput;
