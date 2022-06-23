using System.Collections.Generic;

namespace RSGymPT
{

    /// <summary>
    /// Interface to define console application commands
    /// </summary>
    internal interface IRunnable
    {
        /// <summary>
        /// The command itself
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Description of what the command actualy do
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Example of hpw to use the command
        /// </summary>
        string Use { get; }

        /// <summary>
        /// List of parameters, if any, and its values
        /// </summary>
        Dictionary<string,string> Parameters { get; set; }

        /// <summary>
        /// Check is the command parameters are valid
        /// </summary>
        /// <returns>Success<bool></returns>
        bool HasValidParameters();

        /// <summary>
        /// Runs a given command using its defined parameters
        /// </summary>
        /// <returns>Success<bool></returns>
        bool Run();

        /// <summary>
        /// Creates a string containing information about the command and its use
        /// </summary>
        /// <returns>CommandString<string></returns>
        string Help();
    
    }

}
