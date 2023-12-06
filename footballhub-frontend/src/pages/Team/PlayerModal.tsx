import { Box, Button, Modal, Typography } from "@mui/material";
import { Player } from "./types";

const PlayerModal: React.FC<{ player: Player; onClose: () => void }> = ({
  player,
  onClose,
}) => {
  const style = {
    width: "90%", // Default width for larger screens
    maxWidth: "700px",
    position: "absolute" as "absolute",
    top: "50%",
    left: "50%",
    borderRadius: "15px",
    transform: "translate(-50%, -50%)",
    height: "auto",
    bgcolor: "background.paper",
    boxShadow: 24,
    p: 4,
    overflowY: "auto", // Add a scroll bar if the content overflows vertically
    maxHeight: "80vh", // Set maximum height to 80% of the viewport height
    marginTop: "16px", // Added top margin
    marginBottom: "16px", // Added bottom margin
  };
  const closeButtonStyle = {
    position: "absolute",
    top: "8px",
    right: "10px",
  };
  return (
    <Modal
      open={true}
      onClose={onClose}
      aria-labelledby="modal-modal-title"
      aria-describedby="modal-modal-description"
    >
      <Box sx={style}>
        <Typography variant="h6" component="h2">
          {player.name}
        </Typography>
        <Button onClick={onClose} sx={closeButtonStyle}>
          X
        </Button>
        <Typography sx={{ mt: 2 }}>
          <strong>Cards:</strong> N/A
        </Typography>

        <Typography sx={{ mt: 2 }}>
          <strong>Goals:</strong> N/A
        </Typography>

        <Typography sx={{ mt: 2 }}>
          <strong>Games:</strong> N/A
        </Typography>

        <img
          src={player.photo}
          alt={`Card background for ${player.name}`}
          style={{
            width: "40%",
            borderRadius: "8px",
            marginTop: "16px",
            marginBottom: "16px",
          }}
        />

        <Typography variant="body1" sx={{ mt: 2 }}>
          {/* Additional text after the image */}
          Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla ac
          ligula euismod, efficitur libero eu, dignissim ligula. Proin id urna
          nec nisl dapibus fermentum. Nullam eleifend, purus at cursus
          sollicitudin, mauris libero malesuada dui, ut tincidunt odio libero
          vitae erat.
        </Typography>
      </Box>
    </Modal>
  );
};

export default PlayerModal;
