import { Box, Button, Modal, Typography } from "@mui/material";
import { Product } from "./types";
import { useAuth } from "../../Context/AuthContext";
import EditProductForm from "./EditProductFrom";
import ToastrModal from "./ToastrModal";
import { useState } from "react";
import axios from "axios";
import { urlDeleteProduct } from "../../config/endpoint";

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
    try {
      axios.delete(`${urlDeleteProduct}/${product.id}`);

      console.log("Product deleted successfully");
      window.location.reload();
    } catch (error) {
      console.error("Error deleting product:", error);
    }
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
          <Typography variant="h3" component="h2">
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

          <Typography sx={{ mt: 2 }} variant="h5">
            Price:
            {product.price}$
          </Typography>

          <img
            src={product.imageUrl}
            alt={`/images/0cff698a-a697-4f57-821f-916e1e18ff49.png`}
            style={{
              width: "40%",
              borderRadius: "8px",
              marginTop: "16px",
              marginBottom: "16px",
            }}
          />

          <Typography variant="body1" sx={{ mt: 2 }}>
            <strong>Description: </strong>
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
