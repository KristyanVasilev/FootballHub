import React from "react";
import { Box, Button, Modal, Typography } from "@mui/material";
import { useTheme } from "@mui/system";
import theme from "../../theme";

const ToastrModal: React.FC<{
  open: boolean;
  onClose: () => void;
  message: string;
  onConfirm: () => void;
}> = ({ open, onClose, message, onConfirm }) => {
  const theme = useTheme();

  const modalStyle = {
    position: "fixed" as "fixed",
    top: "50%",
    left: "50%",
    transform: "translate(-50%, -50%)",
    padding: "20px",
    backgroundColor: "white",
    color: "black",
    textAlign: "center",
    borderRadius: "8px",
  };

  const buttonStyle = {
    margin: "8px",
  };

  return (
    <Modal open={open} onClose={onClose}>
      <Box sx={modalStyle}>
        <Typography variant="body1">{message}</Typography>
        <Button variant="contained" onClick={onConfirm} sx={buttonStyle}>
          Confirm
        </Button>
        <Button variant="outlined" onClick={onClose} sx={buttonStyle}>
          Cancel
        </Button>
      </Box>
    </Modal>
  );
};

export default ToastrModal;
