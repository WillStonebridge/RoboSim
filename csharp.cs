using System.Diagnostics;

public class RunDocker
{
    //Method to run a Docker container
    static void Main()
    {
        string pwd = "C:/Users/wston/Desktop/Purdue/Robotic_Motion/docker_experiment";
        string dockerRun = "docker run -it";
        string dockerAddVolume =  "-v "+pwd+":/src:rw";
        string dockerContainer = "scripting";
        string dockerContainerCommand = "python app.py input.txt output.txt";
        string dockerCommand = string.Join(" ", new string[] {dockerRun, dockerAddVolume, dockerContainer, dockerContainerCommand});

        Console.WriteLine($"cmd: {dockerCommand}");

        //Create a new process to execute the Docker command
        Process process = new Process();
        process.StartInfo.FileName = "cmd.exe"; //for windows
        process.StartInfo.Arguments = $"/C {dockerCommand}"; //C executes the command and closes
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true; 

        //output and error logging
        process.OutputDataReceived += (sender, e) =>
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Console.WriteLine($"Output: {e.Data}");
            }
        };
        process.ErrorDataReceived += (sender, e) =>
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Console.WriteLine($"Error: {e.Data}");
            }
        };

        //run the process
        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        process.WaitForExit();

        //Ensure the container succeeded
        if (process.ExitCode == 0)
        {
            Console.WriteLine("Docker container ran successfully!");
        }
        else
        {
            Console.WriteLine($"Docker process exited with code {process.ExitCode}");
        }
    }
}
