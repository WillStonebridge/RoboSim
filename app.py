import sys
import numpy as np

def copy_file_contents(input_filepath, output_filepath):
    matrix = np.array([[1, 2], [3, 4]])
    inverse_matrix = np.linalg.inv(matrix)

    try:
        # Open the input file in read mode
        with open(input_filepath, 'r') as input_file:
            data = input_file.read()

        # Open the output file in write mode
        with open(output_filepath, 'w') as output_file:
            output_file.write(data+str(inverse_matrix))
        
        print(f"Contents copied successfully from {input_filepath} to {output_filepath}")

    except FileNotFoundError:
        print(f"Error: The file {input_filepath} was not found.")
    except IOError as e:
        print(f"Error: An I/O error occurred. {e}")

if __name__ == "__main__":
    if len(sys.argv) != 3:
        print("requires 2 arguments")
    else:
        # Get file paths as input from the user
        input_path = sys.argv[1]
        output_path = sys.argv[2]

        # Call the function to copy contents
        copy_file_contents(input_path, output_path)
