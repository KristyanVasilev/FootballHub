import React, { useState } from "react";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import { FormControl, InputLabel, MenuItem, Select } from "@mui/material";
import { SelectChangeEvent } from "@mui/material/Select";

const MyForm: React.FC = () => {
  const [inputValue, setInputValue] = useState("");
  const [textSize, setTextSize] = useState("medium");
  const [isBold, setIsBold] = useState(false);
  const [isItalic, setIsItalic] = useState(false);
  const [isUnderline, setIsUnderline] = useState(false);
  const [submittedTexts, setSubmittedTexts] = useState<
    { text: string; style: any }[]
  >([]);

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setInputValue(event.target.value);
  };

  const handleTextSizeChange = (event: SelectChangeEvent<string>) => {
    setTextSize(event.target.value);
  };

  const handleBoldClick = () => {
    setIsBold(!isBold);
  };

  const handleItalicClick = () => {
    setIsItalic(!isItalic);
  };

  const handleUnderlineClick = () => {
    setIsUnderline(!isUnderline);
  };

  const handleSubmit = (event: React.FormEvent) => {
    event.preventDefault();
    // Optionally, you can reset the input field after submission
    setInputValue("");

    // Create a new object with the text and the current style for this submission
    const newSubmittedText = {
      text: inputValue,
      style: {
        fontWeight: isBold ? "bold" : "normal",
        fontStyle: isItalic ? "italic" : "normal",
        textDecoration: isUnderline ? "underline" : "none",
      },
    };

    // Add the newSubmittedText to the submittedTexts array
    setSubmittedTexts((prevSubmittedTexts) => [
      ...prevSubmittedTexts,
      newSubmittedText,
    ]);

    setIsBold(false);
    setIsItalic(false);
    setIsUnderline(false);
    setTextSize("medium");
  };

  return (
    <form onSubmit={handleSubmit}>
      <TextField
        label="Enter your text"
        variant="outlined"
        value={inputValue}
        onChange={handleInputChange}
        fullWidth
        multiline
        style={{
          fontSize:
            textSize === "small"
              ? "12px"
              : textSize === "large"
              ? "20px"
              : "14px",
          fontWeight: isBold ? "bold" : "normal",
          fontStyle: isItalic ? "italic" : "normal",
          textDecoration: isUnderline ? "underline" : "none",
        }}
        inputProps={{
          style: {
            fontSize:
              textSize === "small"
                ? "12px"
                : textSize === "large"
                ? "20px"
                : "14px",
            fontWeight: isBold ? "bold" : "normal",
          },
        }}
      />

      <FormControl>
        <InputLabel>Text Size</InputLabel>
        <Select value={textSize} onChange={handleTextSizeChange}>
          <MenuItem value="small">Small</MenuItem>
          <MenuItem value="medium">Medium</MenuItem>
          <MenuItem value="large">Large</MenuItem>
        </Select>
      </FormControl>

      <Button variant="contained" onClick={handleBoldClick}>
        {isBold ? "Unbold" : "Bold"}
      </Button>
      <Button variant="contained" onClick={handleItalicClick}>
        {isItalic ? "Unitalic" : "Italic"}
      </Button>
      <Button variant="contained" onClick={handleUnderlineClick}>
        {isUnderline ? "Remove Underline" : "Underline"}
      </Button>

      <Button type="submit" variant="contained" color="primary">
        Submit
      </Button>

      {submittedTexts.map(({ text, style }, index) => (
        <p key={index} style={style}>
          {text}
        </p>
      ))}
    </form>
  );
};

export default MyForm;
