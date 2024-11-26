# Use the official Python image as a base
FROM python:3.9-slim

# Set the working directory inside the container
WORKDIR /src

#install python libraries
COPY requirements.txt requirements.txt
RUN pip install -r requirements.txt

# Copy the Python script into the container
COPY app.py .

# Set the command to run the script
CMD ["python", "app.py"]
# CMD ["input.txt", "output.txt"]  
# Default args, but can be overridden