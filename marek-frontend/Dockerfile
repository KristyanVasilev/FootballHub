# Use an official Node.js image as the base
FROM node:16-alpine

# Set the working directory in the container
WORKDIR /app

# Copy the package.json and package-lock.json files to the container
COPY ./package.json .
COPY ./package-lock.json .

# Install dependencies
RUN npm install

# Copy the entire app directory to the container
COPY . .

# Expose the port on which your React app runs (default is 3000)
EXPOSE 3000

# Start the React app with live reloading
CMD ["npm", "start", "start-watch"]

