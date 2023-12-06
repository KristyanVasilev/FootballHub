// ProductForm.tsx
import React, { useState, ChangeEvent, FormEvent } from "react";
import { Button, Modal, TextField } from "@mui/material";
import axios from "axios";
import { urlCreateProduct } from "../../config/endpoint";

interface ProductFormProps {
  open: boolean;
  onClose: () => void;
}

const CreateProductForm: React.FC<ProductFormProps> = ({ open, onClose }) => {
  const [productName, setProductName] = useState<string>("");
  const [description, setDescription] = useState<string>("");
  const [price, setPrice] = useState<string>("");
  const [image, setImage] = useState<File | null>(null);

  const handleImageChange = (e: ChangeEvent<HTMLInputElement>) => {
    if (e.target.files && e.target.files.length > 0) {
      const file = e.target.files[0];
      setImage(file);
    }
  };

  const handleSubmit = async (e: FormEvent) => {
    e.preventDefault();

    try {
      const formData = new FormData();
      formData.append("productName", productName);
      formData.append("description", description);
      formData.append("price", price);
      if (image) {
        formData.append("image", image);
      }

      const response = await axios.post(urlCreateProduct, formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      });

      console.log("Product created successfully:", response.data);
      window.location.reload();
      onClose();
    } catch (error) {
      console.error("Error creating product:", error);
    }
  };

  return (
    <Modal open={open} onClose={onClose}>
      <div
        style={{ padding: "20px", background: "white", borderRadius: "8px" }}
      >
        <h2>Create a New Product</h2>
        <form onSubmit={handleSubmit}>
          <TextField
            label="Product Name"
            variant="outlined"
            fullWidth
            margin="normal"
            value={productName}
            onChange={(e) => setProductName(e.target.value)}
          />
          <TextField
            label="Price"
            variant="outlined"
            fullWidth
            margin="normal"
            type="number"
            value={price}
            onChange={(e) => setPrice(e.target.value)}
          />
          <TextField
            label="Description"
            variant="outlined"
            fullWidth
            margin="normal"
            value={description}
            onChange={(e) => setDescription(e.target.value)}
          />
          <input
            type="file"
            accept="image/*"
            onChange={handleImageChange}
            style={{ marginBottom: "10px" }}
          />
          <Button type="submit" variant="contained" color="primary">
            Create Product
          </Button>
        </form>
      </div>
    </Modal>
  );
};

export default CreateProductForm;
