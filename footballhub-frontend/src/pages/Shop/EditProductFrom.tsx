import React, { useState, useEffect, ChangeEvent, FormEvent } from "react";
import { Button, Modal, TextField } from "@mui/material";
import axios from "axios";
import { urlEditProduct, urlGetProductById } from "../../config/endpoint";

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
  const [productDescription, setProductDescription] = useState<string>("");
  const [image, setImage] = useState<File | null>(null);

  useEffect(() => {
    const fetchProductData = async () => {
      try {
        const response = await axios.get(`${urlGetProductById}${productId}`);
        const productData = response.data;

        setProductName(productData.name);
        setProductDescription(productData.description);
        setPrice(productData.price);
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
      formData.append("description", productDescription);
      formData.append("price", price);
      if (image) {
        formData.append("image", image);
      }

      // Replace 'your-api-endpoint' with your actual backend API endpoint
      const response = await axios.put(
        `${urlEditProduct}/${productId}`,
        formData,
        {
          headers: {
            "Content-Type": "multipart/form-data",
          },
        }
      );

      console.log("Product updated successfully:", response.data);

      window.location.reload();
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
          <TextField
            label="Description"
            variant="outlined"
            fullWidth
            margin="normal"
            value={productDescription}
            onChange={(e) => setProductDescription(e.target.value)}
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
