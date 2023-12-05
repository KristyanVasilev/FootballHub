import { Box, Button, Modal, Typography } from "@mui/material";
import { Product } from "./types";
import { useAuth } from "../../Context/AuthContext";
import EditProductForm from "./EditProductFrom";
import ToastrModal from "./ToastrModal";
import { useState } from "react";

const ProductModal: React.FC<{
  product: Product;
  onClose: () => void;
}> = ({ product, onClose }) => {
  const { user } = useAuth();

  const style = {
    width: "90%",
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
    overflowY: "auto",
    maxHeight: "80vh",
    marginTop: "16px",
    marginBottom: "16px",
  };
  const closeButtonStyle = {
    position: "absolute",
    top: "8px",
    right: "10px",
  };

  const [editFormOpen, setEditFormOpen] = useState(false);
  const [deleteConfirmationOpen, setDeleteConfirmationOpen] = useState(false);

  const handleEdit = () => {
    // Open the edit form
    setEditFormOpen(true);
  };

  const handleDelete = () => {
    // Open the delete confirmation modal
    setDeleteConfirmationOpen(true);
  };

  const handleConfirmDelete = () => {
    // Add logic to send delete request to the backend with the product ID
    console.log("Deleting product:", product);
    // Close the confirmation modal
    setDeleteConfirmationOpen(false);
  };

  const handleCancelDelete = () => {
    // Close the confirmation modal
    setDeleteConfirmationOpen(false);
  };

  return (
    <>
      <Modal
        open={true}
        onClose={onClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Box sx={style}>
          <Typography variant="h6" component="h2">
            {product.name}
          </Typography>
          <Button onClick={onClose} sx={closeButtonStyle}>
            X
          </Button>

          {user && (
            <>
              <Button
                variant="outlined"
                onClick={handleEdit}
                sx={{ mr: 2, mt: 2 }}
              >
                Edit
              </Button>
              <Button variant="outlined" onClick={handleDelete} sx={{ mt: 2 }}>
                Delete
              </Button>
            </>
          )}

          <Typography sx={{ mt: 2 }}>
            <strong>Cards:</strong>
          </Typography>

          <Typography sx={{ mt: 2 }}>
            <strong>Goals:</strong>
          </Typography>

          <Typography sx={{ mt: 2 }}>
            <strong>Games:</strong>
          </Typography>

          <img
            src={product.imageUrl}
            alt={`Card background for ${product.name}`}
            style={{
              width: "40%",
              borderRadius: "8px",
              marginTop: "16px",
              marginBottom: "16px",
            }}
          />

          <Typography variant="body1" sx={{ mt: 2 }}>
            {product.description}
          </Typography>
        </Box>
      </Modal>

      {editFormOpen && (
        <EditProductForm
          open={editFormOpen}
          onClose={() => setEditFormOpen(false)}
          productId={product.id}
        />
      )}

      {deleteConfirmationOpen && (
        <ToastrModal
          open={deleteConfirmationOpen}
          onClose={handleCancelDelete}
          message="Are you sure you want to delete this product?"
          onConfirm={handleConfirmDelete}
        />
      )}
    </>
  );
};

export default ProductModal;
