import React, { useState, useEffect, ChangeEvent, FormEvent } from "react";
import { Button, Modal, TextField } from "@mui/material";
import axios from "axios";

interface EditProductFormProps {
  open: boolean;
  onClose: () => void;
  productId: number; // Pass the product ID as a prop for fetching existing data
}

const EditProductForm: React.FC<EditProductFormProps> = ({
  open,
  onClose,
  productId,
}) => {
  const [productName, setProductName] = useState<string>("");
  const [price, setPrice] = useState<string>("");
  const [image, setImage] = useState<File | null>(null);

  useEffect(() => {
    const fetchProductData = async () => {
      try {
        // Replace 'your-api-endpoint' with your actual backend API endpoint
        const response = await axios.get(
          `your-api-endpoint/products/${productId}`
        );
        const productData = response.data;

        setProductName(productData.productName);
        setPrice(productData.price);
        // You may need to handle the image data as well
      } catch (error) {
        console.error("Error fetching product data:", error);
      }
    };

    if (open && productId) {
      fetchProductData();
    }
  }, [open, productId]);

  const handleImageChange = (e: ChangeEvent<HTMLInputElement>) => {
    // Handle the image change event and set the selected file
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
      formData.append("price", price);
      if (image) {
        formData.append("image", image);
      }

      // Replace 'your-api-endpoint' with your actual backend API endpoint
      const response = await axios.put(
        `your-api-endpoint/products/${productId}`,
        formData,
        {
          headers: {
            "Content-Type": "multipart/form-data",
          },
        }
      );

      console.log("Product updated successfully:", response.data);

      // Close the modal
      onClose();
    } catch (error) {
      console.error("Error updating product:", error);
    }
  };

  return (
    <Modal open={open} onClose={onClose}>
      <div
        style={{ padding: "20px", background: "white", borderRadius: "8px" }}
      >
        <h2>Edit Product</h2>
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
          <input
            type="file"
            accept="image/*"
            onChange={handleImageChange}
            style={{ marginBottom: "10px" }}
          />
          <Button type="submit" variant="contained" color="primary">
            Update Product
          </Button>
        </form>
      </div>
    </Modal>
  );
};

export default EditProductForm;
