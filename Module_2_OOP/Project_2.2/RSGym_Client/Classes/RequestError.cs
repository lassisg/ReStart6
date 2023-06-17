namespace RSGym_DAL
{

    public struct RequestError
    {
        public string Parameter { get; set; }
        public string Input { get; set; }
        public string Message { get; set; }

        public RequestError(string parameter, string input, string message)
        {
            Parameter = parameter;
            Input = input;
            Message = message;
        }

    }

}
