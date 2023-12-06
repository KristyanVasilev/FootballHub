import * as React from "react";
import Card from "@mui/material/Card";
import CardMedia from "@mui/material/CardMedia";
import Grid from "@mui/material/Grid";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { styled, ThemeProvider } from "@mui/material/styles";
import { Product } from "./types";
import axios, { AxiosResponse } from "axios";
import { urlAllPlayers } from "../../config/endpoint";
import { useEffect } from "react";
import ProductModal from "./ProductModal";
import theme from "../../theme";
import { useAuth } from "../../Context/AuthContext";
import Button from "@mui/material/Button";
import ProductForm from "./CreateProductForm";

const ShakeCard = styled(Card)({
  transition: "transform 0.2s ease-out",
  borderRadius: "5%",
  background: "rgba(0, 0, 0, 0.5)",
  "&:hover": {
    transform: "scale(1.05)",
  },
});
const TextOverlay = styled("div")({
  position: "absolute",
  bottom: 0,
  left: 0,
  width: "100%",
  background: "rgba(0, 0, 0, 0.5)",
  padding: "1rem",
  color: "white",
});

export default function AllProducts() {
  const [isProductFormOpen, setProductFormOpen] = React.useState(false);
  const [products, setProducts] = React.useState<Product[]>();
  const [selectedProducts, setSelectedProducts] =
    React.useState<Product | null>(null);
  const handleCardClick = (productId: number) => {
    const clickedProduct = products?.find(
      (product) => product.id === productId
    );
    setSelectedProducts(clickedProduct || null);
  };
  const handleCloseModal = () => {
    setSelectedProducts(null);
  };
  const handleOpenProductForm = () => {
    setProductFormOpen(true);
  };

  useEffect(() => {
    axios
      .get(urlAllPlayers)
      .then((response: AxiosResponse<Product[]>) => {
        setProducts(response.data);
        console.log(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  const { user } = useAuth();

  return (
    <ThemeProvider theme={theme}>
      <Container sx={{ py: 8 }} maxWidth="lg">
        <ProductForm
          open={isProductFormOpen}
          onClose={() => setProductFormOpen(false)}
        />
        <Button
          variant="contained"
          color="primary"
          onClick={handleOpenProductForm}
        >
          Add New Product
        </Button>
        <Grid container spacing={4}>
          {products?.map((product) => (
            <Grid item key={product.id} xs={12} sm={6} md={3}>
              <ShakeCard
                sx={{
                  height: "100%",
                  width: "100%",
                  display: "flex",
                  flexDirection: "column",
                  position: "relative",
                }}
                onClick={() => handleCardClick(product.id)}
              >
                <CardMedia
                  component="div"
                  sx={{
                    height: "100%",
                    width: "100%",
                    position: "relative",
                    "& img": {
                      objectFit: "cover",
                      width: "100%",
                      height: "100%",
                    },
                  }}
                >
                  <img
                    src={product.imageUrl}
                    alt={`Card background for ${product.name}`}
                  />
                  <TextOverlay>
                    <Typography variant="h4" fontWeight="bold">
                      {product.name}
                    </Typography>
                    <Typography variant="h4" fontWeight="bold">
                      {product.price}
                    </Typography>
                  </TextOverlay>
                </CardMedia>
              </ShakeCard>
            </Grid>
          ))}
        </Grid>
        {selectedProducts && (
          <ProductModal product={selectedProducts} onClose={handleCloseModal} />
        )}
      </Container>
    </ThemeProvider>
  );
}
